using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductosPruebaM.Data;
using ProductosPruebaM.Modelos;

namespace ProductosPruebaM.Controllers
{
    public class ComprasController : Controller
    {
        //conexion a la base de datos
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ComprasController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        //BUSCAR TRABAJADOR
        public async Task<IActionResult> BuscarTrabajador(string busqueda)
        {
            var trabajadores = await _context.Trabajadores.Where(t => t.Nombres.Contains(busqueda)).ToListAsync();
            return PartialView(trabajadores);
        }

        //VISUALIZACION INDEX
        [HttpGet]
        public IActionResult Index()
        {
            var compras = _context.PR_COMPRAS_S01.FromSqlRaw("exec PR_COMPRAS_S01");
            return View(compras);
        }

        //CREATE ACTUALIZADO

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var Zonas = await _context.Zonas.ToListAsync();
            ViewData["IdZona"] = new SelectList(Zonas, "Id", "NombreZona");
            // ViewBag.IdZona = new SelectList(Zonas, "NombreZona"); tambien se puede con este

            var Categorias = await _context.Categorias.ToListAsync();
            ViewData["IdCategoria"] = new SelectList(Categorias, "id", "NombreCategoria");
            // ViewBag.IdCategoria = new SelectList(Categorias, "NombreCategoria");

            var compras = new Compras { FechaVencimiento = DateTime.Now.Date };
            return PartialView(compras);
        }

        //CARGAR CATEGORIAS -----> REALIZA UNA LISTA DE TODAS LAS CATEGORIAS CREADAS
        [HttpGet]

        public async Task<JsonResult> CargarCategorias(int id)
        {
            var listado = await _context.Categorias.Where(t => t.IdZona.Equals(id)).ToListAsync();
            return Json(listado);
        }

        //CARGAR PRODUCTOS -----> REALIZA UNA LISTA DE TODAS LOS PRODUCTOS CREADAS
        [HttpGet]
        public async Task<JsonResult> CargarProductos(int id)
        {
            var listado = await _context.Productos.Where(t => t.IdCategoria.Equals(id)).ToListAsync();
            return Json(listado);
        }

        //CREAR NUEVO REGISTRO
        [HttpPost]
        public async Task<IActionResult> Create(Compras model)
        {
            //PARA BOLETA
            var prueba = model.BoletaIFormFile;

            if(model.BoletaIFormFile != null)
            {
                model.Boleta = await CargarDocumento(model.BoletaIFormFile, "Boleta");
            }

            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //CARGAR BOLETA
        private async Task<String> CargarDocumento(IFormFile BoletaIFormFile, string ruta)
        {
            var guid = Guid.NewGuid().ToString();
            var fileName = guid + Path.GetExtension(BoletaIFormFile.FileName);
            // REALIZO LA EXTENSION DEL DOCUMENTO
            var carga1 = Path.Combine(_webHostEnvironment.WebRootPath, "images", ruta);
            using (var fileStream = new FileStream(Path.Combine(carga1, fileName), FileMode.Create))
            {
                await BoletaIFormFile.CopyToAsync(fileStream);
            }
            return string.Format("/images/{0}/{1}", ruta, fileName);
        }

        //EDITAR LOS DATOS CREADOS
        public async Task<IActionResult> Edit(int id)
        {
            var Zonas = await _context.Zonas.ToListAsync();
            ViewData["IdZona"] = new SelectList(Zonas, "Id", "NombreZona");
            // ViewBag.IdZona = new SelectList(Zonas, "NombreZona"); tambien se puede con este

            var Categorias = await _context.Categorias.ToListAsync();
            ViewData["IdCategoria"] = new SelectList(Categorias, "id", "NombreCategoria");
            // ViewBag.IdCategoria = new SelectList(Categorias, "NombreCategoria");

            var compras = new Compras { FechaVencimiento = DateTime.Now.Date };
            return PartialView(compras);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Compras model)
        {
            var modelOld = await _context.Compras.FindAsync(model.Id);

            modelOld.Fecha = model.Fecha; // Actualizar el campo Fecha
            modelOld.IdZona = model.IdZona; // Actualizar el campo IdZona
            modelOld.IdCategoria = model.IdCategoria; // Actualizar el campo IdCategoria
            modelOld.IdProducto = model.IdProducto; // Actualizar el campo IdProducto
            modelOld.IdTrabajador = model.IdTrabajador; // Actualizar el campo IdTrabajador
            modelOld.Cantidad = model.Cantidad; // Actualizar el campo Cantidad
            modelOld.Observaciones = model.Observaciones; // Actualizar el campo Observaciones

            // Actualizar DocumentoTecnico si se proporciona un nuevo archivo
            if (model.BoletaIFormFile != null)
            {
                // Eliminar el DocumentoTecnico anterior si existe
                if (!string.IsNullOrEmpty(modelOld.Boleta))
                {
                    var BoletaPath = Path.Combine(_webHostEnvironment.WebRootPath, modelOld.Boleta.TrimStart('/'));
                    if (System.IO.File.Exists(BoletaPath))
                    {
                        System.IO.File.Delete(BoletaPath);
                    }
                }
                // Cargar el nuevo DocumentoTecnico
                modelOld.Boleta = await CargarDocumento(model.BoletaIFormFile, "Boleta");
            }

            _context.Update(modelOld);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //PARA ACTIVAR Y ANULAR COMPRAS
        public async Task<IActionResult> Activar(int id)
        {
            var compras = await _context.Compras.FindAsync(id);
            compras.Estado = true; // Establecer el estado como activado
            _context.Update(compras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Anular COMPRAS method GET
        public async Task<IActionResult> Anular(int id)
        {
            var compras = await _context.Compras.FindAsync(id);
            compras.Estado = false; // Establecer el estado como anulado
            _context.Update(compras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
