using AutoMapper;
using MediatR;
using SocialMedia.Application.Repositories.PostRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.PostGetQueries
{
    public class PostGetQueryHandler : IRequestHandler<PostGetQueryRequest, PostGetQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostGetQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostGetQueryResponse> Handle(PostGetQueryRequest request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetAsync(x => x.Id == request.Id && x.IsDeleted == false);
            return _mapper.Map<PostGetQueryResponse>(post);
        }
    }
}
