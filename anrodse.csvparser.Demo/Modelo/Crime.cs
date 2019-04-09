using Anrodse.CsvParser.Attributes;

namespace Anrodse.CsvParser.Demo.Modelo
{
	public class Crime
	{
		[CsvCol("ID")]
		public string ID { get; set; }

		[CsvCol("Case Number")]
		public string CaseNumber { get; set; }

		[CsvCol("Date")]
		public string Date { get; set; }

		[CsvCol("Block")]
		public string Block { get; set; }

		[CsvCol("IUCR")]
		public string IUCR { get; set; }

		[CsvCol("Primary Type")]
		public string PrimaryType { get; set; }

		[CsvCol("Description")]
		public string Description { get; set; }

		[CsvCol("Location Description")]
		public string LocationDescription { get; set; }

		[CsvCol("Arrest")]
		public string Arrest { get; set; }

		[CsvCol("Domestic")]
		public string Domestic { get; set; }

		[CsvCol("Beat")]
		public string Beat { get; set; }

		[CsvCol("District")]
		public string District { get; set; }

		[CsvCol("Ward")]
		public string Ward { get; set; }

		[CsvCol("Community Area")]
		public string CommunityArea { get; set; }

		[CsvCol("FBI Code")]
		public string FBICode { get; set; }

		[CsvCol("X Coordinate")]
		public string X_Coordinate { get; set; }

		[CsvCol("Y Coordinate")]
		public string Y_Coordinate { get; set; }

		[CsvCol("Year")]
		public string Year { get; set; }

		[CsvCol("Updated On")]
		public string UpdatedOn { get; set; }

		[CsvCol("Latitude")]
		public double Latitude { get; set; }

		[CsvCol("Longitude")]
		public double Longitude { get; set; }

		[CsvCol("Location")]
		public string Location { get; set; }

	}
}
