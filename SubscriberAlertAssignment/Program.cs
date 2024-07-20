namespace SubscriberAlertAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            FacebookPublisher publisher = new ();

            // Subscribe to notifications using Action delegate.
            Action<NotificationEventArgs> subscriber1 = (e) =>
            {
                Console.WriteLine($"Subscriber 1 received notification: '{e.Message}' at {e.Timestamp}");
            };

            Action<NotificationEventArgs> subscriber2 = (e) =>
            {
                Console.WriteLine($"Subscriber 2 received notification: '{e.Message}' at {e.Timestamp}");
            };

            publisher.Subscribe(subscriber1);
            publisher.Subscribe(subscriber2);

            // Publish notifications
            publisher.PublishNotification("Hello subscribers! We are hosting a worldwide social media influencer competition.Don't miss this opportunity—register as soon as possible");

            // Unsubscribe one subscriber
            publisher.Unsubscribe(subscriber1);

            // Publish another notification
            publisher.PublishNotification("Big Day coming Soon!!! Less than 4 days to go... Register soon!");

            // Trying to unsubscribe a non-subscribed subscriber
            publisher.Unsubscribe(subscriber1); 

            // Publish a notification with no subscribers
            publisher.Unsubscribe(subscriber2);
            publisher.PublishNotification("Influencers get ready to show case your talent! See you there");

            Console.ReadLine();
        }
    }
}
