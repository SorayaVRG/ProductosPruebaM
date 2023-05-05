using Microsoft.AspNetCore.Mvc;
using ProductosPruebaM.Data;
using ProductosPruebaM.Modelos;

namespace ProductosPruebaM.Controllers
{
    public class ProveedoresController : Controller
    {
        //conexion a la base de datos
        private readonly DataContext _context;
        public ProveedoresController(DataContext dataContext)
        {
            _context = dataContext;
        }

        //INDEX PROVEEDORES GET : /<Controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var proveedores = _context.Proveedores.ToList();
            return View(proveedores);
        }

        //Create PROVEEDORES
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Proveedores model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var proveedores = await _context.Proveedores.FindAsync(id);
            return PartialView(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Proveedores model)
        {
            var modelOld = await _context.Proveedores.FindAsync(model.Id); //select * from Proveedores where PK = id
            modelOld.NombreProveedor = model.NombreProveedor;
            modelOld.Ruc = model.Ruc;
            modelOld.Telefono = model.Telefono;
            modelOld.Direccion = model.Direccion;
            _context.Update(modelOld); //update Proveedores set NombreProveedores = model.NombreProveedores
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Delete PROVEEDORES method GETT
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var proveedores = await _context.Proveedores.FindAsync(id);
        //    _context.Remove(proveedores);//Delete proveedores
        //    await _context.SaveChangesAsync();//commit a la base de datos
        //    return RedirectToAction(nameof(Index));
        //}

        //Activar y anular proveedor
        // Activar PROVEEDORES method GET
        public async Task<IActionResult> Activar(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            proveedor.Estado = true; // Establecer el estado como activado
            _context.Update(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Anular PROVEEDORES method GET
        public async Task<IActionResult> Anular(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            proveedor.Estado = false; // Establecer el estado como anulado
            _context.Update(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}