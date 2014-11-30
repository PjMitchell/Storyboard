using HDLink;

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
        void Add(ILink link);

        /// <summary>
        /// Removes link from store
        /// </summary>
        void Remove(ILink link);
    }
}
