using System.Collections.Generic;
using System.Linq;
using MusicNotesCodeTest.code.model.Library;
using SQLite;
using Xamarin.Forms;

namespace MusicNotesCodeTest
{
	public class SongRepository
	{
		static object synchronizer = new object();
		SQLiteConnection database;

		public SongRepository()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			database.CreateTable<Song>();
		}
		public IEnumerable<Song> GetItems()
		{
			lock (synchronizer)
			{
				return (from i in database.Table<Song>() select i).ToList();
			}
		}

		public Song GetItem(string id)
		{
			lock (synchronizer)
			{
				return database.Table<Song>().FirstOrDefault(x => x.id == id);
			}
		}

		public int SaveItem(Song item)
		{
			lock (synchronizer)
			{
				if (string.IsNullOrWhiteSpace(item.id))
				{
					return database.Insert(item);
				}
				else {
					return database.Update(item);
				}
			}
		}

		public int InsertItem(Song item)
		{
			lock (synchronizer)
			{
				return database.Insert(item);
			}
		}

		public int DeleteItem(string id)
		{
			lock (synchronizer)
			{
				return database.Delete<Song>(id);
			}
		}
	}
}
