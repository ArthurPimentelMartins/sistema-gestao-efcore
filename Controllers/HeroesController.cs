using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabEFCore.Models;
using TrabEFCore.Models.Data;

namespace TrabEFCore.Controllers
{
    public class HeroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Heroes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Heroes.Include(h => h.Party);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Heroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes
                .Include(h => h.Party)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        // GET: Heroes/Create
        public IActionResult Create()
        {
            ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Name");
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Level,Health,Attack,Defense,PartyId")] Hero hero)
        {
            // 1. INÍCIO DA REGRA DE NEGÓCIO: Validação do limite do grupo
            if (hero.PartyId.HasValue) // Verifica se o usuário selecionou alguma Party
            {
                // Busca a Party no banco de dados para saber qual é o MaxMembers dela
                var party = await _context.Parties.FindAsync(hero.PartyId);

                if (party != null)
                {
                    // Conta quantos heróis já existem cadastrados com esse PartyId
                    var currentMembers = await _context.Heroes.CountAsync(h => h.PartyId == hero.PartyId);

                    // Se já bateu o limite, bloqueamos a ação!
                    if (currentMembers >= party.MaxMembers)
                    {
                        // Injeta um erro personalizado amarrado ao campo "PartyId"
                        ModelState.AddModelError("PartyId", $"O grupo '{party.Name}' já está cheio (Máx: {party.MaxMembers} membros).");
                    }
                }
            }
            // FIM DA REGRA DE NEGÓCIO

            // 2. Se não houver nenhum erro (nem de digitação, nem o nosso erro do grupo acima)...
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se caiu aqui, é porque deu erro. Recarrega a tela com os dados preenchidos e a mensagem vermelha.
            ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Name", hero.PartyId);
            return View(hero);
        }

        // GET: Heroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Name", hero.PartyId);
            return View(hero);
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Level,Health,Attack,Defense,PartyId")] Hero hero)
        {
            if (id != hero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroExists(hero.Id))
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
            ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Name", hero.PartyId);
            return View(hero);
        }

        // GET: Heroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes
                .Include(h => h.Party)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero != null)
            {
                _context.Heroes.Remove(hero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}
