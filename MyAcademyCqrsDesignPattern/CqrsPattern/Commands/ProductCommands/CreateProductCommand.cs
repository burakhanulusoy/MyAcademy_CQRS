using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CategoryResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;
    public record CreateProductCommand(int Id,
                                         string Name,
                                         string Description,
                                         decimal Price,
                                         string ImageUrl,
                                         int CategoryId,
                                         GetCategoriesQueryResult Category);
    
    

