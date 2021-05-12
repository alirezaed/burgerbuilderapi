using BurgerBuilder.WebApi.Repository;
using BurgerBuilder.WebApi.DataModel;

namespace BurgerBuilder.WebApi.Core.Repository
{
	public class UserRepository : BaseRepository<UserDataModel>
	{
		public UserDataModel GetUser()
		{
			return base.Get(new UserDataModel { Id = 1 });
		}

	}
}