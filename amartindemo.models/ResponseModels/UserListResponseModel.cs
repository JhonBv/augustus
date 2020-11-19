namespace amartindemo.models.ResponseModels
{
    /// <summary>
    /// Jhon B. This model represents what the client will view. The name of the user, username and the count of posts for the user.
    /// This is similar to a Domain Model (as in the business domain, it is required that the Model represents the information requested in the requirements).
    /// </summary>
    public class UserListResponseModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public int PostCount { get; set; }
    }
}
