
namespace Rim.API.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string OrderAddress { get; set; }
		public string OrderRecipient { get; set; }
		public bool OrderCompleted { get; set; }
		public bool OrderCancelled { get; set; }
		public bool IsActive { get; set; }
		public virtual Product Product { get; set; }
	}
}
