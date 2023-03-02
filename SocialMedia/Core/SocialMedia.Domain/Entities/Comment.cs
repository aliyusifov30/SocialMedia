using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Comment 
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; }


        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
