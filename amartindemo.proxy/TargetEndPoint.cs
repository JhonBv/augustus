using amartindemo.models.MappedModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace amartindemo.proxy
{
    /// <summary>
    /// Jhon B. This is the EndPoint Proxy responsible for direct communication with the API tom be integrated (jsonplaceholder)
    /// Keeping the proxy separate allows for easier manitenance as well as for easier porting (in case we want to use another service with similar data/functionality)
    /// </summary>
    public class TargetEndPoint : ITargetEndPoint
    {
        private readonly HttpClient _client;
        private readonly ILogger<TargetEndPoint> _logger;

       /*   Jhon B. In a production environment I would add the URL Below to a Configuration section in Azure and avoid keepiing it 
        *   in the code or in a local config file.
        *   See the resomendation: https://docs.microsoft.com/en-us/azure/azure-app-configuration/howto-labels-aspnet-core
        */

        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com/";
        public TargetEndPoint(HttpClient client, ILogger<TargetEndPoint> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<string> Users()
        {
            string responseJson = "";
            try
            {
                var httpResponse = await _client.GetAsync(_baseUrl + "users");
                responseJson = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}Exception has been raised when trying to fetch list of users {1}",ex.Message, DateTime.Now);
            }
            return responseJson;

        }

        public async Task<Object> UserById(int userId)
        {
            var user = new Object();
            try
            {
                var httpResponse = await _client.GetAsync(_baseUrl + "users");
                var responseJson = await httpResponse.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<List<User>>(responseJson).Where(i => i.Id == userId).ToList<User>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}Exception has been raised when trying to fetch {1} User ID: {2}", ex.Message, DateTime.Now, userId);
            }
            return user;
        }
        public async Task<List<Post>> Posts()
        {
            List<Post> postList = new List<Post>();
            var postresponse = await _client.GetAsync(_baseUrl + "posts");
            var responseJson = await postresponse.Content.ReadAsStringAsync();
            try
            {
                postList = JsonConvert.DeserializeObject<List<Post>>(responseJson);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}Exception has been raised when trying to fetch list of posts at {1}", ex.Message, DateTime.Now);
            }
            return postList;
        }

        public async Task<List<Post>> PostsByUserId(int userId)
        {
            List<Post> userPostList = new List<Post>();
            try
            {
                var postresponse = await _client.GetAsync(_baseUrl + "posts");
                var responseJson = await postresponse.Content.ReadAsStringAsync();
                userPostList = JsonConvert.DeserializeObject<List<Post>>(responseJson).Where(i => i.UserId == userId).ToList<Post>();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}Exception has been raised when trying to fetch list of posts belonging to User ID: {1}", ex.Message, DateTime.Now);
            }
            return userPostList;
        }

    }
}
