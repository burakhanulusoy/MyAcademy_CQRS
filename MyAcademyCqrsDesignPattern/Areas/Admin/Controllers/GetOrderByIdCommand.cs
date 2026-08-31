using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.OrderQueries;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    internal class GetOrderByIdCommand : GetOrderByIdQuery
    {
        public GetOrderByIdCommand(int id) : base(id)
        {
        }
    }
}