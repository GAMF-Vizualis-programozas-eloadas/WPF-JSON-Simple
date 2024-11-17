using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;

namespace JSON_Simple
{
	/// <summary>
	/// Examples for serialization into JSON format and deserialization
	/// of object lists without circular references.
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<Article> Articles;
		private List<Article> DeserializedArticles;

		public MainWindow()
		{
			InitializeComponent();
			Articles = new List<Article>();
			CreateLists();
			// Serialization of an object list into a string in JSON format.
			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.LatinExtendedA,UnicodeRanges.Latin1Supplement),
				WriteIndented = true
			};
			string json = JsonSerializer.Serialize(Articles,options);
			tbJSON.Text = json;
			
			// Serialization of an object list into a text file in JSON format.
			File.WriteAllText("Articles.json", json);

			// Deserialization from a string into an object list. 
			string jsonr = File.ReadAllText("Articles.json");
			tbJSON.Text += "\n-------------------------------------------------------\n" +
				jsonr;
			DeserializedArticles = JsonSerializer.Deserialize<List<Article>>(jsonr);
		}
		public void CreateLists()
		{
			var ar1 = new Article
			{
				ID = 1,
				DateofPublication =	new DateTime(2018, 10, 15),
				Title = "Fuzzy Model for the Average Delay Time on a Road Ending with a Traffic Light",
				IsOpenSource = false,
				Authors = "Alvarez, Johanyák"
			};
			var ar2 = new Article { ID = 2, DateofPublication = new DateTime(2008, 5, 15), Title = "Generalization of the single rule reasoning method SURE-LS for the case of arbitrary polygonal shaped fuzzy sets", IsOpenSource = true, Authors = "Johanyák, Alvarez" };
			var ar3 = new Article { ID = 3, DateofPublication = new DateTime(2017, 1, 1), Title = "New cognitive info-communication channels for human-machine interaction", IsOpenSource = false, Authors = "Kovács" };
			// Adding more tan one element as a collection expression.
			Articles.AddRange([ar1, ar2, ar3]);
		}
	}
}
