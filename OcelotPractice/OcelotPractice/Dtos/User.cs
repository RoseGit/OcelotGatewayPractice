namespace OcelotPractice.Dtos
{
    /// <summary>
    /// Model for User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
            this.Posts = new List<Post>();
        }
        /// <summary>
        /// The User Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The user username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The user email 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The user phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// the user website
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// <see cref="Post"/>
        /// </summary>
        public List<Post> Posts { get; set; }
    }
}
