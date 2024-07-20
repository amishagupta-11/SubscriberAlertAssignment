namespace SubscriberAlertAssignment
{
    /// <summary>
    /// Provides event data for a notification with message content and timestamp.
    /// </summary>
    public class NotificationEventArgs : EventArgs
    {
        public string Message { get; }
        public DateTime Timestamp { get; }

        public NotificationEventArgs(string message)
        {
            Message = message;
            Timestamp = DateTime.Now;
        }
    }
}
