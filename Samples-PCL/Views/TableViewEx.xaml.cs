using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SamplesPCL
{
	public partial class TableViewEx : ContentPage
	{
		public TableViewEx ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.TableViewEx;
		}
	}
}

