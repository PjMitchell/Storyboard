using AutoMapper;
using HDLink;
using Storyboard.Data.EF.DbObject;
using Storyboard.Data.EF.Helpers;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Storyboard.Data.EF.Core
{
    public class ActorRepository : IActorRepository, IAsyncNodeRepository
    {
        private readonly ILinkDataService linkDataService;
        
        public ActorRepository(ILinkDataService linkDataService)
        {
            Mapper.CreateMap<ActorTableRow, Actor>();
            Mapper.CreateMap<AddUpdateActorCommand, ActorTableRow>();
            this.linkDataService = linkDataService;
        }

        public async Task<List<Actor>> GetAsync()
        {
            using (var db = new StoryboardContext())
            {
                var rows = await (from row in db.Actor
                                 select row).ToListAsync();
                return rows.Select(Mapper.Map<Actor>).ToList();

            }
        }

        /// <summary>
        /// Gets requested story
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested Story or Null if none is found</returns>
        public async Task<Actor> GetAsync(int id)
        {
            using (var db = new StoryboardContext())
            {
                return Mapper.Map<Actor>(await db.Actor.FindAsync(id));
            }
        }

        async Task<INode> IAsyncNodeRepository.GetAsync(int id)
        {
            using (var db = new StoryboardContext())
            {
                return Mapper.Map<Actor>(await db.Actor.FindAsync(id));
            }
        }


        public async Task<List<Actor>> GetAsync(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var result = new List<Actor>();
            using (var db = new StoryboardContext())
            {
                foreach (var chunk in chunkedIds)
                {
                    var range = await (from row in db.Actor
                                       where chunk.Contains(row.Id)
                                       select row).ToListAsync();
                    result.AddRange(range.Select(Mapper.Map<Actor>));
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
                    var range = await (from row in db.Actor
                                       where chunk.Contains(row.Id)
                                       select row).ToListAsync();
                    result.AddRange(range.Select(Mapper.Map<Actor>));
                }

                return result;
            }
        }
        
        public async Task Delete(int id)
        {
            using (var db = new StoryboardContext())
            {
                var row = new ActorTableRow { Id = id };
                db.Entry(row).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            await linkDataService.Remove(new Node(id, StoryboardNodeTypes.Actor));
        }

        public async Task Update(AddUpdateActorCommand command)
        {
            using (var db = new StoryboardContext())
            {
                var row = Mapper.Map<ActorTableRow>(command);
                db.Actor.Attach(row);
                db.Entry(row).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
        
        public async Task<int> Add(AddUpdateActorCommand command)
        {
            using (var db = new StoryboardContext())
            {
                var row = Mapper.Map<ActorTableRow>(command);
                db.Actor.Add(row);
                await db.SaveChangesAsync();
                return row.Id;
            }
        }

    }
}
