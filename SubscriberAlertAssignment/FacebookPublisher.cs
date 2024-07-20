namespace SubscriberAlertAssignment
{
    /// <summary>
    /// Manages subscribers and publishes notifications to registered subscribers.
    /// </summary>
    public class FacebookPublisher
    {
        private event Action<NotificationEventArgs>? NotificationEvent;
        private readonly List<Action<NotificationEventArgs>> subscribers = new List<Action<NotificationEventArgs>>();

        /// <summary>
        /// Subscribe a new action delegate to receive notifications.
        /// </summary>
        /// <param name="subscriber">The action delegate to subscribe.</param>
        public void Subscribe(Action<NotificationEventArgs> subscriber)
        {
            subscribers.Add(subscriber);
            NotificationEvent += subscriber;
        }

        /// <summary>
        /// Unsubscribe an action delegate from receiving notifications.
        /// </summary>
        /// <param name="subscriber">The action delegate to unsubscribe.</param>
        public void Unsubscribe(Action<NotificationEventArgs> subscriber)
        {
            if (subscribers.Remove(subscriber))
            {
                NotificationEvent -= subscriber;
            }
        }

        /// <summary>
        /// Publishes a notification to all registered subscribers.
        /// </summary>
        /// <param name="message">The message content of the notification.</param>
        public void PublishNotification(string message)
        {
            NotificationEventArgs args = new NotificationEventArgs(message);

            // Log when notification is sent
            LogNotificationSent(args);

            // Trigger the event
            OnNotification(args);
        }

        /// <summary>
        /// Invokes the NotificationEvent to notify all subscribers with the given event arguments.
        /// </summary>
        /// <param name="e">The NotificationEventArgs containing the notification details.</param>
        protected virtual void OnNotification(NotificationEventArgs e)
        {
            NotificationEvent?.Invoke(e);

            // If no subscribers, then it calls the method to display no subscribers. 
            if (NotificationEvent == null)
            {
                HandleNoSubscribers();
            }
        }

        /// <summary>
        /// Logs the details of the notification being sent.
        /// </summary>
        /// <param name="e">The NotificationEventArgs containing the notification details.</param>
        private static void LogNotificationSent(NotificationEventArgs e)
        {
            Console.WriteLine($"Notification sent: '{e.Message}' at {e.Timestamp}");
        }

        /// <summary>
        /// Handles the scenario where no subscribers are currently registered.
        /// </summary>
        private static void HandleNoSubscribers()
        {
            Console.WriteLine("No subscribers currently registered.");            
        }
    }
}
