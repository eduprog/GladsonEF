namespace GladsonEF.Middleware;

public class CurrentUser : ICurrentUser
{
    public Guid GetUserId()
    {
        return Guid.NewGuid();
    }

    public string GetUserEmail()
    {
        return "E-mail de teste";
    }

    public string GetTenant()
    {
        return "Tenant de teste";
    }
}