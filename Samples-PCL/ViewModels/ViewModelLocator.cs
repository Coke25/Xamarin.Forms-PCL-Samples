using System;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace SamplesPCL
{
	public class ViewModelLocator 
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<HomeViewModel>();
			SimpleIoc.Default.Register<TableViewExViewModel> ();
			SimpleIoc.Default.Register<ListViewExViewModel> ();
		}

		/// <summary>
		/// Gets the Main property.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
			"CA1822:MarkMembersAsStatic",
			Justification = "This non-static member is needed for data binding purposes.")]
		public HomeViewModel Home
		{
			get
			{
				return ServiceLocator.Current.GetInstance<HomeViewModel>();
			}
		}
		public TableViewExViewModel TableViewEx
		{
			get
			{
				return ServiceLocator.Current.GetInstance<TableViewExViewModel>();
			}
		}
		public ListViewExViewModel ListViewEx
		{
			get
			{
				return ServiceLocator.Current.GetInstance<ListViewExViewModel>();
			}
		}
	}
}


