using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.EF.DbObject
{
    /// <summary>
    /// Representation of the Link Table row
    /// </summary>
    //[assembly: InternalsVisibleTo("Storyboard.Data.Tests")] Todo find out why this isn't working
    [Table("Link", Schema = DbSchemas.Story)]
    public class LinkTableRow
    {
        [Key]
        public int Id { get; set; }
        public int NodeARef { get; set; }
        public byte NodeAType { get; set; }
        public int NodeBRef { get; set; }
        public byte NodeBType { get; set; }
        public double LinkStrength { get; set; }
        public int LinkTypeRef { get; set; }
        public byte LinkDirection { get; set; }
    }
}
