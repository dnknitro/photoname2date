using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PhotoName2Date.MiddleLayer {
	[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
	public class RenamerConfig/* : INotifyPropertyChanged*/ {

		private string _path = "";
		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public string Path {
			get { return _path; }
			set {
				_path = value;
				if (PropertyChanged != null) {
					//PropertyChanged(this, new PropertyChangedEventArgs("Path"));
				}
			}
		}

		private string _extentions = "";
		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public string Extentions {
			get { return _extentions; }
			set {
				_extentions = value;
				if (PropertyChanged != null) {
					//PropertyChanged(this, new PropertyChangedEventArgs("Extentions"));
				}
			}
		}

		private bool _recurseSubdirs = true;
		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public bool RecurseSubdirs {
			get { return _recurseSubdirs; }
			set {
				_recurseSubdirs = value;
				if (PropertyChanged != null) {
					//PropertyChanged(this, new PropertyChangedEventArgs("RecurseSubdirs"));
				}
			}
		}

		private bool _touch = true;
		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public bool Touch {
			get { return _touch; }
			set {
				_touch = value;
				if (PropertyChanged != null) {
					//PropertyChanged(this, new PropertyChangedEventArgs("Touch"));
				}
			}
		}

		private int _shiftTimeByHours = 0;
		[Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
		public int ShiftTimeByHours {
			get { return _shiftTimeByHours; }
			set {
				_shiftTimeByHours = value;
				if (PropertyChanged != null) {
					//PropertyChanged(this, new PropertyChangedEventArgs("ShiftTimeByHours"));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
