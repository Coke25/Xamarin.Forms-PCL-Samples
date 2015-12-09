using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SamplesPCL
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.Home;
			//tableViewNav.Clicked += GoToTableViewEx;
		}
	    async void GoToTableViewEx(object sender, EventArgs e){
			await Navigation.PushAsync(new TableViewEx());
		}
		/*async void GoToListViewEx(object sender, EventArgs e){
			await Navigation.PushAsync(new ListViewEx());
		}*/
	}
}

