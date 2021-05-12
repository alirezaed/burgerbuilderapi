using BurgerBuilder.WebApi.DataModel;
using BurgerBuilder.WebApi.Enumeration;
using BurgerBuilder.WebApi.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerBuilder.WebApi.Mapping
{
	public static class OrderMapper
	{
		#region ToDateModel
		public static OrderDataModel ToDataModel(this AddOrderViewModel addOrderViewModel)
		{
			return new OrderDataModel
			{
				Cheese = addOrderViewModel.cheese,
				Comment = "",
				CreateDate = DateTime.Now,
				Meat = addOrderViewModel.meat,
				Rate = 0,
				Salad = addOrderViewModel.salad,
				Status = Enumeration.OrderStatus.Pending,
				TotalPrice = addOrderViewModel.total_price,
				UserId = 0
			};

		}
		#endregion

		#region ToViewModel
		public static OrderViewModel ToViewModel(this OrderDataModel orderDataModel)
		{
			return new OrderViewModel
			{
				cheese = orderDataModel.Cheese,
				comment = orderDataModel.Comment,
				create_date = orderDataModel.CreateDate,
				meat = orderDataModel.Meat,
				rate = orderDataModel.Rate,
				salad = orderDataModel.Salad,
				status = Enum.GetName(typeof(OrderStatus), ((OrderStatus)orderDataModel.Status)),
				total_price = orderDataModel.TotalPrice,
				order_number = orderDataModel.Id
			};
		}
		public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<OrderDataModel> orderDataModel)
		{
			return orderDataModel.Select(c => c.ToViewModel());
		}
		#endregion
	}
}