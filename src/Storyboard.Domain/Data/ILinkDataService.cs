using HDLink;
using System.Threading.Tasks;

namespace Storyboard.Domain.Data
{
    /// <summary>
    /// Responsible for altering the ILinkDataStore
    /// </summary>
    public interface ILinkDataService
    {
        /// <summary>
        /// Adds new link to store
        /// </summary>
        Task Add(ILink link);

        /// <summary>
        /// Removes link from store
        /// </summary>
        Task Remove(ILink link);

        /// <summary>
        /// Removes links from store that contain node
        /// </summary>
        Task Remove(INode node);
    }
}
