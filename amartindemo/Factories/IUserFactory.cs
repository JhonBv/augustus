using amartindemo.models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amartindemo.Factories
{
    public interface IUserFactory
    {
        Task<UserDetailResponseModel> BuildUserDetail(int userId);
        Task<List<UserListResponseModel>> BuildUsersResponse();
    }
}
