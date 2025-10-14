using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
    public class Topic
    {
        
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course? Course { get; set; }
        public int TopicsOrder { get; set; }
        [JsonIgnore]
        public ICollection<SubTopic?> SubTopics { get; set; }
       

    }
}
