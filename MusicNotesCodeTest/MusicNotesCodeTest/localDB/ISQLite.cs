using System;
using SQLite;

namespace MusicNotesCodeTest
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
