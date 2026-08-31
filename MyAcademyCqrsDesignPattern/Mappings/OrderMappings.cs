using AutoMapper;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.OrderResults;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.Mappings
{
    public class OrderMappings:Profile
    {
        public OrderMappings()
        {
            CreateMap<Order,GetOrderByIdQueryResult>().ReverseMap();
            CreateMap<Order,GetOrdersQueryResult>().ReverseMap();
            CreateMap<Order,CreateOrderCommand>().ReverseMap();
            CreateMap<Order,UpdateOrderCommand>().ReverseMap();
            CreateMap<UpdateOrderCommand,GetOrderByIdQueryResult>().ReverseMap();

            CreateMap<Order, GetOrdersByCustomerIdQueryResult>().ReverseMap();

        }
    }
}
