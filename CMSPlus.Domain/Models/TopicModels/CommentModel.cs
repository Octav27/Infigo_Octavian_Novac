using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Models.TopicModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Comentariu { get; set; }

        public int IdTopic { get; set; }
        public TopicDetailsModel Topic { get; set; }

    }
}
