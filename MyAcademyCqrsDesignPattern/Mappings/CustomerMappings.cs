using AutoMapper;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.Mappings
{
    public class CustomerMappings:Profile
    {
        public CustomerMappings()
        {
            
            CreateMap<Customer,GetCustomerByIdQueryResult>().ReverseMap();
            CreateMap<Customer,GetCustomersQueryResult>().ReverseMap();
            CreateMap<Customer,CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer,UpdateCustomerCommand>().ReverseMap();
            CreateMap<GetCustomerByIdQueryResult, UpdateCustomerCommand>();

            CreateMap<Customer, GetCustomersWithOrdersQueryResult>().ReverseMap();

        }




    }
}
