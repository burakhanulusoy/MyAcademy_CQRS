using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;

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


        }



    }
}
