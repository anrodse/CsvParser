using Anrodse.CsvParser.Attributes;
using Anrodse.CsvParser.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Anrodse.CsvParser.Serialization
{
	public class CsvSerializer
	{
		private readonly Type T;

		#region Constructor

		public CsvSerializer(Type T) { this.T = T; }

		#endregion Constructor

		#region Serialize

		/// <summary>
		/// Write csv file from list
		/// </summary>
		/// <param name="data">data objects</param>
		/// <param name="reader">Csv file writer</param>
		/// <param name="addHeaders">Add column headers (if true)</param>
		public void Serialize(IEnumerable<object> data, CsvWriter writer, bool addHeaders = true)
		{
			if (addHeaders)
			{
				var atributos = getAtributos();
				writer.WriteRow(atributos);
			}

			var propiedades = getPropiedades();
			string[] fila = new string[propiedades.Count()];
			foreach (var obj in data)
			{
				for (int i = 0; i < fila.Count(); i++)
				{
					string hr = propiedades[i].ToString();
					fila[i] = T.GetProperty(hr)?.GetValue(obj, null)?.ToString() ?? "";
				}

				writer.WriteRow(fila);
			}
		}

		private string[] getPropiedades()
		{
			return T.GetProperties()
						.Where(x => x.GetCustomAttributes(true).Where(y => y is CsvColAttribute).Count() > 0)
						.Select(x => x.Name)
						.ToArray();
		}

		private string[] getAtributos()
		{
			List<string> res = new List<string>();

			PropertyInfo[] props = T.GetProperties();
			foreach (PropertyInfo prop in props)
			{
				foreach (Attribute att in prop.GetCustomAttributes(true))
				{
					if (att is CsvColAttribute)
					{
						res.Add((att as CsvColAttribute).Columna);
					}
				}
			}

			return res.ToArray();
		}

		#endregion Serialize

		#region Deserialize

		/// <summary>
		/// Read csv file into list
		/// </summary>
		/// <param name="reader">Csv file reader</param>
		/// <returns>object list extracted from file</returns>
		public IEnumerable<object> Deserialize(CsvReader reader)
		{
			var diccionario = GetDiccionarioCabeceras(reader);
			List<object> lista = new List<object>();
			List<string> fila = new List<string>();

			var props = T.GetProperties();

			int nFila = 1;  // Cabeceras
			while (reader.ReadRow(fila))
			{
				nFila++;
				object obj = Activator.CreateInstance(T);

				foreach (PropertyInfo prop in props)
				{
					var ats = prop.GetCustomAttributes(true);
					foreach (var at in ats)
					{
						if (at is CsvColAttribute col)
						{
							if (diccionario.TryGetValue(col.Columna, out int pos))
							{
								try
								{
									TrySetValue(fila[pos], obj, prop);
								}
								catch (Exception ex)
								{
									throw new CsvParseException((ex.InnerException ?? ex).Message, ex.InnerException ?? ex) { Row = nFila, Col = col.Columna };
								}
							}
						}
					}
				}

				lista.Add(obj);
			}

			return lista;
		}

		private Dictionary<string, int> GetDiccionarioCabeceras(CsvReader reader)
		{
			// Leer cabecera en una lista
			List<string> cabecera = new List<string>();
			if (!reader.ReadHeader(cabecera)) return null;

			// Crear diccionario para collumna: posicion
			Dictionary<string, int> dic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
			for (int i = 0; i < cabecera.Count; i++)
			{ dic.Add(cabecera[i], i); }

			return dic;
		}

		private void TrySetValue(string valor, object obj, PropertyInfo prop)
		{
			if (String.IsNullOrWhiteSpace(valor)) return;

			// Opcion 0: OK para strings solo
			if (prop.PropertyType == typeof(string))
			{
				prop.SetValue(obj, valor, null);
				return;
			}

			// Opcion 1: No funca
			//var converter = System.ComponentModel.TypeDescriptor.GetConverter(prop);
			//var result = converter.ConvertFrom(valor);

			// Opcion 2
			var parse = prop.PropertyType.GetMethod("Parse", new[] { typeof(string) });

			// Asignar valor
			if (parse != null)
			{
				var result = parse.Invoke(null, new object[] { valor });
				prop.SetValue(obj, result, null);
			}
		}

		//private delegate bool TryParser<T>(string input, out T result);
		//private static bool TryParse<T>(string valor, out T result, TryParser<T> tryParser = null)
		//{
		//	if (valor == null) throw new ArgumentNullException("toConvert");

		//	if (tryParser == null)
		//	{
		//		var method = typeof(T).GetMethod("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });

		//		if (method == null) throw new InvalidOperationException("Type does not have a built in try-parser.");

		//		tryParser = (TryParser<T>)Delegate.CreateDelegate
		//			(typeof(TryParser<T>), method);
		//	}

		//	return tryParser(valor, out result);
		//}

		#endregion Deserialize

	}
}
