using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models.Dtos
{
    public class TopicDto
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int CourseId { get; set; }
    }
}
