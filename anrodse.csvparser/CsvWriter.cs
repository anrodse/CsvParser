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
		/// Column separator (';' by default)
		/// </summary>
		public char Separator { get; set; } = ';';

		#endregion Propiedades

		#region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="stream">Output stream</param>
		public CsvWriter(Stream stream) : base(stream) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="stream">Output stream</param>
		/// <param name="encoding">Text encoding</param>
		public CsvWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="path">Output file path</param>
		/// <param name="append">Append to the file or not</param>
		public CsvWriter(string path, bool append) : base(path, append) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="path">Output file path</param>
		/// <param name="append">Append to the file or not</param>
		/// <param name="encoding">Text encoding</param>
		public CsvWriter(string path, bool append, Encoding encoding) : base(path, append, encoding) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="filename">Output file name</param>
		public CsvWriter(string filename) : base(filename) { }

		#endregion Constructor

		/// <summary>
		/// Write one row in a file
		/// </summary>
		/// <param name="row">Row to be written</param>
		public void WriteRow(IEnumerable<string> row)
		{
			StringBuilder strBuilder = new StringBuilder();
			foreach (string value in row)
			{
				// Escapar caracteres especiales
				if (value.IndexOfAny(new char[] { '"', '\r', '\n', Separator }) == -1) strBuilder.Append(value);
				else strBuilder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));

				strBuilder.Append(Separator);
			}

			// Eliminar último separador
			strBuilder.Remove(strBuilder.Length - 1, 1);

			WriteLine(strBuilder);
		}

	}
}