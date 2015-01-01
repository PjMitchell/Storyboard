using HDLink;
using Simple.Data;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storyboard.Data.Helpers;

namespace Storyboard.Data.Core
{
    public class ActorRepository : IActorRepository, INodeRepository<Actor>, INodeRepository, IAsyncNodeRepository
    {
        private readonly ILinkDataService linkDataService;
        
        public ActorRepository(ILinkDataService linkDataService)
        {
            this.linkDataService = linkDataService;
        }
        
        public IEnumerable<Actor> Get()
        {
            var db = Database.Open();
            IEnumerable<Actor> actor = db.Story.Actor.All();
            return actor;
        }

        public Actor Get(int id)
        {
            var db = Database.Open();
            Actor actor = db.Story.Actor.FindAllById(id).SingleOrDefault();
            return actor;
        }

        public IEnumerable<Actor> Get(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var db = Database.Open();
            return chunkedIds.SelectMany(chunk =>
                {
                    IEnumerable<Actor> chunkResult = db.Story.Actor.FindAllById(chunk.ToArray());
                    return chunkResult;
                });
        }

        public void AddOrUpdate(AddUpdateActorCommand command)
        {
            var db = Database.Open();
            if (command.Id == 0)
            {
                AddUpdateActorCommand result = db.Story.Actor.Insert(command);
                command.Id = result.Id;
            }
            else
            {
                db.Story.Actor.Update(command);
            }
        }

        public void Delete(int id)
        {
            var db = Database.Open();
            db.Story.Actor.DeleteById(id);
            linkDataService.Remove(new Node(id, StoryboardNodeTypes.Actor));
        }



        IEnumerable<INode> INodeRepository.Get(IEnumerable<int> ids)
        {
            return Get(ids);
        }

        INode INodeRepository.Get(int id)
        {
            return Get(id); ;
        }

        public Task<List<Actor>> GetAsync(IEnumerable<int> ids)
        {
            return Task.Run(() => Get(ids).ToList());
        }

        public Task<Actor> GetAsync(int id)
        {
            return Task.Run(() => Get(id));
        }

        Task<List<INode>> IAsyncNodeRepository.GetAsync(IEnumerable<int> ids)
        {
            return Task.Run(() => Get(ids).ToList<INode>()); ;
        }

        Task<INode> IAsyncNodeRepository.GetAsync(int id)
        {
            return Task.Run(() => (INode)Get(id)); ;
        }
    }
}
