using System.ComponentModel.DataAnnotations;

namespace Storyboard.Domain.Core.Commands
{
    public class AddUpdateActorCommand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
