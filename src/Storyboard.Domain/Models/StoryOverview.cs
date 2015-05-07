using Storyboard.Domain.Core;
using System.Collections.Generic;

namespace Storyboard.Domain.Models
{
    /// <summary>
    /// A POCO that presents the story overview across the wire
    /// </summary>
    public class StoryOverview
    {
        public List<StorySection> Sections { get; set; }
        public StorySummary Summary { get; set; }
        public List<Actor> Actors { get; set; }

    }
}