using AutoMapper;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CategoryResults;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.ProductResults;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.Mappings
{
    public class ProductMappings:Profile
    {
        public ProductMappings()
        {
            
            CreateMap<Product,GetProductsQueryResult>().ReverseMap();
            CreateMap<Product,GetProductByIdQueryResult>().ReverseMap();
            CreateMap<Product,UpdateProductCommand>().ReverseMap();
            CreateMap<Product,CreateProductCommand>().ReverseMap();
            CreateMap<UpdateProductCommand,GetProductByIdQueryResult>().ReverseMap();
            
            








            CreateMap<Category, GetCategoriesQueryResult>().ReverseMap();


        }
    }
}
