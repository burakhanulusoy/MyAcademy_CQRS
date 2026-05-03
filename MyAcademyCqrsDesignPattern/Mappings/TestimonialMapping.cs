using AutoMapper;
using Microsoft.Identity.Client;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.TestimonialResults;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.Mappings
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>();
            CreateMap<Testimonial, GetTestimonialsQueryResult>();
            CreateMap<UpdateTestimonialCommand, Testimonial>();
            CreateMap<CreateTestimonialCommand, Testimonial>();
            CreateMap<GetTestimonialByIdQueryResult, UpdateTestimonialCommand>();
        }
    }
}
