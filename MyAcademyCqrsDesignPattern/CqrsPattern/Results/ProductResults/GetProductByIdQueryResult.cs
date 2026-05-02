using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CategoryResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Results.ProductResults;

    public record GetProductByIdQueryResult(int Id,
                                         string Name,
                                         string Description,
                                         decimal Price,
                                         string ImageUrl,
                                         int CategoryId,
                                         GetCategoriesQueryResult Category);
    