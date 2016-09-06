using System;
using MusicNotesCodeTest.code.model.Library;

namespace MusicNotesCodeTest
{
	public class SongViewModel : BaseViewModel
	{
		public readonly Song song;

		public SongViewModel(Song song)
		{
			this.song = song;
		}

		public int Views
		{
			get { return song.views; }
			set { this.song.views = value; this.NotifyPropertyChanged("Subtitle"); }
		}

		public string Title
		{
			get { return song.title; }
		}

		public string Subtitle { get { return "Artist: " + song.artist + " | View Count: " + song.views + " | Pages: " + song.pages; } }

	}
}
