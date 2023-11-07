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

    public IReadOnlyCollection<Subscription> Subscriptions { get; private set; }

    public void Update(string name)
    {
        Name = name;
        UpdatedAt = DateTime.Now;
    }
    
    public void AddSubscription(Subscription subscription)
    {
        if (Subscriptions.Contains(subscription)) throw new Exception("A assinatura já existe");

        var subscriptions = Subscriptions.ToList();
        subscriptions.Add(subscription);
        Subscriptions = subscriptions;
    }

    public void RemoveSubscription(Subscription subscription)
    {
        if (!Subscriptions.Contains(subscription)) throw new Exception("A assinatura informada não existe");

        var subscriptions = Subscriptions.ToList();
        subscriptions.Remove(subscription);
        Subscriptions = subscriptions;
    }
}
