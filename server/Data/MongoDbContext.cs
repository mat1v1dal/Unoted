// Data/MongoDbContext.cs
using MongoDB.Driver;
using Server.Models;
using Microsoft.Extensions.Configuration;

namespace Server.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("UniversidadDB");
        }

        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
        public IMongoCollection<Materia> Materias => _database.GetCollection<Materia>("Materias");
        public IMongoCollection<Tema> Temas => _database.GetCollection<Tema>("Temas");
        public IMongoCollection<Archivo> Archivos => _database.GetCollection<Archivo>("Archivos");
        public IMongoCollection<SesionUsuario> SesionesUsuarios => _database.GetCollection<SesionUsuario>("SesionesUsuarios");
    }
}
