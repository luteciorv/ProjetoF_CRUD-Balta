namespace ProjetoF.Domain.Entities;

public class Student : EntityBase
{
    public Student(string name, string email)
    {
        Name = name;
        Email = email;

        Subscriptions = new List<Subscription>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }

    public ICollection<Subscription> Subscriptions { get; }

    public void Update(string name)
    {
        Name = name;
        UpdatedAt = DateTime.Now;
    }
}
