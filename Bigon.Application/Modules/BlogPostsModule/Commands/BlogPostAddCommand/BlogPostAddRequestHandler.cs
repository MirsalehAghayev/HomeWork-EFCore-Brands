﻿using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Abstracts;
using Bigon.Infrastructure.Extensions;
using MediatR;

namespace Bigon.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand
{
    class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPostAddRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostAddRequestHandler(
            IBlogPostRepository blogPostRepository, 
            IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }

        public async Task<BlogPostAddRequestDto> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new BlogPost
            {
                Title = request.Title,
                Slug = request.Title.ToSlug(),
                CategoryId = request.CategoryId,
                Body = request.Body,
            };

            entity.ImagePath = await fileService.UploadAsync(request.Image);

            await blogPostRepository.AddAsync(entity,cancellationToken);
            await blogPostRepository.SaveAsync(cancellationToken);

            var dto = new BlogPostAddRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                Body = entity.Body,
                ImageUrl = entity.ImagePath
            };

            #warning must be complate

            return dto;
        }
    }
}
