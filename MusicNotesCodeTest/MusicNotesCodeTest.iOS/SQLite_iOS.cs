using System;
using System.IO;
using MusicNotesCodeTest.iOS;
using Xamarin.Forms;

[assembly: Dependency (typeof (SQLite_iOS))]

namespace MusicNotesCodeTest.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS()
		{
		}

		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "SQLite.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, sqliteFilename);

			var conn = new SQLite.SQLiteConnection(path);

			return conn;
		}
	}
}
