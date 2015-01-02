﻿using HDLink;
using Simple.Data;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Storyboard.Data.Helpers;
using System.Threading.Tasks;

namespace Storyboard.Data.Core
{
    public class StoryRepository : IStoryRepository, INodeRepository<Story>, INodeRepository, IAsyncNodeRepository
    {
        private readonly ILinkDataService linkDataService;
        
        public StoryRepository(ILinkDataService linkDataService)
        {
            this.linkDataService = linkDataService;
        }
        
        /// <summary>
        /// Gets all Stories from Database
        /// </summary>
        /// <returns>All Stories</returns>
        public Task<List<Story>> GetAsync()
        {
            return Task.Run(()=>{
            var db = Database.Open();
            IEnumerable<Story> stories = db.Story.Story.All();
                return stories.ToList();
            });
            
        }

        /// <summary>
        /// Gets requested story
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested Story or Null if none is found</returns>
        public Story Get(int id)
        {
            var db = Database.Open();
            Story story = db.Story.Story.FindAllById(id).SingleOrDefault();
            return story;
        }

        /// <summary>
        /// Adds or Updates Story
        /// </summary>
        /// <param name="command">Story to be created / updated</param>
        public void AddOrUpdate(AddUpdateStoryCommand command)
        {
            var db = Database.Open();
            if (command.Id == 0)
            {
                AddUpdateStoryCommand result = db.Story.Story.Insert(command);
                command.Id = result.Id;
            }
            else
            {
                db.Story.Story.Update(command);
            }
        }

        /// <summary>
        /// Deletes Story
        /// </summary>
        /// <param name="id">Story Id</param>
        public void Delete(int id)
        {
            var db = Database.Open();
            db.Story.Story.DeleteById(id);
            linkDataService.Remove(new Node(id, StoryboardNodeTypes.Story));
        }

        public IEnumerable<Story> Get(IEnumerable<int> ids)
        {
            var chunkedIds = ids.Chunk(1000);
            var db = Database.Open();
            return chunkedIds.SelectMany(chunk =>
            {
                IEnumerable<Story> chunkResult = db.Story.Story.FindAllById(chunk.ToArray());
                return chunkResult;
            });
        }

        IEnumerable<INode> INodeRepository.Get(IEnumerable<int> ids)
        {
            return Get(ids);
        }

        INode INodeRepository.Get(int id)
        {
            return Get(id);
        }

        public Task<List<Story>> GetAsync(IEnumerable<int> ids)
        {
            return Task.Run(() => Get(ids).ToList());
        }

        public Task<Story> GetAsync(int id)
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
