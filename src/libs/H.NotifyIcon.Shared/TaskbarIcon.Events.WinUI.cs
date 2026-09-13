#if HAS_WINUI
#nullable enable

namespace H.NotifyIcon
{
    public partial class TaskbarIcon
    {
        /// <summary>
        /// Occurs when the second-window context menu is opened.
        /// </summary>
        public event global::System.EventHandler? SecondWindowContextMenuOpened;

        /// <summary>
        /// A helper method to subscribe the SecondWindowContextMenuOpened event.
        /// </summary>
        public global::System.IDisposable SubscribeToSecondWindowContextMenuOpened(global::System.EventHandler handler)
        {
            SecondWindowContextMenuOpened += handler;

            return new global::H.NotifyIcon.EventSubscription(() => SecondWindowContextMenuOpened -= handler);
        }

        /// <summary>
        /// A helper method to raise the SecondWindowContextMenuOpened event.
        /// </summary>
        protected virtual global::System.EventArgs OnSecondWindowContextMenuOpened()
        {
            var args = new global::System.EventArgs();
            SecondWindowContextMenuOpened?.Invoke(this, args);

            return args;
        }
    }
}
#endif
