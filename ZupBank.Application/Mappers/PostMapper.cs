using System.Collections.Generic;
using ZupBank.Application.Dtos;
using ZupBank.Domain.Entities;

namespace ZupBank.Application.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public static class PostMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDto"></param>
        /// <returns></returns>
        public static Post ToDomain(PostDto postDto)
        {
            if (postDto == null)
                return null;

            return new Post(postDto.Id, postDto.Title);
        }


        public static IEnumerable<Post> ToDomainList(IEnumerable<PostDto> postsDto)
        {
            var posts = new List<Post>();

            foreach (var p in postsDto)
                posts.Add(ToDomain(p));

            return posts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static PostDto ToDto(Post post)
        {
            if (post == null)
                return null;

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public static IEnumerable<PostDto> ToDtoList(IEnumerable<Post> posts)
        {
            var postsDto = new List<PostDto>();

            foreach (var p in posts)
                postsDto.Add(ToDto(p));

            return postsDto;
        }
    }
}
