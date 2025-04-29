using Microsoft.AspNetCore.Mvc; // Provides features for building HTTP services
using Microsoft.EntityFrameworkCore; // Provides EF Core functionality for database operations
using TodoApi; // Access to TodoApi's context and models
using TodoApi.Models; // Access to the 'Item' model

namespace TodoApi.Controllers // Groups controller-related functionality
{
    [Route("api/[controller]")] // Defines the route pattern for this controller
    [ApiController] // Specifies that this is an API controller and provides default behaviors
    public class DummyDataController : ControllerBase // Inherits from ControllerBase to manage HTTP requests
    {
        private readonly DummyDataContext _context; // Defines a private readonly field for database context

        // Constructor to inject the database context into the controller
        public DummyDataController(DummyDataContext context)
        {
            _context = context;
        }

        // GET: api/DummyData - Retrieves all items from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            // Asynchronously fetches all items from the database and returns them
            return await _context.Items.ToListAsync();
        }

        // GET: api/DummyData/5 - Retrieves a specific item by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            // Attempts to find the item by ID; returns 'NotFound' if not found
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item; // Returns the found item
        }

        // POST: api/DummyData - Adds a new item to the database
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item); // Adds the new item to the database context
            await _context.SaveChangesAsync(); // Saves changes to the database

            // Returns the created item along with the URL to get the item
            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // PUT: api/DummyData/5 - Updates an existing item in the database
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            // Checks if the ID in the URL matches the ID in the item object
            if (id != item.Id)
            {
                return BadRequest(); // Returns a bad request if IDs don't match
            }

            _context.Entry(item).State = EntityState.Modified; // Marks the item as modified
            await _context.SaveChangesAsync(); // Saves the updated item to the database

            return NoContent(); // Indicates that the update was successful but there is no content to return
        }

        // DELETE: api/DummyData/5 - Deletes a specific item by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id); // Attempts to find the item by ID
            if (item == null)
            {
                return NotFound(); // Returns 'NotFound' if the item doesn't exist
            }

            _context.Items.Remove(item); // Removes the item from the context
            await _context.SaveChangesAsync(); // Saves changes to the database

            return NoContent(); // Indicates that the deletion was successful but no content to return
        }
    }
}
