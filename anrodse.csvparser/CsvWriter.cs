using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Anrodse.CsvParser
{
	/// <summary>
	/// Class for CSV file writing
	/// </summary>
	public class CsvWriter : StreamWriter
	{
		#region Propiedades

		/// <summary>
		/// Column separato (';' by default)
		/// </summary>
		public char Separator { get; set; } = ';';

		#endregion Propiedades

		#region Constructor

		public CsvWriter(Stream stream) : base(stream) { }

		public CsvWriter(string filename) : base(filename) { }

		#endregion Constructor

		/// <summary>
		/// Write one row in a file
		/// </summary>
		/// <param name="row">Row to be written</param>
		public void WriteRow(List<string> row)
		{
			StringBuilder strBuilder = new StringBuilder();
			bool firstColumn = true;
			foreach (string value in row)
			{
				// Escapar caracteres especiales
				if (value.IndexOfAny(new char[] { '"', Separator }) == -1) strBuilder.Append(value);
				else strBuilder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));

				// Separador para primera columna
				if (!firstColumn)
				{
					strBuilder.Append(Separator);
					firstColumn = false;
				}
			}

			WriteLine(strBuilder.ToString());
		}

	}

}
