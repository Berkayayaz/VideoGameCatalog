using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameCatalog.Domain.Models;
using VideoGameCatalog.Entity;
using VideoGameCatalog.Server.Controllers;
using Xunit;

namespace VideoGameCatalog.Tests {
	public class VideoGamesControllerTests {
		private VideoGameCatalogDbContext GetTestContext() {
			var options = new DbContextOptionsBuilder<VideoGameCatalogDbContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			var context = new VideoGameCatalogDbContext(options);
			context.VideoGames.Add(new VideoGame {
				Id = 1,
				Title = "Test Game",
				Publisher = "Test Publisher",
				Price = 59.99m
			});
			context.SaveChanges();
			return context;
		}

		[Fact]
		public async Task GetGames_ReturnsAllGames() {
			var context = GetTestContext();
			var controller = new VideoGameController(context);

			var result = await controller.GetVideoGames();

			var games = Assert.IsAssignableFrom<IEnumerable<VideoGame>>(result.Value);
			Assert.Single(games);
		}

		[Fact]
		public async Task GetGame_ReturnsGameWhenExists() {
			var context = GetTestContext();
			var controller = new VideoGameController(context);

			var result = await controller.GetVideoGame(1);

			var game = Assert.IsType<VideoGame>(result.Value);
			Assert.Equal("Test Game", game.Title);
		}
	}
}
