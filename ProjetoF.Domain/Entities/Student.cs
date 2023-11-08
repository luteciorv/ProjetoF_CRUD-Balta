using ProjetoF.Domain.Entities.Subscriptions;
using ProjetoF.Domain.Exceptions;
using System.Net;

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
        if (SubscriptionExists(subscription)) 
            throw new SubscriptionException($"{HttpStatusCode.BadRequest}", "A assinatura já existe", nameof(Student));

        if (IsInvalidPeriod(subscription.StartDate, subscription.EndDate)) 
            throw new SubscriptionException($"{HttpStatusCode.BadRequest}", "Já existe uma assinatura para o período informado", nameof(Student));

        var subscriptions = Subscriptions.ToList();
        subscriptions.Add(subscription);
        UpdatedAt = DateTime.Now;

        Subscriptions = subscriptions;
    }

    public void RemoveSubscription(Guid id)
    {
        var subscription = Subscriptions.FirstOrDefault(s => s.Id == id) 
            ?? throw new SubscriptionException($"{HttpStatusCode.NotFound}", "A assinatura informada não existe", nameof(Student));
        
        var subscriptions = Subscriptions.ToList();
        subscriptions.Remove(subscription);
        UpdatedAt = DateTime.Now;
        
        Subscriptions = subscriptions;
    }

    public bool SubscriptionExists(Subscription subscription) =>
        Subscriptions.Contains(subscription) || Subscriptions.Any(s => s.Id == subscription.Id);

    public bool IsInvalidPeriod(DateTime startDate, DateTime endDate) =>
        Subscriptions.Any(s => s.DatesBehind(startDate, endDate));
}
