using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Creates or Updates Actor
        /// </summary>
        /// <param name="command">Actor to be created / updated</param>
        void AddOrUpdate(AddUpdateActorCommand command);

        /// <summary>
        /// Deletes Actor
        /// </summary>
        /// <param name="id">Actor Id</param>
        void Delete(int id);
    }
}
