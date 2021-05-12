using BurgerBuilder.WebApi.Core.Repository;
using BurgerBuilder.WebApi.Mapping;
using BurgerBuilder.WebApi.ViewModels.Order;
using BurgerBuilder.WebApi.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BurgerBuilder.WebApi.Controller
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class OrderController : ApiController
	{
		OrderRepository orderRepository;
		
		public OrderController()
		{
			orderRepository = new OrderRepository();
		}

		#region Burger
		[HttpPost]
		public HttpResponseMessage AddOrder(AddOrderViewModel	 addOrderViewModel)
		{
			AddOrderResultViewModel result;
			try
			{
				if (addOrderViewModel.total_price + addOrderViewModel.meat + addOrderViewModel.cheese + addOrderViewModel.salad + addOrderViewModel.salad == 0)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest,"input is not correct");
				}
				
				if (5000 + addOrderViewModel.meat * 5000 + addOrderViewModel.salad * 2000 + addOrderViewModel.cheese * 4000 != addOrderViewModel.total_price)
				{
					result = new AddOrderResultViewModel
					{
						status = false,
						message = "total price is incorrect"
					};
					return Request.CreateResponse(HttpStatusCode.OK, result);
				}
				var datamodel = addOrderViewModel.ToDataModel();
				if (true) /*validate token*/
				{
					datamodel.UserId = 0;
				};
				
				int orderNumber = orderRepository.Insert(datamodel);
				result = new AddOrderResultViewModel
				{
					order_number = orderNumber,
					status = true,
					message = "successfully added"
				};
			}
			catch (Exception ex)
			{
				result = new AddOrderResultViewModel
				{
					status = false,
					message = "error on add order : " + ex.Message
				};
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}
		[HttpPost]
		public HttpResponseMessage GetAllOrders(GetAllOrdersViewModel getAllOrdersViewModel)
		{
			var result = orderRepository.GetAll(getAllOrdersViewModel.sort_field).ToViewModel();
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}
		#endregion
	}
}