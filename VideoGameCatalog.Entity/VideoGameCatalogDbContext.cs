using Microsoft.EntityFrameworkCore;
using VideoGameCatalog.Domain.Models;

namespace VideoGameCatalog.Entity {
	public class VideoGameCatalogDbContext : DbContext {

		public VideoGameCatalogDbContext(DbContextOptions<VideoGameCatalogDbContext> options)
		  : base(options) {
			Database.EnsureCreated();
		}
		public DbSet<VideoGame> VideoGames { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<VideoGame>()
				.Property(g => g.Title)
				.IsRequired()
				.HasMaxLength(200);

			modelBuilder.Entity<VideoGame>()
				.Property(g => g.Price)
				.HasColumnType("decimal(18,2)");
		}
	}
}
