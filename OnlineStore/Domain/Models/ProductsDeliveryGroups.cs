
namespace OnlineStore.Domain.Models
{
	public class ProductsDeliveryGroups
	{
		public int ProductId { get; set; }
		public int DeliveryGroupId { get; set; }
		public Product Product { get; set; }
		public DeliveryGroup DeliveryGroup { get; set; }
	}
}
