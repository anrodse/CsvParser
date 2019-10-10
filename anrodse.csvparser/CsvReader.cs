using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace Anrodse.CsvParser
{
	/// <summary>
	/// Class for csv file read
	/// </summary>
	public class CsvReader : StreamReader
	{
		#region Enums

		/// <summary>
		/// Read results
		/// </summary>
		public enum ReadResult
		{
			/// <summary>
			/// Ok result
			/// </summary>
			Ok,
			/// <summary>
			/// End of File result
			/// </summary>
			EoF,
			/// <summary>
			/// Error result
			/// </summary>
			Error,
			/// <summary>
			/// Empty line result
			/// </summary>
			EmptyLine,
			/// <summary>
			/// Just separators line result
			/// </summary>
			SemicolonLine
		}

		#endregion Enums

		#region Propiedades

		/// <summary>
		/// Column separator (';' by default)
		/// </summary>
		public char Separator { get; set; } = ';';

		#endregion Propiedades

		#region Constructores

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="stream">Csv input stream</param>
		public CsvReader(Stream stream) : base(stream) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="path">Csv file path</param>
		[SecuritySafeCritical]
		public CsvReader(string path) : base(path) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="stream">Csv input stream</param>
		/// <param name="encoding">Text encoding</param>
		public CsvReader(Stream stream, Encoding encoding) : base(stream, encoding) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="path">Csv file path</param>
		/// <param name="encoding">Text encoding</param>
		[SecuritySafeCritical]
		public CsvReader(string path, Encoding encoding) : base(path, encoding) { }

		#endregion Constructores

		/// <summary>
		/// Reads one line from csv file. Empty lines will be ignored
		/// </summary>
		/// <param name="row">Result array</param>
		/// <returns>Read result</returns>
		public ReadResult ReadRow(ref List<string> row)
		{
			string linea = ReadLine();

			if (linea == null) { row.Clear(); return ReadResult.EoF; }
			if (String.IsNullOrEmpty(linea)) { /*row.ForEach(x => x = String.Empty);*/ return ReadResult.EmptyLine; }
			if (String.IsNullOrEmpty(linea.Trim(Separator))) { /*row.Clear();*/ return ReadResult.SemicolonLine; }

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
								if (linea == null) return ReadResult.Error;
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

			//return (row.Count > 0)? ReadResult.Ok: ReadResult.EmptyLine;
			return ReadResult.Ok;
		}

		/// <summary>
		/// Read csv column headers
		/// Reestart file read, moving pointer to the begining
		/// </summary>
		/// <param name="header">Column list</param>
		/// <returns>Read result</returns>
		public ReadResult ReadHeader(ref List<string> header)
		{
			// Mueve el puntero al principio
			BaseStream.Position = 0;
			DiscardBufferedData();

			return ReadRow(ref header);
		}

	}
}
