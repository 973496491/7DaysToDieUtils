using System.Collections.Generic;

namespace _7DaysToDieUtils.Entity
{
    public class MenuInfoEntity
    {
        public List<ItemTabEntity> List { get; set; }
    }

    public class ItemTabEntity
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public List<ItemNode> ItemNode { get; set; }
    }

    public class ItemNode
    {
        public int ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ImageKey { get; set; }
        public string Content { get; set; }
    }
}
