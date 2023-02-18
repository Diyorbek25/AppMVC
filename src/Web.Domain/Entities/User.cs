using AppMVC.Domain.Enums;

namespace AppMVC.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public Role UserRole { get; set; }

    public ICollection<ProductAudit> ProductAudits { get; set; }
}
