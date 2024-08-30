using Microsoft.AspNetCore.Mvc;
using Server.Models;
using MongoDB.Driver;
using Server.Data;
using MongoDB.Bson;
namespace Server.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase{
        private readonly MongoDbContext _context;
        public MateriaController(MongoDbContext context){
            _context = context;
        }

        [HttpPost("CrearMateria")]
        public IActionResult CrearMateria([FromBody] Materia materia){
            if(materia == null){
                return BadRequest("Datos inválidos.");
            }
            else if(string.IsNullOrEmpty(materia.Nombre) || string.IsNullOrEmpty(materia.Descripcion)){
                return BadRequest("Datos inválidos.");
            }
            else{
                _context.Materias.InsertOne(materia);
                return Ok(materia);
            }
        }

        [HttpPost("{materiaId}")]
        public IActionResult AgregarMateria(string materiaId, string usuarioId){
            if(string.IsNullOrEmpty(materiaId) || string.IsNullOrEmpty(usuarioId)){
                return BadRequest("Datos inválidos.");
            }

            var materia = _context.Materias.Find(m => m.Id == new ObjectId(materiaId)).FirstOrDefault();
            var usuario = _context.Usuarios.Find(u => u.Id == new ObjectId(usuarioId)).FirstOrDefault();

            if(materia == null || usuario == null){
                return NotFound("Materia o usuario no encontrado.");
            }

            usuario.MateriasId.Add(materia.Id);
            _context.Usuarios.ReplaceOne(u => u.Id == usuario.Id, usuario);
            return Ok("Materia agregada al usuario.");
        }

        [HttpGet("{usuarioId}")]
        public IActionResult ObtenerMaterias(string usuarioId){
            if(string.IsNullOrEmpty(usuarioId)){
                return BadRequest("Datos inválidos.");
            }

            var filter = Builders<Usuario>.Filter.Eq(u => u.Id, new ObjectId(usuarioId));
            var usuario = _context.Usuarios.Find(filter).FirstOrDefault();

            if(usuario == null){
                return NotFound("Usuario no encontrado.");
            }

            List<Materia> materias = _context.Materias.Find(m => usuario.MateriasId.Contains(m.Id)).ToList();
            return Ok(materias);
        }

        [HttpGet("{materiaId}")]
        public IActionResult ObtenerMateria(string materiaId){
            if(string.IsNullOrEmpty(materiaId)){
                return BadRequest("Datos inválidos.");
            }

            var materia = _context.Materias.Find(m => m.Id == new ObjectId(materiaId)).FirstOrDefault();

            if(materia == null){
                return NotFound("Materia no encontrada.");
            }

            return Ok(materia);
        }

        [HttpDelete("{materiaId}")]
        public IActionResult EliminarMateria(string materiaId){
            if(string.IsNullOrEmpty(materiaId)){
                return BadRequest("Datos inválidos.");
            }

            var materia = _context.Materias.Find(m => m.Id == new ObjectId(materiaId)).FirstOrDefault();

            if(materia == null){
                return NotFound("Materia no encontrada.");
            }

            _context.Materias.DeleteOne(m => m.Id == new ObjectId(materiaId));
            return Ok("Materia eliminada.");
        }
    }
}