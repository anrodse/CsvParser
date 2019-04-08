using Anrodse.CsvParser.Attributes;

namespace Anrodse.CsvParser.Demo.Modelo
{
	public class Transactions
	{
		[CsvCol("street")]
		public string Street { get; set; }

		[CsvCol("city")]
		public string City { get; set; }

		[CsvCol("zip")]
		public string zip { get; set; }

		[CsvCol("state")]
		public string state { get; set; }

		[CsvCol("beds")]
		public string beds { get; set; }

		[CsvCol("baths")]
		public string baths { get; set; }

		[CsvCol("sq__ft")]
		public string sq__ft { get; set; }

		[CsvCol("type")]
		public string type { get; set; }

		[CsvCol("sale_date")]
		public string sale_date { get; set; }

		[CsvCol("price")]
		public string price { get; set; }

		[CsvCol("latitude")]
		public string Latitude { get; set; }

		[CsvCol("longitude")]
		public string Longitude { get; set; }

	}
}
