using Anrodse.CsvParser.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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

		private IEnumerable<object> objetos;

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

				using (var reader = new CsvReader(fichero) { Separator = Separador })
				{
					CsvSerializer csv = new CsvSerializer(T);
					objetos = csv.Deserialize(reader);
				}
				crono.Stop();

				tabModelo.DataSource = objetos;
				lblStatus.Text = "Lectura finalizada en " + (crono.ElapsedMilliseconds/ 1000.0) + " s.";
				lblResultado.Text = objetos.Count() + " resultados";
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

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (objetos == null || objetos.Count() == 0)
			{
				MessageBox.Show("No hay datos cargados", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
				lblStatus.Text = "No hay datos que guardar.";
				lblResultado.Text = "Error";
				return;
			}

			SaveFileDialog fsd = new SaveFileDialog()
			{
				Filter = "csv (separado por comas)|*.csv",
				Title = "Guardar fichero CSV",
			};

			if (fsd.ShowDialog() == DialogResult.OK)
			{
				string path = fsd.FileName;
				lblStatus.Text = "Guardando datos en " + path + ".";

				using (CsvWriter writer = new CsvWriter(path) { Separator = ',' })
				{
					Type t = objetos.First().GetType();
					CsvSerializer csv = new CsvSerializer(t);
					csv.Serialize(objetos, writer);
				}
				lblStatus.Text = "Fichero de datos creado.";
			}
		}
	}
}
