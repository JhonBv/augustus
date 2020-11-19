using amartindemo.models.MappedModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amartindemo.Services
{
    public interface IProxyService
    {
        Task<List<User>> GetUsers();
        Task<Object> GetUserById(int userId);
        Task<List<Post>> GetPosts();
        Task<List<Post>> GetPostsByUserId(int userId);


    }
}
