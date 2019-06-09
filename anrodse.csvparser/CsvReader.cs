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

			string valor;
			int ini, p = 0, nrow = 0;

			while (p < linea.Length)
			{
				if (linea[p] == '"')
				{
					p++;
					ini = p;
					valor = string.Empty;

					while (true)
					{
						// Si encuentro comillas
						if (linea[p] == '"')
						{
							p++;

							// Si hay dos dobles comillas, se ignorarán
							if (p >= linea.Length || linea[p] != '"')
							{ break; }
						}

						p++;
						if (p >= linea.Length)
						{
							valor += linea.Substring(ini, p - ini) + "\r\n";
							while (String.IsNullOrEmpty(linea = ReadLine()))
							{
								if (linea == null) return false;
								valor += "\r\n";    // Lineas vacías
							}
							ini = p = 0;
						}
					}

					valor += linea.Substring(ini, p - ini - 1);  // Evito comillas
					valor = valor.Replace("\"\"", "\"");
				}
				else
				{
					ini = p;
					while (p < linea.Length && linea[p] != Separator) p++;
					valor = linea.Substring(ini, p - ini);
				}

				// Añadir valor a la lista
				if (nrow < row.Count) row[nrow] = valor;
				else row.Add(valor);
				nrow++;

				p++;    // Saltar separador
			}

			// Si acaba en "Separador", añadir una columna vacía
			if (linea[linea.Length - 1].Equals(Separator))
			{
				valor = String.Empty;
				if (nrow < row.Count) row[nrow] = valor;
				else row.Add(valor);
				nrow++;
			}

			// Borrar columnas no usadas
			while (row.Count > nrow) row.RemoveAt(nrow);

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
