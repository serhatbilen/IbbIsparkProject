using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerhatBilenIBB_TestApp.Models
{
	public class LoginViewModel
	{
		[Display(Name ="Kullanıcı Adı")]
		[Required(ErrorMessage ="Kullanıcı adı alanı boş bırakılamaz")]
        public string KullaniciAdi { get; set; }
		[Display(Name = "Parola")]
		[Required(ErrorMessage = "Parola alanı boş bırakılamaz")]
		[DataType(DataType.Password)]
		public string Parola { get; set; }
	}
}