using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Storyboard.Data.EF.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using Storyboard.Data.EF.DbObject;

namespace Storyboard.Data.EF.Core
{
    public class StoryRepository : IStoryRepository, IAsyncNodeRepository
    {
        private readonly ILinkDataService linkDataService;
        
        public StoryRepository(ILinkDataService linkDataService)
        {
            this.linkDataService = linkDataService;
            Mapper.CreateMap<StoryTableRow, Story>();
            Mapper.CreateMap<AddUpdateActorCommand, StoryTableRow>();
            
        }
          
      



        /// <summary>
        /// Gets all Stories from Database
        /// </summary>
        /// <returns>All Stories</returns>
        public async Task<List<Story>> GetAsync()
        {
            using(var db = new StoryboardContext())
            {
                var rows = await (from row in db.Story
                        select row).ToListAsync();
                return rows.Select(Mapper.Map<Story>).ToList();
                    
            }
        }

        /// <summary>
        /// Gets requested story
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested Story or Null if none is found</returns>
        public async Task<Story> GetAsync(int id)
        {
            using (var db = new StoryboardContext())
            {
                return Mapper.Map<Story>(await db.Story.FindAsync(id));
            }
        }

        async Task<INode> IAsyncNodeRepository.GetAsync(int id)
        {
            using (var db = new StoryboardContext())
            {
                return Mapper.Map<Story>(await db.Story.FindAsync(id));
            }
        }


        public async Task<List<Story>> GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<Story>();
            using (var db = new StoryboardContext())
            {
                foreach (var chunk in chunkedIds)
                {
                    var range = await (from row in db.Story
                                 where chunk.Contains(row.Id)
                                 select row).ToListAsync();
                    result.AddRange(range.Select(Mapper.Map<Story>));
                }

                return result;
            }
        }

        async Task<List<INode>> IAsyncNodeRepository.GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<INode>();
            using (var db = new StoryboardContext())
            {
                foreach (var chunk in chunkedIds)
                {
                    var range = await(from row in db.Story
                                      where chunk.Contains(row.Id)
                                      select row).ToListAsync();
                    result.AddRange(range.Select(Mapper.Map<Story>));
                }

                return result;
            }
        }

        /// <summary>
        /// Adds or Updates Story
        /// </summary>
        /// <param name="command">Story to be created / updated</param>
        public void AddOrUpdate(AddUpdateStoryCommand command)
        {
            if (command.Id != 0)
                Update(command);
            else
                Add(command);
        }

        /// <summary>
        /// Deletes Story
        /// </summary>
        /// <param name="id">Story Id</param>
        public void Delete(int id)
        {
            using (var db = new StoryboardContext())
            {
                var row = new StoryTableRow { Id = id };
                db.Entry(row).State = EntityState.Deleted;
                db.SaveChanges();
            }
            linkDataService.Remove(new Node(id, StoryboardNodeTypes.Story));
        }

        private void Add(AddUpdateStoryCommand command)
        {
            using (var db = new StoryboardContext())
            {
                var row = Mapper.Map<StoryTableRow>(command);
                db.Story.Add(row);
                db.SaveChanges();
                command.Id = row.Id;
            }
        }

        private void Update(AddUpdateStoryCommand command)
        {
            using (var db = new StoryboardContext())
            {
                var row = Mapper.Map<StoryTableRow>(command);
                db.Story.Attach(row);
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
