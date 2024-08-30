using Microsoft.AspNetCore.Mvc;
using Server.Models;
using MongoDB.Driver;
using Server.Data;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MongoDbContext _context;


        public UsersController(MongoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if(usuario == null)
            {
                return BadRequest();
            }
            else if(string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Contraseña))
            {
                return BadRequest();
            }
            else
            {
                if(_context.Usuarios.Find(u => u.Nombre == usuario.Nombre).Any())
                {
                    return BadRequest("El nombre de usuario ya está en uso.");
                }
                else if(_context.Usuarios.Find(u => u.Email == usuario.Email).Any())
                {
                    return BadRequest("El correo electrónico ya está en uso.");
                }
                _context.Usuarios.InsertOne(usuario);
                return Ok(usuario);
            }
        }

       [HttpGet("{nombre}")]
        public IActionResult ObtenerUsuario(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return BadRequest("El nombre no puede estar vacío.");
            }

            var filter = Builders<Usuario>.Filter.Eq(u => u.Nombre, nombre);
            var usuario = _context.Usuarios.Find(filter).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound($"No se encontró ningún usuario con el nombre '{nombre}'.");
            }

            return Ok(usuario);
        }

    }
}