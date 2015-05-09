using AutoMapper;
using HDLink;
using Storyboard.Data.DbObject;
using Storyboard.Data.Helpers;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Storyboard.Data.Core
{
    public class ActorRepository : IActorRepository, IAsyncNodeRepository
    {
        private readonly ILinkDataService linkDataService;
        private readonly StoryboardContext dbContext;

        public ActorRepository(ILinkDataService linkDataService, StoryboardContext dbContext)
        {
            Mapper.CreateMap<ActorTableRow, Actor>();
            Mapper.CreateMap<AddUpdateActorCommand, ActorTableRow>();
            this.dbContext = dbContext;
            this.linkDataService = linkDataService;
        }

        public async Task<List<Actor>> GetAsync()
        {
           var rows = await (from row in dbContext.Actor
                                 select row).ToListAsync();
            return rows.Select(Mapper.Map<Actor>).ToList();           
        }

        /// <summary>
        /// Gets requested story
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested Story or Null if none is found</returns>
        public async Task<Actor> GetAsync(int id)
        {            
            return Mapper.Map<Actor>(await dbContext.Actor.SingleOrDefaultAsync(r=> r.Id == id));            
        }

        async Task<INode> IAsyncNodeRepository.GetAsync(int id)
        {
            return Mapper.Map<Actor>(await dbContext.Actor.SingleOrDefaultAsync(r => r.Id == id));         
        }


        public async Task<List<Actor>> GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<Actor>();

            foreach (var chunk in chunkedIds)
            {
                var range = await (from row in dbContext.Actor
                                    where chunk.Contains(row.Id)
                                    select row).ToListAsync();
                result.AddRange(range.Select(Mapper.Map<Actor>));
            }

            return result;           
        }

        async Task<List<INode>> IAsyncNodeRepository.GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<INode>();
            foreach (var chunk in chunkedIds)
            {
                var range = await (from row in dbContext.Actor
                                    where chunk.Contains(row.Id)
                                    select row).ToListAsync();
                result.AddRange(range.Select(Mapper.Map<Actor>));
            }
            return result;
        }

        public async Task Delete(int id)
        {
            var row = new ActorTableRow { Id = id };
            dbContext.Entry(row).State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
            await linkDataService.Remove(new Node(id, StoryboardNodeTypes.Actor));
        }

        public async Task Update(AddUpdateActorCommand command)
        {
            var row = Mapper.Map<ActorTableRow>(command);
            dbContext.Actor.Attach(row);
            dbContext.Entry(row).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        
        public async Task<int> Add(AddUpdateActorCommand command)
        {
            var row = Mapper.Map<ActorTableRow>(command);
            dbContext.Actor.Add(row);
            await dbContext.SaveChangesAsync();
            return row.Id;
        }

    }
}
