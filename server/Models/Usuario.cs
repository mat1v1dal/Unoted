using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class Usuario
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }

        public List<ObjectId> MateriasId { get; set; } = new List<ObjectId>();
    }
}