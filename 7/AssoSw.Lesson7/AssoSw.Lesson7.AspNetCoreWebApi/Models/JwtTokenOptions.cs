namespace AssoSw.Lesson7.AspNetCoreWebApi.Models
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;

        public string SigningKey { get; set; } = null!;
    }
}
