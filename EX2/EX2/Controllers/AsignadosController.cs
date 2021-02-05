using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EX2.Models;

namespace EX2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignadosController : ControllerBase
    {
        private readonly APIContext _context;

        public AsignadosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Asignados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignado>>> GetAsignado()
        {
            return await _context.Asignado.ToListAsync();
        }

        // GET: api/Asignados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignado>> GetAsignado(string id)
        {
            var asignado = await _context.Asignado.FindAsync(id);

            if (asignado == null)
            {
                return NotFound();
            }

            return asignado;
        }

        // PUT: api/Asignados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignado(string id, Asignado asignado)
        {
            if (id != asignado.DNICientifico)
            {
                return BadRequest();
            }

            _context.Entry(asignado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignadoExists(id))
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

        // POST: api/Asignados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Asignado>> PostAsignado(Asignado asignado)
        {
            _context.Asignado.Add(asignado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsignadoExists(asignado.DNICientifico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignado", new { id = asignado.DNICientifico }, asignado);
        }

        // DELETE: api/Asignados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asignado>> DeleteAsignado(string id)
        {
            var asignado = await _context.Asignado.FindAsync(id);
            if (asignado == null)
            {
                return NotFound();
            }

            _context.Asignado.Remove(asignado);
            await _context.SaveChangesAsync();

            return asignado;
        }

        private bool AsignadoExists(string id)
        {
            return _context.Asignado.Any(e => e.DNICientifico == id);
        }
    }
}
