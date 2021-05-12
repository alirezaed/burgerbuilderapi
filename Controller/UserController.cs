using BurgerBuilder.WebApi.Core.Repository;
using BurgerBuilder.WebApi.ViewModels.Order;
using BurgerBuilder.WebApi.ViewModels.User;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BurgerBuilder.WebApi.Controller
{
	[EnableCors(origins: "http://localhost:3000,http://demo.BurgerBuilder.com,http://www.BurgerBuilder.com,http://www.BurgerBuilder.ir,http://www.joybarhotel.com,http://www.joybarhotel.ir,http://www.joybarboutiquehotel.com,http://www.joybarboutiquehotel.ir,http://BurgerBuilder.com,http://BurgerBuilder.ir,http://joybarhotel.com,http://joybarhotel.ir,http://joybarboutiquehotel.com,http://joybarboutiquehotel.ir", headers: "*", methods: "*")]
	public class UserController : ApiController
	{
		UserRepository userRepository;
		
		public UserController()
		{
			userRepository = new UserRepository();
		}

		#region User
		[HttpPost]
		public HttpResponseMessage Login(LoginViewModel loginViewModel)
		{
			var result = new LoginStatusViewModel();
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}
		[HttpPost]
		public HttpResponseMessage SingUp(SingUpViewModel singUpViewModel)
		{
			var result = new SingUpStatusViewModel();
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}
		[HttpPost]
		public HttpResponseMessage Singin(SingUpViewModel singinViewModel)
		{
			var result = new SingUpStatusViewModel();
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}
		#endregion
	}
}