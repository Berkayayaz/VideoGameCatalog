using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameCatalog.Domain.Models;

namespace VideoGameCatalog.Entity {
	public static class DatabaseSeeder {
		public static void SeedData(VideoGameCatalogDbContext context) {
			// Only seed if the database is empty
			if (context.VideoGames.Any()) {
				return;
			}

			var videoGames = new[]
			{
								new VideoGame
								{
									Title = "The Legend of Zelda: Breath of the Wild",
									Developer = "Nintendo EPD",
									Publisher = "Nintendo",
									ReleaseDate = new DateTime(2017, 3, 3),
									Genre = "Action-Adventure",
									Price = 59.99m,
									Description = "An open-world action-adventure game that breaks new ground while honoring the origins of the acclaimed series.",
									Rating = 4.8f
								},
								new VideoGame
								{
									Title = "Red Dead Redemption 2",
									Developer = "Rockstar Games",
									Publisher = "Rockstar Games",
									ReleaseDate = new DateTime(2018, 10, 26),
									Genre = "Action",
									Price = 49.99m,
									Description = "An epic tale of life in America's unforgiving heartland.",
									Rating = 4.7f
								},
								new VideoGame
								{
									Title = "Fifa 2025",
									Developer = "FromSoftware",
									Publisher = "Bandai Namco",
									ReleaseDate = new DateTime(2022, 2, 25),
									Genre = "Action RPG",
									Price = 59.99m,
									Description = "An action RPG set in a fantasy world crafted by Hidetaka Miyazaki and George R. R. Martin.",
									Rating = 4.9f
								},
								new VideoGame
								{
									Title = "God of War Ragnarök",
									Developer = "Santa Monica Studio",
									Publisher = "Sony Interactive Entertainment",
									ReleaseDate = new DateTime(2022, 11, 9),
									Genre = "Action-Adventure",
									Price = 69.99m,
									Description = "Embark on an epic and heartfelt journey as Kratos and Atreus struggle with holding on and letting go.",
									Rating = 4.9f
								},
								new VideoGame
								{
									Title = "Cyberpunk 2077",
									Developer = "CD Projekt Red",
									Publisher = "CD Projekt",
									ReleaseDate = new DateTime(2020, 12, 10),
									Genre = "Action RPG",
									Price = 39.99m,
									Description = "An open-world RPG set in Night City, a megalopolis obsessed with power, glamour and body modification.",
									Rating = 4.0f
								},
								new VideoGame
								{
									Title = "Baldur's Gate 3",
									Developer = "Larian Studios",
									Publisher = "Larian Studios",
									ReleaseDate = new DateTime(2023, 8, 3),
									Genre = "RPG",
									Price = 59.99m,
									Description = "Gather your party, and return to the Forgotten Realms in a tale of fellowship and betrayal, sacrifice and survival.",
									Rating = 4.9f
								},
								new VideoGame
								{
									Title = "Final Fantasy XVI",
									Developer = "Square Enix",
									Publisher = "Square Enix",
									ReleaseDate = new DateTime(2023, 6, 22),
									Genre = "Action RPG",
									Price = 69.99m,
									Description = "A dark fantasy world where the fate of the land is decided by Dominants, powerful beings who can call upon deadly Eikons.",
									Rating = 4.8f
								},
								new VideoGame
								{
									Title = "Super Mario Bros. Wonder",
									Developer = "Nintendo",
									Publisher = "Nintendo",
									ReleaseDate = new DateTime(2023, 10, 20),
									Genre = "Platformer, Adventure",
									Price = 59.99m,
									Description = "The iconic Mario franchise returns with 'Super Mario Bros. Wonder,' featuring a new adventure with stunning graphics and innovative gameplay. Play solo or with friends as you navigate vibrant worlds filled with secrets, enemies, and thrilling power-ups.",
									Rating = 9.5f
								},
								new VideoGame
								{
									Title = "FIFA 24",
									Developer = "EA Sports",
									Publisher = "EA Sports",
									ReleaseDate = new DateTime(2023, 9, 22),
									Genre = "Sports, Simulation",
									Price = 69.99m,
									Description = "FIFA 24 delivers the most realistic football experience to date with updated rosters, improved gameplay mechanics, and enhanced graphics. Enjoy multiple modes including Career, Ultimate Team, and VOLTA Football, bringing the action of the pitch directly to your console.",
									Rating = 8.7f
								},
								new VideoGame
								{
									Title = "FIFA 25",
									Developer = "EA Sports",
									Publisher = "EA Sports",
									ReleaseDate = new DateTime(2024, 9, 20),
									Genre = "Sports, Simulation",
									Price = 69.99m,
									Description = "FIFA 25 expands on its predecessor with advanced AI, refined animations, and updated player data. New features include customizable stadiums and the addition of classic teams, offering an immersive football experience for both casual and hardcore fans.",
									Rating = 9.0f
								},
								new VideoGame
								{
									Title = "NFL 24",
									Developer = "EA Tiburon",
									Publisher = "EA Sports",
									ReleaseDate = new DateTime(2023, 8, 18),
									Genre = "Sports, Simulation",
									Price = 69.99m,
									Description = "NFL 24 brings the gridiron to life with realistic animations, updated rosters, and a reworked Franchise mode. Enhanced visuals and the new Superstar KO mode make this edition a must-have for American football enthusiasts.",
									Rating = 8.2f
								},
								new VideoGame
								{
									Title = "NFL 25",
									Developer = "EA Tiburon",
									Publisher = "EA Sports",
									ReleaseDate = new DateTime(2024, 8, 20),
									Genre = "Sports, Simulation",
									Price = 69.99m,
									Description = "NFL 25 builds on the foundation of previous games, introducing improved mechanics, detailed player stats, and the all-new Coaches Challenge mode. Step up your gameplay with realistic features and new commentary for a fresh NFL experience.",
									Rating = 8.5f
								},
								new VideoGame
								{
									Title = "NBA 2K24",
									Developer = "Visual Concepts",
									Publisher = "2K Sports",
									ReleaseDate = new DateTime(2023, 9, 8),
									Genre = "Sports, Simulation",
									Price = 69.99m,
									Description = "NBA 2K24 delivers unparalleled basketball simulation with hyper-realistic graphics, in-depth MyCareer storylines, and competitive online modes. New gameplay adjustments offer a smoother, more responsive experience both on and off the court.",
									Rating = 8.9f
								},
								new VideoGame
								{
									Title = "Forza Motorsport",
									Developer = "Turn 10 Studios",
									Publisher = "Xbox Game Studios",
									ReleaseDate = new DateTime(2023, 10, 10),
									Genre = "Racing, Simulation",
									Price = 69.99m,
									Description = "Forza Motorsport offers an immersive racing experience with lifelike car models, dynamic weather, and a diverse array of tracks from around the world. The game’s revamped Career Mode and stunning visuals set a new standard for the racing genre.",
									Rating = 9.0f
								}
							};

			context.VideoGames.AddRange(videoGames);
			context.SaveChanges();
		}
	}
}