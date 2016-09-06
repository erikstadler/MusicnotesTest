using MusicNotesCodeTest.code.view;
using Xamarin.Forms;

namespace MusicNotesCodeTest
{
    public class App : Application
    {
		static SongService songService;

        public App()
        {
            MainPage = new MainMasterDetailPage();
        }

		public static SongService SongService
		{
			get
			{
				if (songService == null)
				{
					songService = new SongService();
				}
				return songService;
			}
		}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
