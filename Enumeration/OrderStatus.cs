using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerBuilder.WebApi.Enumeration
{
	public enum OrderStatus
	{
		Pending = 1,
		Preparing = 2,
		ReadyToSend = 3,
		Sent = 4,
		Received = 5
	}
}