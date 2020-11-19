using amartindemo.models.MappedModels;
using amartindemo.proxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amartindemo.Services
{
    /// <summary>
    /// Jhon B. This is the Proxy Service which defines the way the cliend consumes the JsonPlaceholder API.
    /// The mapping is similar in terms of methods and signatures but it can be extended to be used by a Factory to buld custom responses
    /// which might not be avaliable from the TargetEndpoint.
    /// </summary>
    public class ProxyService : IProxyService
    {
        private readonly ITargetEndPoint _endpoint;

        public ProxyService(ITargetEndPoint endpoint)
        {
            _endpoint = endpoint;
        }
        public async Task<List<User>> GetUsers()
        {
            var userJson = await _endpoint.Users();

            var jsonResponse = JsonConvert.DeserializeObject<List<User>>(userJson);
            return jsonResponse;
        }
        /// <summary>
        /// Jhon B. Get a user by Id. Notice I am not using Exception Handling here as this is already been enabled in the TargetEndPoint,
        /// so I did not think it is necessary as it would just be repeating the code ;)
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>User Model with post details</returns>
        public async Task<Object> GetUserById(int userId)
        {
            return await _endpoint.UserById(userId);
        }
        public async Task<List<Post>> GetPosts()
        {
            var jsonResponse = await _endpoint.Posts();
            return jsonResponse;
        }
        /// <summary>
        /// Jhon B. Get a list of Posts for a given user by passing userId.
        /// As in the previous comment, I didnt think there is a need to do extra exception handling as it is already done at TargetEndPoint.
        /// However, if I wished to transform the Error response I can also handle it here, however, I will leave that to the API controller.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetPostsByUserId(int userId)
        {
            return await _endpoint.PostsByUserId(userId);
        }
    }
}
