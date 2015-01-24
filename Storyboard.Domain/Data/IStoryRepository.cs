using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Data
{
    public interface IStoryRepository : IAsyncNodeRepository<Story>
    {
        /// <summary>
        /// Gets all Stories from Database
        /// </summary>
        /// <returns>All Stories</returns>
        Task<List<Story>> GetAsync();

        /// <summary>
        /// Creates or Updates Story
        /// </summary>
        /// <param name="command">Story to be created / updated</param>
        void AddOrUpdate(AddUpdateStoryCommand command);

        /// <summary>
        /// Deletes Story
        /// </summary>
        /// <param name="id">Story Id</param>
        void Delete(int id);
    }
}
