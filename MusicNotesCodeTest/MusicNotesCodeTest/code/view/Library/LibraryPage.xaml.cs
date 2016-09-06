using System.Collections.Generic;
using System.Collections.ObjectModel;
using MusicNotesCodeTest.code.model.Library;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.view.Library
{
    public partial class LibraryPage : ContentPage
    {
		
        public LibraryPage()
        {
			InitializeComponent();

			listView.ItemSelected += onItemSelected;

			List<SongViewModel> viewModels = new List<SongViewModel>();
			foreach (Song aSong in App.SongService.Songs)
			{
				viewModels.Add(new SongViewModel(aSong));
			}

			ObservableCollection<SongViewModel> observedSongList = new ObservableCollection<SongViewModel>(viewModels);
			listView.ItemsSource = observedSongList;
        }

		async void onItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				SongViewModel songViewModel = e.SelectedItem as SongViewModel;

				songViewModel.Views++;

				App.SongService.SaveSongToDB(songViewModel.song);

				var songPage = new SongPage();
				songPage.BindingContext = songViewModel.song;
				await Navigation.PushAsync(songPage);

				((ListView)sender).SelectedItem = null;
			}
		}

    }
}
