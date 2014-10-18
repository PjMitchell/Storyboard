using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Storyboard.Web.Models.Home
{
    public class StoryOverviewSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
    }
}