using MF_ProjetoBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MF_ProjetoBackEnd.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();

            return View(dados);
        }

        public ActionResult Create() //Create GET
        {
            return View();
        }


        [HttpPost] //Create POST
        public async Task<ActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }


        public async Task<IActionResult> Edit(int? id) //Edit GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }


        public async Task<IActionResult> Delete(int? id) //Delete GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id) //Delete POST
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }
            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

 
        public async Task<IActionResult> Details(int? id) //Details POST
        {
            if(id == null)
            {
                return NotFound();
            }

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }
    }
}