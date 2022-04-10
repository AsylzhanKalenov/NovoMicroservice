using System;

namespace ApiGateway.Models
{
    [Serializable]
    public class LoginResponse
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }
}
