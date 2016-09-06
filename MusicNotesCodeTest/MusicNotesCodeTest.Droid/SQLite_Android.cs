using System;
using System.IO;
using MusicNotesCodeTest.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace MusicNotesCodeTest.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android()
		{
		}

		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "SQLite.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, sqliteFilename);

			var conn = new SQLite.SQLiteConnection(path);

			return conn;
		}

	}
}
