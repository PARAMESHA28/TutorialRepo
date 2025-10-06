using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public string ResourceUrl { get; set; }
    }
}
