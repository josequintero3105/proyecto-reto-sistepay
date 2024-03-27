using AutoMapper;
using MongoDB.Bson;
using ProyectoBack.Models;

namespace ProyectoBack.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile() 
        {
            CreateMap<Producto, ProductoDTO>()
                .ForMember(a => a.Name, e => e.MapFrom(c => c.Name))
                .ForMember(a => a.Price, e => e.MapFrom(c => c.Price))
                .ForMember(a => a.Quantity, e => e.MapFrom(c => c.Quantity))
                .ForMember(a => a.Description, e => e.MapFrom(c => c.Description))
                .ForMember(a => a.Category, e => e.MapFrom(c => c.Category))
                .ForMember(a => a.State, e => e.MapFrom(c => c.State))
                .ReverseMap();
            //CreateMap<BsonDocument, Producto>()
            //    .ForMember(a => a._id, e => e.MapFrom(c => c["_id"].AsObjectId))
            //    .ForMember(a => a.Name, e => e.MapFrom(c => c["Name"].AsString))
            //    .ForMember(a => a.Price, e => e.MapFrom(c => c["Price"].AsDouble))
            //    .ForMember(a => a.Quantity, e => e.MapFrom(c => c["Quantity"].AsInt32))
            //    .ForMember(a => a.Description, e => e.MapFrom(c => c["Description"].AsString))
            //    .ForMember(a => a.Category, e => e.MapFrom(c => c["Category"].AsString))
            //    .ForMember(a => a.State, e => e.MapFrom(c => c["State"].AsBoolean));
        }
    }
}
