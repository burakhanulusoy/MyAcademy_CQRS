using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers;
using System.Reflection;

namespace MyAcademyCqrsDesignPattern.Extensions
{
    public static class ServiceRegistrations
    {

        //this deme nedenim uzerınde bulundgu prjeyı bellı etsın
        public static void AddCqrsHandlers(this IServiceCollection services)
        {
            //services.AddScoped<GetCategoriesQueryHandler>();
            //services.AddScoped<GetCategoryByIdQueryHandler>();
            //services.AddScoped<UpdateCategoryCommandHandler>();
            //services.AddScoped<CreateCategoryCommandHandler>();
            //services.AddScoped<RemoveCategoryCommandHandler>();



            //services.AddScoped<GetProductByIdQueryHandler>();
            //services.AddScoped<GetProductsQueryHandler>();
            //services.AddScoped<UpdateProductCommandHandler>();
            //services.AddScoped<CreateProductCommandHandler>();
            //services.AddScoped<RemoveProductCommandHandler>();

            //SCRUTOR İLE AUTO REGİSTRATİON

            services.Scan(options => options.FromAssemblies(Assembly.GetExecutingAssembly()) //kendi assembly içinde 
                     .AddClasses(x => x.Where(t => t.Name.EndsWith("Handler")))
                     .AsSelf()
                     .WithScopedLifetime()

            );

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        }



    }
}
