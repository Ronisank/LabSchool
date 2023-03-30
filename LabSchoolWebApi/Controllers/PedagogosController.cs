using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchoolWebApi.Context;
using LabSchoolWebApi.Models;
using AutoMapper;
using LabSchoolWebApi.DTOs;

namespace LabSchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedagogosController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public PedagogosController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pedagogos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedagogo>>> GetPedagogos()
        {
            var pedagogo = await _context.Pedagogos.ToListAsync();

          if (_context.Pedagogos == null)
          {
              return NotFound();
          }
            List<PedagogoRespostaDTO> pedagogoDto = _mapper.Map<List<PedagogoRespostaDTO>>(pedagogo);
            return Ok(pedagogoDto);
           
        }

        // GET: api/Pedagogos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedagogo>> GetPedagogo(int id)
        {
          if (_context.Pedagogos == null)
          {
              return NotFound();
          }
            var pedagogo = await _context.Pedagogos.FindAsync(id);

            if (pedagogo == null)
            {
                return NotFound();
            }

            return pedagogo;
        }

        // PUT: api/Pedagogos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedagogo(int id, Pedagogo pedagogo)
        {
            if (id != pedagogo.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(pedagogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedagogoExists(id))
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

        // POST: api/Pedagogos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedagogo>> PostPedagogo(Pedagogo pedagogo)
        {
          if (_context.Pedagogos == null)
          {
              return Problem("Entity set 'LabSchoolContext.Pedagogos'  is null.");
          }
            _context.Pedagogos.Add(pedagogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedagogo", new { id = pedagogo.Codigo }, pedagogo);
        }

        // DELETE: api/Pedagogos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedagogo(int id)
        {
            if (_context.Pedagogos == null)
            {
                return NotFound();
            }
            var pedagogo = await _context.Pedagogos.FindAsync(id);
            if (pedagogo == null)
            {
                return NotFound();
            }

            _context.Pedagogos.Remove(pedagogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedagogoExists(int id)
        {
            return (_context.Pedagogos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
