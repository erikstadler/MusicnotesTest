using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using SQLite;

namespace MusicNotesCodeTest.code.model.Library
{

	[XmlRoot(ElementName = "songs")]
	public class RootAllSongs
	{
		[XmlElement("song")]
		public List<Song> songs { get; set; }
	}

	public class Song
	{
		[PrimaryKey]
		public string id { get; set; }
		public string title { get; set; }
		public string artist { get; set; }
		public string key { get; set; }
		public string instruments { get; set; }
		public int pages { get; set; }

		public int views { get; set; }

		public static List<Song> parseXMLFile(string filename)
		{
			var assembly = typeof(Song).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream(filename);

			RootAllSongs newModel = null;
			using (var reader = new StreamReader(stream))
			{
				var serializer = new XmlSerializer(typeof(RootAllSongs));
				newModel = (RootAllSongs)serializer.Deserialize(reader);
			}
			return newModel.songs;
		}

	}
}