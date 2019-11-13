using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtOrderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static TshirtDatabase database;

        public static TshirtDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TshirtDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TShirtSQLite.db3"));
                }
                return database;
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
