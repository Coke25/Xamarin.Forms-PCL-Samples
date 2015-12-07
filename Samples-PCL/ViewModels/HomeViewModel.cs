using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SamplesPCL
{
	public class HomeViewModel :ViewModelBase
	{
		/// <summary>
		/// The <see cref="ClickCount" /> property's name.
		/// </summary>
		public const string ClickCountPropertyName = "ClickCount";

		#region properties
		private int _clickCount;

		/// <summary>
		/// Sets and gets the ClickCount property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int ClickCount
		{
			get
			{
				return _clickCount;
			}
			set
			{
				if (Set(() => ClickCount, ref _clickCount, value))
				{
					RaisePropertyChanged(() => ClickCountFormatted);
				}
			}
		}

		public string ClickCountFormatted
		{
			get
			{
				return string.Format("The button was clicked {0} time(s)", ClickCount);
			}
		}

		private RelayCommand _incrementCommand;

		/// <summary>
		/// Gets the IncrementCommand.
		/// </summary>
		public RelayCommand IncrementCommand
		{
			get
			{
				return _incrementCommand
					?? (_incrementCommand = new RelayCommand(
						() =>
						{
							ClickCount++;
						}));
			}
		}
		//Placeholder --> Will add Navigation Service later
		/*private RelayCommand<string> _navCommand = null;

		public RelayCommand<string> NavCommand
		{
			get
			{
				if (_navCommand == null) {
					_navCommand = new RelayCommand<string> ((item) => GoToPage (item),(item) => true);
				}
				return _navCommand;
			}
		}*/
		#endregion
		//Placeholder --> Will add Navigation Service later
		/*
		public async void GoToPage(string pageTag)
		{
			if (pageTag == "TableViewExample") {
			} 
		}*/
	}
}


