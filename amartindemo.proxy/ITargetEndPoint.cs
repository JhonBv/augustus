using amartindemo.models.MappedModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amartindemo.proxy
{
    public interface ITargetEndPoint
    {
        Task<string> Users();

        Task<Object> UserById(int userId);
        Task<List<Post>> Posts();
        Task<List<Post>> PostsByUserId(int userId);
    }
}