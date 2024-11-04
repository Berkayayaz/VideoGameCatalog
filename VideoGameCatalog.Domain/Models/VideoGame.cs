namespace VideoGameCatalog.Domain.Models {
	public class VideoGame {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Developer { get; set; }
		public string Publisher { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public float Rating { get; set; }

	}
}
