using AutoMapper;
using HDLink;
using Storyboard.Data.Helpers;
using Storyboard.Data.DbObject;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Storyboard.Data.Core
{
    public class StorySectionRepository : IStorySectionRepository
    {
        private readonly StoryboardContext dbContext;

        public StorySectionRepository(StoryboardContext dbContext)
        {
            this.dbContext = dbContext;
            Mapper.CreateMap<StorySectionTableRow, StorySection>();
        }
        
        public async Task<OrderedHierarchicalTree<StorySection>> GetTreeForStory(int storyId)
        {
            var rows = await(from row in dbContext.StorySection
                                where row.StoryId == storyId
                                select row).ToListAsync();
            return new OrderedHierarchicalTree<StorySection>(rows.Select(Mapper.Map<StorySection>));
        }

        public async Task<List<StorySection>> GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<StorySection>();
            foreach (var chunk in chunkedIds)
            {
                var range = await (from row in dbContext.StorySection
                                    where chunk.Contains(row.Id)
                                    select row).ToListAsync();
                result.AddRange(range.Select(Mapper.Map<StorySection>));
            }

            return result;
        }

        public async Task<StorySection> GetAsync(int id)
        {
            return Mapper.Map<StorySection>(await dbContext.StorySection.SingleOrDefaultAsync(r => r.Id == id));
        }

        async Task<List<INode>> IAsyncNodeRepository.GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<INode>();
            foreach (var chunk in chunkedIds)
            {
                var range = await(from row in dbContext.StorySection
                                    where chunk.Contains(row.Id)
                                    select row).ToListAsync();
                result.AddRange(range.Select(Mapper.Map<StorySection>));
            }

            return result;
        }

        async Task<INode> HDLink.IAsyncNodeRepository.GetAsync(int id)
        {
            return Mapper.Map<StorySection>(await dbContext.StorySection.SingleOrDefaultAsync(r => r.Id == id));
        }
    }
}
