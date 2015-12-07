using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace SamplesPCL
{
	public class NavigationViewCell:ViewCell
	{
		public static readonly BindableProperty TextProperty = 
			BindableProperty.Create<NavigationViewCell,string>(
				prop=>prop.Text,string.Empty,
				propertyChanged:(bindable,oldvalue,newvalue)=>
				{
					NavigationViewCell cell = (NavigationViewCell)bindable;
					cell.label.Text = newvalue;
				}
			);

		public string Text
		{
			get {
				return (string)GetValue(TextProperty);
			}
			set {
				SetValue (TextProperty, value);
			}
		}

		public static readonly BindableProperty CommandProperty = 
			BindableProperty.Create<NavigationViewCell,ICommand>(
				prop=>prop.Command,default(ICommand),
				propertyChanged:(bindable,oldvalue,newvalue)=>
				{
					NavigationViewCell cell = (NavigationViewCell)bindable;
					cell.button.Command = newvalue;
				}
			);

		public ICommand Command
		{
			get {
				return (Command)GetValue(CommandProperty);
			}
			set {
				SetValue (CommandProperty, value);
				if (button != null) {
					button.Command = value;
				}
			}
		}
		public static readonly BindableProperty CommandParameterProperty = 
			BindableProperty.Create<NavigationViewCell,object>(prop=>prop.CommandParameter,default(object),
				propertyChanged:(bindable,oldvalue,newvalue)=>
				{
					NavigationViewCell cell = (NavigationViewCell)bindable;
					cell.button.CommandParameter = newvalue;
				}
			);
		public object CommandParameter
		{
			get {return (object)GetValue(CommandParameterProperty);}
			set {SetValue (CommandParameterProperty, value);}
		}
		Button button;
		Label label;
		public NavigationViewCell ()
		{								
			Grid grid = new Grid {
				Padding = new Thickness (0, 1, 1, 1),
				RowSpacing = 1,
				ColumnSpacing = 2,		
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (30, GridUnitType.Auto)}
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (25, GridUnitType.Auto) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) }
				}
			};

			label = new Label () {
				FontSize = 16,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.Black
			};
			grid.Children.Add (label, 0, 0);

			var image = new Image (){ 
				Source = ImageSource.FromFile("Arrow_Right.png"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions=LayoutOptions.End
			};
			grid.Children.Add (image,1,0);

			button = new Button (){ 
				BackgroundColor = Color.Transparent,
				VerticalOptions =  LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};				button.Command = Command;

			if (Command != null && Command.CanExecute(CommandProperty)) {
			}
			//if (CommandParameter != null) {
			//		button.CommandParameter = CommandParameter;
			//		}
			grid.Children.Add (button, 0, 2, 0, 1);
			var layout = new StackLayout (){ 
				Padding=new Thickness(15,0,15,0),
				Children={
					grid
				}
			};
			//OnTapped += 
			View = layout;
		}

	}
}

