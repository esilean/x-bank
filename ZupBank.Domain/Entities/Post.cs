using System;

namespace ZupBank.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Post
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public Post(int id, string title)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
    }
}
