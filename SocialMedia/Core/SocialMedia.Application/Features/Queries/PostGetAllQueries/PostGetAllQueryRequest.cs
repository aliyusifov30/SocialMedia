using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.PostGetAllQueries
{
    public class PostGetAllQueryRequest : IRequest<PostGetAllQueryResponse>
    {
        public string? UserName { get; set; }
    }
}
