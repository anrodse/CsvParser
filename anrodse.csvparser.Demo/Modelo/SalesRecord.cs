using Anrodse.CsvParser.Attributes;

namespace Anrodse.CsvParser.Demo.Modelo
{
	public class SalesRecord
	{
		[CsvCol("Region")]
		public string Region { get; set; }

		[CsvCol("Country")]
		public string Country { get; set; }

		[CsvCol("Item Type")]
		public string ItemType { get; set; }

		[CsvCol("Sales Channel")]
		public string SalesChannel { get; set; }

		[CsvCol("Order Priority")]
		public char OrderPriority { get; set; }

		[CsvCol("Order Date")]
		public string OrderDate { get; set; }

		[CsvCol("Order ID")]
		public int OrderID { get; set; }

		[CsvCol("Ship Date")]
		public string ShipDate { get; set; }

		[CsvCol("Units Sold")]
		public int UnitsSold { get; set; }

		[CsvCol("Unit Price")]
		public float UnitPrice { get; set; }

		[CsvCol("Unit Cost")]
		public float UnitCost { get; set; }

		[CsvCol("Total Revenue")]
		public double TotalRevenue { get; set; }

		[CsvCol("Total Cost")]
		public double TotalCost { get; set; }

		[CsvCol("Total Profit")]
		public double TotalProfit { get; set; }

	}
}
