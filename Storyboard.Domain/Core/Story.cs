using Storyboard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Core
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }


        public AddUpdateStoryCommand ToAddUpdateCommand()
        {
            return new AddUpdateStoryCommand
            {
                Id = this.Id,
                Title = this.Title,
                Synopsis = this.Synopsis
            };
        }
    }
}
