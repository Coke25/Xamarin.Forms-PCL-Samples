using System;

using Xamarin.Forms;

namespace SamplesPCL
{
	public class App : Application
	{
		private static ViewModelLocator _locator;

		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}


		public static Page GetHomePage()
		{
			return new HomePage();
		}
		public App ()
		{
			// The root page of your application
			MainPage = new  NavigationPage(new HomePage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

