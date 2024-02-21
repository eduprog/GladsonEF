namespace GladsonEF.Domain;

public class DocumentType : Entity
{
    protected DocumentType() { }
    public DocumentType(string name, bool showInAppDesktop, bool showInAppMobile, bool showInAppWeb, int companyBusinessId)
    {
        Name = new Name(name);
        ShowInAppDesktop = showInAppDesktop;
        ShowInAppMobile = showInAppMobile;
        ShowInAppWeb = showInAppWeb;
        CompanyBusinessId = companyBusinessId;
    }
    public Name Name { get; private set; }
    public bool ShowInAppDesktop { get; private set; }
    public bool ShowInAppMobile { get; private set; }
    public bool ShowInAppWeb { get; private set; }
    public int CompanyBusinessId { get; private set; }
}