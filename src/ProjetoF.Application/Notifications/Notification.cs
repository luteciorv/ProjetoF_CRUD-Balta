using MediatR;

namespace ProjetoF.Application.Notifications
{
    public class Notification : INotification
    {
        public Notification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            TimeOccurred = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; set; }
        public DateTime TimeOccurred { get; private set; }
    }
}
