namespace GladsonEF.Middleware;

public interface ICurrentUser
{
    Guid GetUserId();
    string GetUserEmail();
    string GetTenant();
}