using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace Anrodse.CsvParser
{
	/// <summary>
	/// Clase para lectura de fichero csv
	/// </summary>
	public class CsvReader : StreamReader
	{
		#region Propiedades

		/// <summary>
		/// Column separator (';' by default)
		/// </summary>
		public char Separator { get; set; } = ';';

		#endregion Propiedades

		#region Constructor

		public CsvReader(Stream stream) : base(stream) { }

		[SecuritySafeCritical]
		public CsvReader(string path) : base(path) { }

		public CsvReader(Stream stream, Encoding encoding) : base(stream, encoding) { }

		[SecuritySafeCritical]
		public CsvReader(string path, Encoding encoding) : base(path, encoding) { }

		#endregion Constructor

		/// <summary>
		/// Reads one line from csv file
		/// </summary>
		/// <param name="row">Result array</param>
		/// <returns>true si la línea es correcta</returns>
		public bool ReadRow(List<string> row)
		{
			string linea = ReadLine();
			if (String.IsNullOrEmpty(linea)) return false;

			int p = 0, rows = 0;
			while (p < linea.Length)
			{
				string value;
				int ini = p;

				if (linea[p] == '"')
				{
					p++;
					while (p < linea.Length)
					{
						// Si encuentro comillas
						if (linea[p] == '"')
						{
							p++;

							// Si hay dos dobles comillas, se ignorarán
							if (p >= linea.Length || linea[p] != '"')
							{
								break;
							}
						}
						p++;
					}

					value = linea.Substring(ini + 1, p - ini - 2);  // Evito comillas
					value = value.Replace("\"\"", "\"");
				}
				else
				{
					while (p < linea.Length && linea[p] != Separator) p++;
					value = linea.Substring(ini, p - ini);
				}

				// Añadir valor a la lista
				if (rows < row.Count) row[rows] = value;
				else row.Add(value);

				rows++;

				// Pasar a la siguiente coma
				while (p < linea.Length && linea[p] != Separator) p++;
				if (p < linea.Length) p++;
			}

			// Borrar columnas no usadas
			while (row.Count > rows) row.RemoveAt(rows);

			return (row.Count > 0);
		}

		/// <summary>
		/// Read csv column headers
		/// Reestart file read, moving pointer to the begining
		/// </summary>
		/// <param name="row">Column list</param>
		/// <returns>true if header read is correct</returns>
		public bool ReadHeader(List<string> header)
		{
			// Mueve el puntero al principio
			BaseStream.Position = 0;
			DiscardBufferedData();

			return ReadRow(header);
		}

	}
}
