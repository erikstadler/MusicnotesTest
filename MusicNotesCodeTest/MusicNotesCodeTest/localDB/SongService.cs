using System.Collections.Generic;
using MusicNotesCodeTest.code.model.Library;
using System.Linq;

namespace MusicNotesCodeTest
{
	public class SongService
	{
		SongRepository songRepository;

		public SongService()
		{
			songRepository = new SongRepository();

			IEnumerable<Song> songs = songRepository.GetItems();

			// No songs in local db?  No problem!
			if (songs.Count() == 0)
			{
				songs = this.createNewDatabaseFromXML();
			}

		}

		public IEnumerable<Song> Songs
		{
			get
			{
				return songRepository.GetItems();
			}
		}

		public int SaveSongToDB(Song song)
		{
			return songRepository.SaveItem(song);
		}

		private IEnumerable<Song> createNewDatabaseFromXML()
		{
			List<Song> defaultSongs = Song.parseXMLFile("MusicNotesCodeTest.localDB.songs.xml");
			foreach (Song aSong in defaultSongs)
			{
				songRepository.InsertItem(aSong);
			}
			return defaultSongs;
		}

	}
}
