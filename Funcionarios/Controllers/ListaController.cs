using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Funcionarios.Models;

namespace Funcionarios.Controllers
{
    public class ListaController : Controller
    {
        private readonly Bancodedados _context;

        public ListaController(Bancodedados context)
        {
            _context = context;
        }

        // GET: Lista
        public async Task<IActionResult> Index()
        {
            return View(await _context.Listas.ToListAsync());
        }

        // GET: Lista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Listas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // GET: Lista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Cidade,Endereco,Email")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lista);
        }

        // GET: Lista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Listas.FindAsync(id);
            if (lista == null)
            {
                return NotFound();
            }
            return View(lista);
        }

        // POST: Lista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Cidade,Endereco,Email")] Lista lista)
        {
            if (id != lista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaExists(lista.Id))
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
            return View(lista);
        }

        // GET: Lista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Listas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // POST: Lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lista = await _context.Listas.FindAsync(id);
            _context.Listas.Remove(lista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaExists(int id)
        {
            return _context.Listas.Any(e => e.Id == id);
        }
    }
}
