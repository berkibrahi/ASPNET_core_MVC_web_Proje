namespace WebApplication6.Entity
{
	public class Genre
	{
		public int genreId { get; set; }
		public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
