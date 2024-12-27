namespace SecuringWebApi.Data.Entities
{
    public class Post : BaseEntity
    {
        public required string Title { get; set; }
        public required string Context { get; set; }
    }
}
