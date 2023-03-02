using SocialMedia.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class PostLike
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string FromUserId { get; set; }
        public AppUser FromUser { get; set; }
    }
}
