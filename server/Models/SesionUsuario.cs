using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class SesionUsuario
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}