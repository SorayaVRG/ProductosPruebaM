using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosPruebaM.Data;
using ProductosPruebaM.Modelos;

namespace ProductosPruebaM.Controllers
{
    public class CategoriasController : Controller
    {
        //conexion a la base de datos
        private readonly DataContext _context;

        public CategoriasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        //Index
        public async Task<IActionResult> Index(int id)
        {
            var categorias = await _context.Categorias.Where(t => t.IdZona.Equals(id)).ToListAsync();
            var modelZonas = await _context.Zonas.FindAsync(id);
            ViewBag.Zonas = modelZonas;
            return View(categorias);
        }

        //Create
        public IActionResult Create(int idZonas)
        {
            var categorias = new Categorias { IdZona = idZonas };
            return PartialView(categorias);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categorias model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = model.IdZona });
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var categorias = await _context.Categorias.FindAsync(id);
            return PartialView(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categorias model)
        {
            var modelOld = await _context.Categorias.FindAsync(model.Id);
            modelOld.NombreCategoria = model.NombreCategoria;
            _context.Update(modelOld);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = model.IdZona });
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var idZonas = 0;
            var categorias = await _context.Categorias.FindAsync(id);
            if (categorias != null)
            {
                idZonas = categorias.IdZona;
                _context.Remove(categorias);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = idZonas });
        }
    }
}