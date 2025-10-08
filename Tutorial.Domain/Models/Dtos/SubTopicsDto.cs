using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models.Dtos
{
    public class SubTopicsDto
    {
        public int SubTopicId { get; set; }
        public string SubTopicName { get; set; }
        public int SubTopicsOrder { get; set; }
        public int TopicId { get; set; }
    }
}
