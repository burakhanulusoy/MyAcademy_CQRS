using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CategoryResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;
    public record CreateProductCommand(
                                         string Name,
                                         string Description,
                                         decimal Price,
                                         string ImageUrl,
                                         int CategoryId

                                        
                                         );
    
    

