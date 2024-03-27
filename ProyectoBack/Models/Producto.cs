using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoBack.Models
{
    public class Producto
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool State { get; set; }
    }
}
