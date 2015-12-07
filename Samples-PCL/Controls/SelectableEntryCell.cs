using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SamplesPCL
{
	public class SelectableEntryCell:ViewCell
	{
		public Picker picker;
		public Entry entry;
		public StackLayout pickerStacklayout;
		public StackLayout entryStacklayout;

		public SelectableEntryCell (List<string> pickerItems,string labelText)
		{	
			Grid grid = new Grid {
				Padding = new Thickness (0, 1, 1, 1),
				RowSpacing = 1,
				ColumnSpacing = 3,		
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (30, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (10, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (40, GridUnitType.Absolute) }
				}
			};
			var label = new Label { 
				Text=labelText,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions=LayoutOptions.CenterAndExpand
			};
			grid.Children.Add (label,1,2,0,1);
			picker = new Picker{
				HorizontalOptions=LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};
			foreach (var i in pickerItems) {
				picker.Items.Add (i);
			}
			picker.SelectedIndexChanged += selectedIndexChanged;
			pickerStacklayout = new StackLayout{ Padding = new Thickness (10, 5, 10, 5),Children={picker} };
			pickerStacklayout.IsVisible = false;
			grid.Children.Add (pickerStacklayout, 2, 3, 0, 1);

			entry = new Entry {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent,
				TextColor = Color.White
			};
			entryStacklayout = new StackLayout{ Padding = new Thickness (10, 5, 10, 5), Children = { entry } };
			grid.Children.Add (entryStacklayout,2,3,0,1);

			var showPickerViewButton = new Button {
				Image="Account.png",
				VerticalOptions=LayoutOptions.CenterAndExpand
			};
			showPickerViewButton.Clicked += showPickerView;
			grid.Children.Add (showPickerViewButton, 3, 4, 0, 1);
			View = grid;
		}
		void showPickerView(object sender,EventArgs e){
			picker.Focus ();
			//entryStacklayout.IsVisible = false;
		}
		void selectedIndexChanged(object sender,EventArgs e){
			entry.Text = picker.Items [picker.SelectedIndex];
			entryStacklayout.IsVisible = true;
		}

	}
}

