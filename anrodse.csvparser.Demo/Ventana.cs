using Anrodse.CsvParser.Serialization;
using Anrodse.CsvParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anrodse.CsvParser.Demo
{
	public partial class Ventana : Form
	{

		enum Modelos
		{
			[Description("Crimes")] Crimes,
			[Description("Sacramento transactions")] Transactions,
			[Description("Sales Record")] SalesRecord
		}

		public Ventana()
		{
			InitializeComponent();
			Inicializar();
		}

		private void Inicializar()
		{
			LoadComboModelo();
		}

		private void LoadComboModelo()
		{
			cmbModelo.DataSource = Enum.GetValues(typeof(Modelos)).Cast<Enum>().Select(value => new
			{
				(Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
				value
			}).OrderBy(item => item.value).ToList();

			cmbModelo.DisplayMember = "Description";
			cmbModelo.ValueMember = "value";
		}

		private void btnCargar_Click(object sender, EventArgs e)
		{
			switch (((dynamic)cmbModelo.SelectedItem).value)
			{
				case Modelos.Crimes:
					LeerFichero("Ejemplos\\crimes.csv", typeof(Modelo.Crime), ',');
					break;
				case Modelos.Transactions:
					LeerFichero("Ejemplos\\Sacramentorealestatetransactions.csv", typeof(Modelo.Transactions), ',');
					break;
				case Modelos.SalesRecord:
					LeerFichero("Ejemplos\\Sales Records.csv", typeof(Modelo.SalesRecord), ',');
					break;
			}
		}

		private void LeerFichero(string fichero, Type T, char Separador)
		{
			if (System.IO.File.Exists(fichero)) { lblStatus.Text = "Fichero aceptado. Leyendo datos...."; }
			else { lblStatus.Text = "No existe el fichero " + fichero; lblResultado.Text = "Error"; return; }

			System.Diagnostics.Stopwatch crono = new System.Diagnostics.Stopwatch();
			try
			{
				crono.Start();
				CsvSerializer csv = new CsvSerializer(T);
				var datos = csv.Deserialize(new CsvReader(fichero) { Separator = Separador });
				crono.Stop();

				tabModelo.DataSource = datos;
				lblStatus.Text = "Lectura finalizada en " + (crono.Elapsed.Milliseconds / 1000.0) + " s.";
				lblResultado.Text = datos.Count() + " resultados";
			}
			catch (CsvParser.Exceptions.CsvParseException ex)
			{
				lblStatus.Text = "Error en fichero csv. Linea " + ex.Row + ", columna " + ex.Col;
				lblResultado.Text = "Error";
			}
			catch (Exception ex)
			{
				lblStatus.Text = "Error leyendo fichero: " + ex.Message;
				lblResultado.Text = "Error";
			}

			crono.Reset();
		}

	}
}
