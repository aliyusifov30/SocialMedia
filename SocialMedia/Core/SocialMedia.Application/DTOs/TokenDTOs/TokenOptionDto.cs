using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.DTOs.TokenDTOs
{
    public class TokenOptionDto
    {

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }

    }
}
