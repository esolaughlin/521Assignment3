﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _521Assignment3.Data;
using _521Assignment3.Models;

namespace _521Assignment3.Controllers
{
    public class ActorMovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorMovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActorMovie
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ActorMovie.Include(a => a.Actor).Include(a => a.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ActorMovie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActorMovie == null)
            {
                return NotFound();
            }

            var actorMovie = await _context.ActorMovie
                .Include(a => a.Actor)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorMovie == null)
            {
                return NotFound();
            }

            return View(actorMovie);
        }

        // GET: ActorMovie/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Gender");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Genre");
            return View();
        }

        // POST: ActorMovie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActorId,MovieId")] ActorMovie actorMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Gender", actorMovie.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Genre", actorMovie.MovieId);
            return View(actorMovie);
        }

        // GET: ActorMovie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActorMovie == null)
            {
                return NotFound();
            }

            var actorMovie = await _context.ActorMovie.FindAsync(id);
            if (actorMovie == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Gender", actorMovie.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Genre", actorMovie.MovieId);
            return View(actorMovie);
        }

        // POST: ActorMovie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActorId,MovieId")] ActorMovie actorMovie)
        {
            if (id != actorMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorMovieExists(actorMovie.Id))
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
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Gender", actorMovie.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Genre", actorMovie.MovieId);
            return View(actorMovie);
        }

        // GET: ActorMovie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActorMovie == null)
            {
                return NotFound();
            }

            var actorMovie = await _context.ActorMovie
                .Include(a => a.Actor)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorMovie == null)
            {
                return NotFound();
            }

            return View(actorMovie);
        }

        // POST: ActorMovie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActorMovie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ActorMovie'  is null.");
            }
            var actorMovie = await _context.ActorMovie.FindAsync(id);
            if (actorMovie != null)
            {
                _context.ActorMovie.Remove(actorMovie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorMovieExists(int id)
        {
          return _context.ActorMovie.Any(e => e.Id == id);
        }
    }
}
