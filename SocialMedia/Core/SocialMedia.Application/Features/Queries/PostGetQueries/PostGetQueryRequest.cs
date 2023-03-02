using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.PostGetQueries
{
    public class PostGetQueryRequest : IRequest<PostGetQueryResponse>
    {
        public string? UserName { get; set; }
        public int Id { get; set; }
    }
}
