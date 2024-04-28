namespace Backend_TeaTech.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string userEmail);
    }
}
