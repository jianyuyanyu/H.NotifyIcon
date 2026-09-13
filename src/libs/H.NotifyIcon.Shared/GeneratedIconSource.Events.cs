#nullable enable

namespace H.NotifyIcon
{
    internal sealed class EventSubscription : global::System.IDisposable
    {
        private readonly global::System.Action action;

        public EventSubscription(global::System.Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            action();
        }
    }

    public partial class GeneratedIconSource
    {
        /// <summary>
        /// Occured when any dependency property was changed
        /// </summary>
        public event global::System.EventHandler? DependencyPropertyChanged;

        /// <summary>
        /// A helper method to subscribe the DependencyPropertyChanged event.
        /// </summary>
        public global::System.IDisposable SubscribeToDependencyPropertyChanged(global::System.EventHandler handler)
        {
            DependencyPropertyChanged += handler;

            return new global::H.NotifyIcon.EventSubscription(() => DependencyPropertyChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the DependencyPropertyChanged event.
        /// </summary>
        private global::System.EventArgs OnDependencyPropertyChanged()
        {
            var args = new global::System.EventArgs();
            DependencyPropertyChanged?.Invoke(this, args);

            return args;
        }
    }
}
