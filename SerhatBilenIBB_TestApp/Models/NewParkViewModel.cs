using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace SerhatBilenIBB_TestApp.Models
{
	public class NewParkViewModel
	{
        [Display(Name ="Park Adı")]
        [Required(ErrorMessage ="Park Adı Boş Bırakılamaz")]
        public string ParkAdi { get; set; }
		[Display(Name = "Lokasyon")]
		[Required(ErrorMessage = "Lokasyon Boş Bırakılamaz")]
		public string Lokasyon { get; set; }
		[Display(Name = "Park Tipi")]
		[Required(ErrorMessage = "Park Tipi Boş Bırakılamaz")]
		public string ParkTipi { get; set; }
		[Display(Name = "Kapasite")]
		[Required(ErrorMessage = "Kapasite Bilgisi Boş Bırakılamaz")]
		public int Kapasite { get; set; }
		[Display(Name = "Çalışma Saatleri")]
		[Required(ErrorMessage = "Çalışma Saat Bilgisi Boş Bırakılamaz")]
		public DateTime CalismiSaatleri { get; set; }
		[Display(Name = "İlçe")]
		[Required(ErrorMessage = "İlçe Bilgisi Boş Bırakılamaz")]
		public string Ilce { get; set; }
		[Display(Name = "Boylam")]
		[Required(ErrorMessage = "Boylam Bilgisi Boş Bırakılamaz")]
		public float Boylam { get; set; }
		[Display(Name = "Enlem")]
		[Required(ErrorMessage = "Enlem Bilgisi Boş Bırakılamaz")]
		public float Enlem { get; set; }
    }
}