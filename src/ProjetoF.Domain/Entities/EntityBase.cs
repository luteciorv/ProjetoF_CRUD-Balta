namespace ProjetoF.Domain.Entities;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Enabled = true;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; protected set; }

    public bool Enabled { get; set; }
    public DateTime? DeletedAt { get; protected set; }

    public void Delete()
    {
        Enabled = false;
        DeletedAt = DateTime.Now;
    }
}
