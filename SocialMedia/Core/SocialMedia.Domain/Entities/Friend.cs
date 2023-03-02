using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Friend 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }


        public string FromUserId { get; set; }
        public AppUser FromUser { get; set; }

        public string ToUserId { get; set; }
        public AppUser ToUser { get; set; }


        public bool IsFriend { get; set; }
    }
}
