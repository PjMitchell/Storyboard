namespace Storyboard.Data.DbObject
{
    public class StorySectionTableRow
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int HierarchyLevel { get; set; }
        public int Order { get; set; }
        public int ParentHierarchyElementId { get; set; }
        public int StoryId { get; set; }
        public StoryTableRow Story { get; set; }
    }
    
}
