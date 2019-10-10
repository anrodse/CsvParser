namespace Anrodse.CsvParser.Attributes
{
	/// <summary>
	/// Attribute class for csv columns definition
	/// </summary>
	public class CsvColAttribute : System.Attribute
	{
		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="columna">Column name in csv file</param>
		public CsvColAttribute(string columna)
		{
			this.Columna = columna;
		}

		/// <summary>
		/// Column name in csv file
		/// </summary>
		public string Columna { get; set; }
	}
}
