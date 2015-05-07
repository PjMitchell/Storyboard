using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storyboard.Domain.Data
{
    public interface IActorRepository: HDLink.IAsyncNodeRepository<Actor>
    {
        /// <summary>
        /// Get Actors
        /// </summary>
        /// <returns>All Actors</returns>
        Task<List<Actor>> GetAsync();
        
        /// <summary>
        /// Creates Actor
        /// </summary>
        /// <param name="command">Actor to be created</param>
        Task<int> Add(AddUpdateActorCommand command);

        /// <summary>
        /// Updates Actor
        /// </summary>
        /// <param name="command">Actor to be updated</param>
        Task Update(AddUpdateActorCommand command);

        /// <summary>
        /// Deletes Actor
        /// </summary>
        /// <param name="id">Actor Id</param>
        Task Delete(int id);
    }
}
