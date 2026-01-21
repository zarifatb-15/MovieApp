namespace MovieApp.DAL.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
}

public class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdateAt { get; set; }
}