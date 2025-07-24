using LogiTrack.Data;
using LogiTrack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LogiTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly LogiTrackContext _context;
        private readonly IMemoryCache _cache;

        public InventoryController(LogiTrackContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
        {
            if (!_cache.TryGetValue("InventoryData", out List<InventoryItem> inventory))
            {
                inventory = await _context.InventoryItems.AsNoTracking().ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set("InventoryData", inventory, cacheOptions);
            }

            return inventory;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<InventoryItem>> AddItem(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            _cache.Remove("InventoryData"); // Invalidate cache after insert

            return CreatedAtAction(nameof(GetInventory), new { id = item.Id }, item);
        }
    }
}
