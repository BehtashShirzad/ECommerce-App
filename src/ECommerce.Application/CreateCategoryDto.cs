using ECommerce.Domain.Aggregates.Category;
using MediatR;

namespace ECommerce.Application;

public record CreateCategoryDto(string  Name, string Description,bool IsActive):IRequest;

public class handlerTest (ICategoryRepository categoryRepository): IRequestHandler<CreateCategoryDto>
{
    public async Task Handle(CreateCategoryDto request, CancellationToken cancellationToken)
    { 
        var category = Category.Create(request.Name,request.Description,request.IsActive);
       await categoryRepository.AddCategoryAsync(category);
        
    }
}
 