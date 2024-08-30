using Microsoft.AspNetCore.Mvc;
using Server.Models;
using MongoDB.Driver;
using Server.Data;
using MongoDB.Bson;
namespace Server.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : Controller{
        private readonly MongoDbContext _context;

        public TemaController(MongoDbContext context){
            _context = context;
        }
        [HttpPost("{materiaId}")]
        public IActionResult AgregarTema([FromBody] Tema tema, string materiaId){
            if(tema == null || string.IsNullOrEmpty(materiaId)){
                return BadRequest("Datos inválidos.");
            }
            var materia = _context.Materias.Find(m => m.Id == new ObjectId(materiaId)).FirstOrDefault();
            if(materia == null){
                return NotFound("Materia no encontrada.");
            }
            materia.Temas.Add(tema);
            _context.Materias.ReplaceOne(m => m.Id == materia.Id, materia);
            return Ok("Tema agregado a la materia.");
        }
    }
}