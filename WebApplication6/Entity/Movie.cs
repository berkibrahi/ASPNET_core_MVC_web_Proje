namespace WebApplication6.Entity
{
	public class Movie
	{
		public int movieId { get; set; }
		//[DisplayName("Başlık")]
		//[Required(ErrorMessage ="başlık alanı eklemelisiniz")]
		//[StringLength(50, MinimumLength = 5, ErrorMessage = "Film başlığı 5-50 karakter arasında olmalıdır")]

		public string title { get; set; }

		//[Required]
		//[DisplayName("Açıklama")]

		public string description { get; set; }
		//[Required]
		//public string director { get; set; }
		

		public string imageUrl { get; set; }
        public List<Genre> Genres { get; set; }


    }
}
