using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class Tema
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ObjectId MateriaId { get; set; }
    }
}