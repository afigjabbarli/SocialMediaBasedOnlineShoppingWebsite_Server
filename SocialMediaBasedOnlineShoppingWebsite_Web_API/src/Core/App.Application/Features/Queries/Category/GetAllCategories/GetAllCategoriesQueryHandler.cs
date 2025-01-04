using MediatR;

namespace App.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        public Task Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<GetAllCategoriesQueryResponse> IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>.Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
