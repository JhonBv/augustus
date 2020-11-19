using amartindemo.models.MappedModels;
using amartindemo.models.ResponseModels;
using amartindemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amartindemo.Factories
{
    /// <summary>
    /// Jhon B. This class is responsible for building the User responses we wnat the API controller to return to the Client App.
    /// It liaises directly with the ProxyService adding further shielding the consuming client from back-end changes.
    /// </summary>
    public class UserFactory : IUserFactory
    {
        private readonly IProxyService _proxy;

        public UserFactory(IProxyService proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Jhon B. Could have been done in a more elegant manner however the response is a UserList with custom fields
        /// which will be presented in the Client App (website)
        /// </summary>
        /// <returns>List<UserListResponseModel></returns>
        public async Task<List<UserListResponseModel>> BuildUsersResponse()
        {
            var users = await _proxy.GetUsers();
            var posts = await _proxy.GetPosts();
            List<UserListResponseModel> requestedUsers = new List<UserListResponseModel>();
            foreach (var u in users)
            {

                UserListResponseModel model = new UserListResponseModel
                {
                    id = u.Id,
                    Name = u.Name,
                    UserName = u.UserName,
                    PostCount = posts.Where(i => i.UserId.Equals(u.Id)).ToList<Post>().Count
                };
                requestedUsers.Add(model);
            }
            return requestedUsers;
        }
        /// <summary>
        /// Jhon B.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>UserDetailResponseModel</returns>
        public async Task<UserDetailResponseModel> BuildUserDetail(int userId)
        {

            var user = await _proxy.GetUserById(userId);
            var posts = await _proxy.GetPostsByUserId(userId);
            UserDetailResponseModel model = new UserDetailResponseModel();
            if (user != null)
            {
                model = new UserDetailResponseModel
                {
                    user = (User)user,
                    userPosts = posts
                };
            }
            return model;
        }
    }
}
