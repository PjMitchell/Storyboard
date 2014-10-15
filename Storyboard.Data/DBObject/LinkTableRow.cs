using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.DBObject
{
    /// <summary>
    /// Representation of the Link Table row
    /// </summary>
    //[assembly: InternalsVisibleTo("Storyboard.Data.Tests")] Todo find out why this isn't working
    public class LinkTableRow
    {
        public int NodeARef { get; set; }
        public int NodeAType { get; set; }
        public int NodeBRef { get; set; }
        public int NodeBType { get; set; }
        public float LinkStrength { get; set; }
        public int LinkTypeRef { get; set; }
        public int LinkDirection { get; set; }
    }
}
