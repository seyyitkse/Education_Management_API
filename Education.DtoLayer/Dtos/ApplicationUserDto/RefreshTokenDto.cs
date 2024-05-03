namespace Education.DtoLayer.Dtos.ApplicationUserDto
{
    public class RefreshTokenDto
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
