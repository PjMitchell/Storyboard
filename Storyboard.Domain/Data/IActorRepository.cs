using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Data
{
    public interface IActorRepository
    {
        /// <summary>
        /// Gets all Actors from Database
        /// </summary>
        /// <returns>All Actors</returns>
        IEnumerable<Actor> Get();

        /// <summary>
        /// Gets requested Actor
        /// </summary>
        /// <param name="id">Actor Id</param>
        /// <returns>Requested Actor</returns>
        Actor Get(int id);

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
