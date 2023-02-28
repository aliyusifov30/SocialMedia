using SocialMedia.Application.DTOs.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.PostGetAllQueries
{
    public class PostGetAllQueryResponse
    {
        public ICollection<PostGetDto> PostGetDtos { get; set; }
    }
}
