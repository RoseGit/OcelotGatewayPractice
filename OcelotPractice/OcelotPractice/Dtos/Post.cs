namespace OcelotPractice.Dtos
{
    /// <summary>
    /// Model for Post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// The User ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// The Post Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Post Title 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The Post body
        /// </summary>
        public string Body { get; set; }
    }
}
