using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerBuilder.WebApi.DataModel
{
	public class UserDataModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public DateTime CreateDate { get; set; }
		public bool Confirmed { get; set; }
	}
}