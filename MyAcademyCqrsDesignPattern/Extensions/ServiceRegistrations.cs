using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using System.Reflection;

namespace MyAcademyCqrsDesignPattern.Extensions
{
    public static class ServiceRegistrations
    {

        //this deme nedenim uzerınde bulundgu prjeyı bellı etsın
        public static void AddCqrsHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetCategoriesQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();



            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        }



    }
}
