using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class Archivo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public DateTime FechaSubida { get; set; }
        public ObjectId TemaId { get; set; }
    }
}