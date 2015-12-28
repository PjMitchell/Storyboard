using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Storyboard.Data.Helpers;
using System.Threading.Tasks;
using AutoMapper;
using Storyboard.Data.DbObject;
using Microsoft.Data.Entity;

namespace Storyboard.Data.Core
{
    public class StoryRepository : IStoryRepository
    {
        private readonly ILinkDataService linkDataService;
        private readonly StoryboardContext dbContext;

        public StoryRepository(ILinkDataService linkDataService, StoryboardContext dbContext)
        {
            this.linkDataService = linkDataService;
            this.dbContext = dbContext;
            Mapper.CreateMap<StoryTableRow, Story>();
            Mapper.CreateMap<AddUpdateStoryCommand, StoryTableRow>();
            
        }
     
        /// <summary>
        /// Gets all Stories from Database
        /// </summary>
        /// <returns>All Stories</returns>
        public async Task<List<Story>> GetAsync()
        {
            var rows = await (from row in dbContext.Story
                    select row).ToListAsync();
            return rows.Select(Mapper.Map<Story>).ToList();
        }

        /// <summary>
        /// Gets requested story
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested Story or Null if none is found</returns>
        public async Task<Story> GetAsync(int id) =>
            Mapper.Map<Story>(await dbContext.Story.SingleOrDefaultAsync(r=> r.Id == id));

        async Task<INode> IAsyncNodeRepository.GetAsync(int id) =>
             Mapper.Map<Story>(await dbContext.Story.SingleOrDefaultAsync(r => r.Id == id));



        public async Task<List<Story>> GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<Story>();
            foreach (var chunk in chunkedIds)
            {
                var range = await (from row in dbContext.Story
                                where chunk.Contains(row.Id)
                                select row).ToListAsync();
                result.AddRange(range.Select(Mapper.Map<Story>));
            }

            return result;
        }

        async Task<List<INode>> IAsyncNodeRepository.GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<INode>();
            foreach (var chunk in chunkedIds)
            {
                var range = await(from row in dbContext.Story
                                    where chunk.Contains(row.Id)
                                    select row).ToListAsync();
                result.AddRange(range.Select(Mapper.Map<Story>));
            }

            return result;
        }

        /// <summary>
        /// Deletes Story
        /// </summary>
        /// <param name="id">Story Id</param>
        public async Task Delete(int id)
        {
            var row = new StoryTableRow { Id = id };
            dbContext.Entry(row).State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
            await linkDataService.Remove(new Node(id, StoryboardNodeTypes.Story));
        }

        /// <summary>
        /// Adds Story
        /// </summary>
        /// <param name="command">Story to be created</param>
        public async Task<AddUpdateStoryCommand> Add(AddUpdateStoryCommand command)
        {
            var row = Mapper.Map<StoryTableRow>(command);
            dbContext.Story.Add(row);
            await dbContext.SaveChangesAsync();
            command.Id = row.Id;
            return command;
        }

        /// <summary>
        /// Updates Story
        /// </summary>
        /// <param name="command">Story to be updated</param>
        public async Task Update(AddUpdateStoryCommand command)
        {
            if (command.Id == 0)
                throw new ArgumentOutOfRangeException("command", "Tried update a story with Id of 0");
            var row = Mapper.Map<StoryTableRow>(command);
            dbContext.Story.Attach(row);
            dbContext.Entry(row).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

    }
}
