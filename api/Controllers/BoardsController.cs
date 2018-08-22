using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Model;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/Boards")]
    public class BoardsController : Controller
    {
        private readonly BoardContext _context;
        //private readonly MysqlBoardContext _context;


        public BoardsController(BoardContext context)
        {
            _context = context;
        }

        // GET: api/Boards
        [HttpGet]
        public IEnumerable<Board> GetTodoItems()
        {
            return _context.Board;
        }

        // GET: api/Boards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = await _context.Board.SingleOrDefaultAsync(m => m.board_id == id);
            //var items = await _context.Item.Where(m=>m.board_id == id).ToListAsync();

            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        // PUT: api/Boards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoard([FromRoute] long id, [FromBody] Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != board.board_id)
            {
                return BadRequest();
            }

            _context.Entry(board).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Boards
        [HttpPost]
        public async Task<IActionResult> PostBoard([FromBody] Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Board.Add(board);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBoard", new { id = board.board_id }, board);
        }

        // DELETE: api/Boards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = await _context.Board.SingleOrDefaultAsync(m => m.board_id == id);
            if (board == null)
            {
                return NotFound();
            }

            _context.Board.Remove(board);
            await _context.SaveChangesAsync();

            return Ok(board);
        }

        private bool BoardExists(long id)
        {
            return _context.Board.Any(e => e.board_id == id);
        }
    }
}