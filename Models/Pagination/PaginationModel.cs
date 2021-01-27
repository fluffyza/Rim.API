
namespace Rim.API.Models
{
	public class PaginationModel
	{
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public double TotalPageCount { get; set; }
		public int TotalResults { get; set; }
	}
}
