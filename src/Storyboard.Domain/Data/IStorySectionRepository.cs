using Storyboard.Domain.Core;
using System.Threading.Tasks;
using HDLink;

namespace Storyboard.Domain.Data
{
    public interface IStorySectionRepository : IAsyncNodeRepository<StorySection>
    {
        Task<OrderedHierarchicalTree<StorySection>> GetTreeForStory(int storyId);
    }
}
