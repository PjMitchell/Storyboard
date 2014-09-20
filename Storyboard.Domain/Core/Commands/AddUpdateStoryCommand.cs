using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Core.Commands
{
    /// <summary>
    /// Command for the creation of a new story
    /// </summary>
    public class AddUpdateStoryCommand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(4000)]
        public string Synopsis { get; set; }
    }
}
