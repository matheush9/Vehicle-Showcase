namespace VehicleShowcase.Application.DTOs.JwtToken
{
    public class JwtTokenResponseDto
    {
        public string accessToken { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public DateTime? IssuedAt { get; set; }
    }
}