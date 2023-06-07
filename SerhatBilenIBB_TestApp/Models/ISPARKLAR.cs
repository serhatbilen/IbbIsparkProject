using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SerhatBilenIBB_TestApp.Models
{
	public class ISPARKLAR : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		private int __id;
		private string _park_name;
		private string _location_name;
		private string _park_type_id;
		private string _park_type_desc;
		private int? _capacity_of_park;
		private string _working_time;
		private string _country_name;
		private decimal? _longitude;
		private decimal? _latitude;
		private Guid? _author;
		private DateTime? _updated;
		private string _Id;
		[Key]
		[Required]
		public int _id { get { return __id; } set { if (value != __id) { this.__id = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string park_name { get { return _park_name; } set { if (value != _park_name) { this._park_name = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string location_name { get { return _location_name; } set { if (value != _location_name) { this._location_name = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string park_type_id { get { return _park_type_id; } set { if (value != _park_type_id) { this._park_type_id = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string park_type_desc { get { return _park_type_desc; } set { if (value != _park_type_desc) { this._park_type_desc = value; NotifyPropertyChanged(); } } }
		public int? capacity_of_park { get { return _capacity_of_park; } set { if (value != _capacity_of_park) { this._capacity_of_park = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string working_time { get { return _working_time; } set { if (value != _working_time) { this._working_time = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string country_name { get { return _country_name; } set { if (value != _country_name) { this._country_name = value; NotifyPropertyChanged(); } } }
		public decimal? longitude { get { return _longitude; } set { if (value != _longitude) { this._longitude = value; NotifyPropertyChanged(); } } }
		public decimal? latitude { get { return _latitude; } set { if (value != _latitude) { this._latitude = value; NotifyPropertyChanged(); } } }
		public Guid? author { get { return _author; } set { if (value != _author) { this._author = value; NotifyPropertyChanged(); } } }
		public DateTime? updated { get { return _updated; } set { if (value != _updated) { this._updated = value; NotifyPropertyChanged(); } } }
		[MaxLength(500)]
		public string Id { get { return _Id; } set { if (value != _Id) { this._Id = value; NotifyPropertyChanged(); } } }
	}

}