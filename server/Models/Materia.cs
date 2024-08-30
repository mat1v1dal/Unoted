using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class Materia
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ObjectId UsuarioId { get; set; }

        public List<Tema> Temas = new List<Tema>();
    }
}