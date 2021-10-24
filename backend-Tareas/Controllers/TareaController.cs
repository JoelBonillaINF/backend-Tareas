using backend_Tareas.Context;
using backend_Tareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TareaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTareas = await _context.Tareas.ToListAsync();
                return Ok(listTareas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Tarea tarea)
        {
            try
            {
                 _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();
                return Ok("Registro Exitoso");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            try
            {
                if (id !=tarea.id)
                {
                    return NotFound();
                }
                tarea.estado = !tarea.estado;

                _context.Entry(tarea).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Actualizacion Completada");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea==null)
                {
                    return NotFound();
                }
                
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
                return Ok("Registro Eliminado ");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
