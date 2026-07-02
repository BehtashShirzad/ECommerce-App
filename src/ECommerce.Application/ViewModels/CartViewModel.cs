namespace ECommerce.Application.ViewModels;

public class CartViewModel
{
    public record CartDto(List<ProductViewModel.ProductViewModelOutput>Products,decimal TotalPrice);
}