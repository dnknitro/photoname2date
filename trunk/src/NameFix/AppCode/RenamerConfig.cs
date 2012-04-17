using System.ComponentModel;

namespace NameFix.AppCode
{
	[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
	public class RenamerConfig /* : INotifyPropertyChanged*/
	{
		private string _extentions = "";
		private string _path = "";
		private bool _recurseSubdirs = true;
		private int _shiftTimeByHours;
		private bool _touch = true;
		public event PropertyChangedEventHandler PropertyChanged;

		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public string Path
		{
			get {return _path;}
			set
			{
				_path = value;
				if(PropertyChanged != null)
				{
					//PropertyChanged(this, new PropertyChangedEventArgs("Path"));
				}
			}
		}

		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public string Extentions
		{
			get {return _extentions;}
			set
			{
				_extentions = value;
				if(PropertyChanged != null)
				{
					//PropertyChanged(this, new PropertyChangedEventArgs("Extentions"));
				}
			}
		}

		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public bool RecurseSubdirs
		{
			get {return _recurseSubdirs;}
			set
			{
				_recurseSubdirs = value;
				if(PropertyChanged != null)
				{
					//PropertyChanged(this, new PropertyChangedEventArgs("RecurseSubdirs"));
				}
			}
		}

		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public bool Touch
		{
			get {return _touch;}
			set
			{
				_touch = value;
				if(PropertyChanged != null)
				{
					//PropertyChanged(this, new PropertyChangedEventArgs("Touch"));
				}
			}
		}

		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public int ShiftTimeByHours
		{
			get {return _shiftTimeByHours;}
			set
			{
				_shiftTimeByHours = value;
				if(PropertyChanged != null)
				{
					//PropertyChanged(this, new PropertyChangedEventArgs("ShiftTimeByHours"));
				}
			}
		}
	}
}