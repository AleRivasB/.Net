using Clase1.Data;
using Clase1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace Clase1.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly ApplicationDbContext _context;

        public EmpleadoController(ApplicationDbContext context)
        {
            //_logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Empleados = _context.Empleados.ToList(); //Convierte en una lista
            ViewBag.TipoEmpleados = _context.TipoEmpleados.ToList();
            return View();

            
        }
        public IActionResult Index1()
        {
            ViewBag.TipoEmpleados = _context.TipoEmpleados.ToList(); //Convierte en una lista
            return View();


        }

        // Método para obtener un empleado por ID (para editar)
        [HttpGet]
        public IActionResult GetEmpleado()
        {
            var empleado = _context.Empleados.ToList();
            if (empleado == null)
            {
                return NotFound();
            }
            return Json(empleado);
        }

        [HttpPost]
        public IActionResult GetEmpleadobyId(int id)
        {
            var empleado = _context.Empleados.Where(x => x.Id == id).SingleOrDefault();
            if (empleado == null)
            {
                return NotFound();
            }
            return Json(empleado);
        }


        // Método para obtener un empleado por ID (para editar)
        [HttpGet]
        public IActionResult GetTiposEmpleados()
        {
            var empleado = _context.TipoEmpleados.ToList();
            if (empleado == null)
            {
                return NotFound();
            }
            return Json(empleado);
        }

        // Método para crear un nuevo empleado (con AJAX)
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return Ok(new  { message = "Empleado creado correctamente" });
            }
            return BadRequest();
        }

        // Método para editar un empleado (con AJAX)
        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Update(empleado);
                _context.SaveChanges();
                return Ok(new { message = "Empleado actualizado correctamente" });
            }
           return BadRequest();
        }

        // Método para eliminar un empleado (con AJAX)
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();

            return Ok(new { message = "Empleado eliminado correctamente" });
        }
    }
}

