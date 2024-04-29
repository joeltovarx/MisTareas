using Microsoft.AspNetCore.Mvc; 
using MisTareas.Datos;
using MisTareas.Models;

namespace MisTareas.Controllers
{
    public class MantenedorController : Controller
    {
        TareasDatos _TareasDatos = new TareasDatos();
        public IActionResult Listar()
        {
            var listaDatos = _TareasDatos.listarTareas();

            return View(listaDatos);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(TareasModel objTareas)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _TareasDatos.crearTarea(objTareas);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idTarea)
        {
            var objTarea = _TareasDatos.obtenerTarea(idTarea);
            return View();
        }
        [HttpPost]
        public IActionResult Editar(TareasModel objTareas)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _TareasDatos.modificarTarea(objTareas);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idTarea)
        {
            var objTarea = _TareasDatos.obtenerTarea(idTarea);
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(TareasModel objTareas)
        {
            

            var respuesta = _TareasDatos.eliminarTarea(objTareas.idTarea);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }

}
