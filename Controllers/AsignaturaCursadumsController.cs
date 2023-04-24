using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_1_HP.Models;

namespace Prueba_1_HP.Controllers
{
    public class AsignaturaCursadumsController : Controller
    {
        private readonly Prueba1HpContext _context;

        public AsignaturaCursadumsController(Prueba1HpContext context)
        {
            _context = context;
        }

        // GET: AsignaturaCursadums
        public async Task<IActionResult> Index()
        {
            var prueba1HpContext = _context.AsignaturaCursada.Include(a => a.AsignaturasCodigoAsignaturaNavigation).Include(a => a.EstudiantesRutEstudianteNavigation);
            return View(await prueba1HpContext.ToListAsync());
        }

        // GET: AsignaturaCursadums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AsignaturaCursada == null)
            {
                return NotFound();
            }

            var asignaturaCursadum = await _context.AsignaturaCursada
                .Include(a => a.AsignaturasCodigoAsignaturaNavigation)
                .Include(a => a.EstudiantesRutEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignaturaCursada == id);
            if (asignaturaCursadum == null)
            {
                return NotFound();
            }

            return View(asignaturaCursadum);
        }

        // GET: AsignaturaCursadums/Create
        public IActionResult Create()
        {
            ViewData["AsignaturasCodigoAsignatura"] = new SelectList(_context.Asignaturas, "CodigoAsignatura", "CodigoAsignatura");
            ViewData["EstudiantesRutEstudiante"] = new SelectList(_context.Estudiantes, "RutEstudiante", "RutEstudiante");
            return View();
        }

        // POST: AsignaturaCursadums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignaturaCursada,EstudiantesRutEstudiante,AsignaturasCodigoAsignatura")] AsignaturaCursadum asignaturaCursadum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaCursadum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturasCodigoAsignatura"] = new SelectList(_context.Asignaturas, "CodigoAsignatura", "CodigoAsignatura", asignaturaCursadum.AsignaturasCodigoAsignatura);
            ViewData["EstudiantesRutEstudiante"] = new SelectList(_context.Estudiantes, "RutEstudiante", "RutEstudiante", asignaturaCursadum.EstudiantesRutEstudiante);
            return View(asignaturaCursadum);
        }

        // GET: AsignaturaCursadums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AsignaturaCursada == null)
            {
                return NotFound();
            }

            var asignaturaCursadum = await _context.AsignaturaCursada.FindAsync(id);
            if (asignaturaCursadum == null)
            {
                return NotFound();
            }
            ViewData["AsignaturasCodigoAsignatura"] = new SelectList(_context.Asignaturas, "CodigoAsignatura", "CodigoAsignatura", asignaturaCursadum.AsignaturasCodigoAsignatura);
            ViewData["EstudiantesRutEstudiante"] = new SelectList(_context.Estudiantes, "RutEstudiante", "RutEstudiante", asignaturaCursadum.EstudiantesRutEstudiante);
            return View(asignaturaCursadum);
        }

        // POST: AsignaturaCursadums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignaturaCursada,EstudiantesRutEstudiante,AsignaturasCodigoAsignatura")] AsignaturaCursadum asignaturaCursadum)
        {
            if (id != asignaturaCursadum.IdAsignaturaCursada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaCursadum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaCursadumExists(asignaturaCursadum.IdAsignaturaCursada))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturasCodigoAsignatura"] = new SelectList(_context.Asignaturas, "CodigoAsignatura", "CodigoAsignatura", asignaturaCursadum.AsignaturasCodigoAsignatura);
            ViewData["EstudiantesRutEstudiante"] = new SelectList(_context.Estudiantes, "RutEstudiante", "RutEstudiante", asignaturaCursadum.EstudiantesRutEstudiante);
            return View(asignaturaCursadum);
        }

        // GET: AsignaturaCursadums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AsignaturaCursada == null)
            {
                return NotFound();
            }

            var asignaturaCursadum = await _context.AsignaturaCursada
                .Include(a => a.AsignaturasCodigoAsignaturaNavigation)
                .Include(a => a.EstudiantesRutEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignaturaCursada == id);
            if (asignaturaCursadum == null)
            {
                return NotFound();
            }

            return View(asignaturaCursadum);
        }

        // POST: AsignaturaCursadums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AsignaturaCursada == null)
            {
                return Problem("Entity set 'Prueba1HpContext.AsignaturaCursada'  is null.");
            }
            var asignaturaCursadum = await _context.AsignaturaCursada.FindAsync(id);
            if (asignaturaCursadum != null)
            {
                _context.AsignaturaCursada.Remove(asignaturaCursadum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaCursadumExists(int id)
        {
          return (_context.AsignaturaCursada?.Any(e => e.IdAsignaturaCursada == id)).GetValueOrDefault();
        }
    }
}
