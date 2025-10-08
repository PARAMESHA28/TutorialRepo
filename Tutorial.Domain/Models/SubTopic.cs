using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
    public class SubTopic
    {
        public int SubTopicId { get; set; }
        public string SubTopicName { get; set; }
        public int SubTopicsOrder { get; set; }
        public int TopicId { get; set; } 
        public Topic Topic { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
