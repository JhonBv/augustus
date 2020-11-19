using amartindemo.models.MappedModels;
using System.Collections.Generic;

namespace amartindemo.models.ResponseModels
{
    public class UserDetailResponseModel
    {
        public User user { get; set; }
        public List<Post> userPosts { get; set; }
    }
}
