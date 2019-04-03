namespace Anrodse.CsvParser.Attributes
{
	public class CsvColAttribute : System.Attribute
	{
		public CsvColAttribute(string columna)
		{
			this.Columna = columna;
		}

		public string Columna;
	}
}
