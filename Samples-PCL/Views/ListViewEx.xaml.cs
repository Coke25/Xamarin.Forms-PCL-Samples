using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SamplesPCL
{
	public partial class ListViewEx : ContentPage
	{
		public ListViewEx ()
		{
			InitializeComponent ();
			//BindingContext = App.Locator.ListViewEx;
			listView.ItemsSource = new List<string> (new string[]{"Hi", "Hello"});
		}
	}
}

