using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.EF.DbObject
{
    [Table("StorySection", Schema = DbSchemas.Story)]
    public class StorySectionTableRow
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int HierarchyLevel { get; set; }
        public int Order { get; set; }
        public int ParentHierarchyElementId { get; set; }
        public int StoryId { get; set; }
        public StoryTableRow Story { get; set; }
    }
    
}
