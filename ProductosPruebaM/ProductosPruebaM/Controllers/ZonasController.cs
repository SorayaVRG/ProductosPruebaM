using Microsoft.AspNetCore.Mvc;
using ProductosPruebaM.Data;
using ProductosPruebaM.Modelos;

namespace ProductosPruebaM.Controllers
{
    public class ZonasController : Controller
    {
        //conexion a la base de datos
        private readonly DataContext _context;

        public ZonasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        //INDEX ZONAS GET : /<Controller>/
        public IActionResult Index()
        {
            var zonas = _context.Zonas.ToList();
            return View(zonas);
        }

        //Create ZONAS
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Zonas model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // edit
        public async Task<IActionResult> Edit(int id)
        {
            var zonas = await _context.Zonas.FindAsync(id); //select * from Zonas where PK = id
            return PartialView(zonas);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Zonas model)
        {
            var modelOld = await _context.Zonas.FindAsync(model.Id);//select * from Zonas where PK = id
            modelOld.NombreZona = model.NombreZona;
            _context.Update(modelOld);//update Zonas set NombreZonas = model.NombreZonas
            await _context.SaveChangesAsync(); //commit a la base de datos
            return RedirectToAction(nameof(Index));
        }

        ////Delete ZONAS method GETT
        public async Task<IActionResult> Delete(int id)
        {
            var zonas = await _context.Zonas.FindAsync(id);
            _context.Remove(zonas);//Delete zonas
            await _context.SaveChangesAsync();//commit a la base de datos
            return RedirectToAction(nameof(Index));
        }
    }
}
