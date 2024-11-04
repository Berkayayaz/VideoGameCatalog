using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCatalog.Domain.Models;
using VideoGameCatalog.Entity;

namespace VideoGameCatalog.Server.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class VideoGameController : ControllerBase {
		private readonly VideoGameCatalogDbContext _context;

		public VideoGameController(VideoGameCatalogDbContext context) {
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<VideoGame>>> GetVideoGames() {
			return await _context.VideoGames.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<VideoGame>> GetVideoGame(int id) {
			var videoGame = await _context.VideoGames.FindAsync(id);
			if (videoGame == null) {
				return NotFound();
			}
			return videoGame;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutVideoGame(int id, VideoGame videoGame) {
			if (id != videoGame.Id) {
				return BadRequest();
			}

			_context.Entry(videoGame).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!VideoGameExists(id)) {
					return NotFound();
				}
				throw;
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<VideoGame>> PostVideoGame(VideoGame videoGame) {
			_context.VideoGames.Add(videoGame);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetVideoGame), new { id = videoGame.Id }, videoGame);
		}

		private bool VideoGameExists(int id) {
			return _context.VideoGames.Any(e => e.Id == id);
		}
	}
}
