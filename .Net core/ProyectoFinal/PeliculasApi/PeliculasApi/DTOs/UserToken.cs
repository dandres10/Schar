namespace PeliculasApi.DTOs
{
    using System;

    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}