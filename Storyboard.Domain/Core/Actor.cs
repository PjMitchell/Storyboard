using Storyboard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Core
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AddUpdateActorCommand ToAddUpdateCommand()
        {
            return new AddUpdateActorCommand
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
