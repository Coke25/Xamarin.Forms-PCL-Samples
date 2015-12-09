using System;
using Xamarin.Forms;

namespace SamplesPCL
{
	public class CheckBox:Button
	{
		public static readonly BindableProperty CheckImageProperty = 
			BindableProperty.Create<CheckBox,FileImageSource>(
				prop=>prop.Image,(FileImageSource)ImageSource.FromFile("Checked_Black.png"),
				propertyChanged:(bindable,oldvalue,newvalue)=>
				{
					CheckBox checkBox = (CheckBox)bindable;
					if(checkBox.IsChecked){
						checkBox.Image = newvalue;
					}
				}
			);

		public FileImageSource CheckedImage
		{
			get {
				return (FileImageSource)GetValue(CheckImageProperty);
			}
			set {
				SetValue (CheckImageProperty, value);
			}
		}
		public static readonly BindableProperty UnCheckImageProperty = 
			BindableProperty.Create<CheckBox,FileImageSource>(
				prop=>prop.Image,(FileImageSource)ImageSource.FromFile("Unchecked_Black.png"),
				propertyChanged:(bindable,oldvalue,newvalue)=>
				{
					CheckBox checkBox = (CheckBox)bindable;
					if(!checkBox.IsChecked){
						checkBox.Image = newvalue;
					}
				}
			);

		public FileImageSource UnCheckedImage
		{
			get {
				return (FileImageSource)GetValue(UnCheckImageProperty);
			}
			set {
				SetValue (UnCheckImageProperty, value);
			}
		}
		public static readonly BindableProperty IsCheckedProperty = 
			BindableProperty.Create<CheckBox,Boolean>(
				prop=>prop.IsChecked,false,
				propertyChanged:(bindable,oldvalue,newvalue)=>
				{
					CheckBox checkBox = (CheckBox)bindable;

				}
			);

		public Boolean IsChecked
		{
			get {
				return (Boolean)GetValue(IsCheckedProperty);
			}
			set {
				SetValue (IsCheckedProperty, value);
				this.Image = value ? CheckedImage : UnCheckedImage;
			}
		}

		public CheckBox ()
		{
			this.Clicked += toggleCheckBox;
			Image = IsChecked ? CheckedImage : UnCheckedImage;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			VerticalOptions = LayoutOptions.FillAndExpand;
		}
		void toggleCheckBox(object o,EventArgs e){
			var checkbox = (CheckBox)o;
			checkbox.IsChecked = !checkbox.IsChecked;
		}
	}
}

