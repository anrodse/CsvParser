# CsvParser

A simple csv file parser, using class attributes.

## Using the CsvParser library

Write your model using CsvCol attribute for choosen properties:

	public class Foo
	{
		[CsvCol("Bar")]
		public string MyBar { get; set; }
	}

Read the file using the parser

	public List<Foo> void Read()
	{
		string file = "PATH\TO\FILE.csv";
		Serialization.CsvSerializer csv = new Serialization.CsvSerializer(typeof(Foo));
		return csv.Deserialize(new CsvReader(file));
	}

### Reading file by lines
Files can be read line by line into a list of strings

	public void ReadByLine()
	{
		string file = "PATH\TO\FILE.csv";
		CsvReader reader = new CsvReader(file);
		List<string> row = new List<string>();

		reader.ReadHeader(row);
		Console.WriteLine(String.Join(";", row));	// Print file headers
		while (reader.ReadRow(row))
		{
			Console.WriteLine(String.Join(";", row));	// Print file as it is
		}
	}


# Contact
Let me know if you find any bug or if you have code improvements.
