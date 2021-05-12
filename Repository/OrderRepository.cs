using BurgerBuilder.WebApi.Repository;
using BurgerBuilder.WebApi.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace BurgerBuilder.WebApi.Core.Repository
{
	public class OrderRepository : BaseRepository<OrderDataModel>
	{
		public new int Insert(OrderDataModel orderDataModel)
		{
			base.Insert(orderDataModel);
			return base.GetQueryInt("SELECT MAX(Id) FROM brg_Orders");
		}
		public List<OrderDataModel> GetAll(string sortField)
		{
			return base.Find(c => c.Where($"1=1").OrderBy($"{sortField}")).ToList();
		}
	}
}