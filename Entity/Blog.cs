using System;

namespace MM.Domain.Entity
{
    public class Blog
    {
        public string ID { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }

        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
    }
}
