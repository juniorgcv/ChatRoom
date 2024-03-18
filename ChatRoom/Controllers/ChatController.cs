using Microsoft.AspNetCore.Mvc;

namespace ChatRoom.Controllers
{
    public class ChatController : Controller
    {
        public readonly Dictionary<int, string> DescripcionesDeSalas = new Dictionary<int, string>()
        {
            {1, "Esta es la sala general para todos los usuarios." },
            {2, "Esta sala es para hablar sobre música." },
            {3, "Esta sala es para hablar sobre deportes." }
        };

        public string GetDescripcion(int sala)
        {
            if (DescripcionesDeSalas.TryGetValue(sala, out string descripcion))
            {
                return descripcion;
            }
            else
            {
                return $"No hay descripcion";
            }
        }

        public readonly Dictionary<int, string> Salas = new Dictionary<int, string>()
        {
            {1, "Sala Uno" },
            {2, "Sala Dos" },
            {3, "Sala Tres" }
        };

        public IActionResult ListadeSalas()
        {
			ViewBag.Salas = Salas;
			ViewBag.DescripcionesDeSalas = DescripcionesDeSalas;
			return View();
        }

        public IActionResult Cuarto(int sala)
        {
            ViewBag.DescripcionSala = GetDescripcion(sala);
            ViewBag.Salas = Salas; // Pasar el diccionario completo de salas a la vista
            return View();
        }

    }

}
