using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_SIF.Models;
using api_SIF.dbContexts;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoTicketsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public EstadoTicketsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/EstadoTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoTicket>>> GetEstadoTicket()
        {
            return await _context.EstadoTicket.ToListAsync();
        }

        // GET: api/EstadoTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoTicket>> GetEstadoTicket(int id)
        {
            var estadoTicket = await _context.EstadoTicket.FindAsync(id);

            if (estadoTicket == null)
            {
                return NotFound();
            }

            return estadoTicket;
        }

        // PUT: api/EstadoTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoTicket(int id, EstadoTicket estadoTicket)
        {
            if (id != estadoTicket.id)
            {
                return BadRequest();
            }

            _context.Entry(estadoTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoTicketExists(id))
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

        // POST: api/EstadoTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstadoTicket>> PostEstadoTicket(EstadoTicket estadoTicket)
        {
            _context.EstadoTicket.Add(estadoTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoTicket", new { id = estadoTicket.id }, estadoTicket);
        }

        // DELETE: api/EstadoTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoTicket>> DeleteEstadoTicket(int id)
        {
            var estadoTicket = await _context.EstadoTicket.FindAsync(id);
            if (estadoTicket == null)
            {
                return NotFound();
            }

            _context.EstadoTicket.Remove(estadoTicket);
            await _context.SaveChangesAsync();

            return estadoTicket;
        }

        private bool EstadoTicketExists(int id)
        {
            return _context.EstadoTicket.Any(e => e.id == id);
        }
    }
}
