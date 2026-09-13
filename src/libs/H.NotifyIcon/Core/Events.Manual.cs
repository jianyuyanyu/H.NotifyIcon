
#pragma warning disable CA1034 // Preserve the public API formerly emitted by EventGenerator.

namespace H.NotifyIcon.Core
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
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class BalloonToolTipChangedEventArgs : global::System.EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public bool IsVisible { get; }

            /// <summary>
            ///
            /// </summary>
            public BalloonToolTipChangedEventArgs(bool isVisible)
            {
                IsVisible = isVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out bool isVisible)
            {
                isVisible = IsVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(IsVisible={IsVisible})";
            }
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class ChangeToolTipStateRequestEventArgs : global::System.EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public bool IsVisible { get; }

            /// <summary>
            ///
            /// </summary>
            public ChangeToolTipStateRequestEventArgs(bool isVisible)
            {
                IsVisible = isVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out bool isVisible)
            {
                isVisible = IsVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(IsVisible={IsVisible})";
            }
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class KeyboardEventReceivedEventArgs : global::System.EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public global::H.NotifyIcon.Core.KeyboardEvent KeyboardEvent { get; }

            /// <summary>
            ///
            /// </summary>
            public global::System.Drawing.Point Point { get; }

            /// <summary>
            ///
            /// </summary>
            public KeyboardEventReceivedEventArgs(global::H.NotifyIcon.Core.KeyboardEvent keyboardEvent, global::System.Drawing.Point point)
            {
                KeyboardEvent = keyboardEvent;
                Point = point;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out global::H.NotifyIcon.Core.KeyboardEvent keyboardEvent, out global::System.Drawing.Point point)
            {
                keyboardEvent = KeyboardEvent;
                point = Point;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(KeyboardEvent={KeyboardEvent}, Point={Point})";
            }
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class MouseEventReceivedEventArgs : global::System.EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public global::H.NotifyIcon.Core.MouseEvent MouseEvent { get; }

            /// <summary>
            ///
            /// </summary>
            public global::System.Drawing.Point Point { get; }

            /// <summary>
            ///
            /// </summary>
            public MouseEventReceivedEventArgs(global::H.NotifyIcon.Core.MouseEvent mouseEvent, global::System.Drawing.Point point)
            {
                MouseEvent = mouseEvent;
                Point = point;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out global::H.NotifyIcon.Core.MouseEvent mouseEvent, out global::System.Drawing.Point point)
            {
                mouseEvent = MouseEvent;
                point = Point;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(MouseEvent={MouseEvent}, Point={Point})";
            }
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired if a balloon ToolTip was either displayed or closed (indicated by the boolean flag).
        /// </summary>
        public event global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.BalloonToolTipChangedEventArgs>? BalloonToolTipChanged;

        /// <summary>
        /// A helper method to subscribe the BalloonToolTipChanged event.
        /// </summary>
        public global::System.IDisposable SubscribeToBalloonToolTipChanged(global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.BalloonToolTipChangedEventArgs> handler)
        {
            BalloonToolTipChanged += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => BalloonToolTipChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the BalloonToolTipChanged event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.BalloonToolTipChangedEventArgs OnBalloonToolTipChanged(global::H.NotifyIcon.Core.MessageWindow.BalloonToolTipChangedEventArgs args)
        {
            BalloonToolTipChanged?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the BalloonToolTipChanged event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.BalloonToolTipChangedEventArgs OnBalloonToolTipChanged(
            bool isVisible)
        {
            var args = new global::H.NotifyIcon.Core.MessageWindow.BalloonToolTipChangedEventArgs(isVisible);
            BalloonToolTipChanged?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// The custom tooltip should be closed or hidden.
        /// </summary>
        public event global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.ChangeToolTipStateRequestEventArgs>? ChangeToolTipStateRequest;

        /// <summary>
        /// A helper method to subscribe the ChangeToolTipStateRequest event.
        /// </summary>
        public global::System.IDisposable SubscribeToChangeToolTipStateRequest(global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.ChangeToolTipStateRequestEventArgs> handler)
        {
            ChangeToolTipStateRequest += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => ChangeToolTipStateRequest -= handler);
        }

        /// <summary>
        /// A helper method to raise the ChangeToolTipStateRequest event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.ChangeToolTipStateRequestEventArgs OnChangeToolTipStateRequest(global::H.NotifyIcon.Core.MessageWindow.ChangeToolTipStateRequestEventArgs args)
        {
            ChangeToolTipStateRequest?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the ChangeToolTipStateRequest event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.ChangeToolTipStateRequestEventArgs OnChangeToolTipStateRequest(
            bool isVisible)
        {
            var args = new global::H.NotifyIcon.Core.MessageWindow.ChangeToolTipStateRequestEventArgs(isVisible);
            ChangeToolTipStateRequest?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired if dpi change window message received.
        /// </summary>
        public event global::System.EventHandler? DpiChanged;

        /// <summary>
        /// A helper method to subscribe the DpiChanged event.
        /// </summary>
        public global::System.IDisposable SubscribeToDpiChanged(global::System.EventHandler handler)
        {
            DpiChanged += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => DpiChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the DpiChanged event.
        /// </summary>
        protected virtual global::System.EventArgs OnDpiChanged()
        {
            var args = new global::System.EventArgs();
            DpiChanged?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu.
        /// </summary>
        public event global::System.EventHandler? InitMenuPopup;

        /// <summary>
        /// A helper method to subscribe the InitMenuPopup event.
        /// </summary>
        public global::System.IDisposable SubscribeToInitMenuPopup(global::System.EventHandler handler)
        {
            InitMenuPopup += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => InitMenuPopup -= handler);
        }

        /// <summary>
        /// A helper method to raise the InitMenuPopup event.
        /// </summary>
        protected virtual global::System.EventArgs OnInitMenuPopup()
        {
            var args = new global::System.EventArgs();
            InitMenuPopup?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired in case the user interacted with the taskbar icon area with keyboard shortcuts.
        /// </summary>
        public event global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.KeyboardEventReceivedEventArgs>? KeyboardEventReceived;

        /// <summary>
        /// A helper method to subscribe the KeyboardEventReceived event.
        /// </summary>
        public global::System.IDisposable SubscribeToKeyboardEventReceived(global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.KeyboardEventReceivedEventArgs> handler)
        {
            KeyboardEventReceived += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => KeyboardEventReceived -= handler);
        }

        /// <summary>
        /// A helper method to raise the KeyboardEventReceived event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.KeyboardEventReceivedEventArgs OnKeyboardEventReceived(global::H.NotifyIcon.Core.MessageWindow.KeyboardEventReceivedEventArgs args)
        {
            KeyboardEventReceived?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the KeyboardEventReceived event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.KeyboardEventReceivedEventArgs OnKeyboardEventReceived(
            global::H.NotifyIcon.Core.KeyboardEvent keyboardEvent,
            global::System.Drawing.Point point)
        {
            var args = new global::H.NotifyIcon.Core.MessageWindow.KeyboardEventReceivedEventArgs(keyboardEvent, point);
            KeyboardEventReceived?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired in case the user clicked or moved within the taskbar icon area.
        /// </summary>
        public event global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.MouseEventReceivedEventArgs>? MouseEventReceived;

        /// <summary>
        /// A helper method to subscribe the MouseEventReceived event.
        /// </summary>
        public global::System.IDisposable SubscribeToMouseEventReceived(global::System.EventHandler<global::H.NotifyIcon.Core.MessageWindow.MouseEventReceivedEventArgs> handler)
        {
            MouseEventReceived += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => MouseEventReceived -= handler);
        }

        /// <summary>
        /// A helper method to raise the MouseEventReceived event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.MouseEventReceivedEventArgs OnMouseEventReceived(global::H.NotifyIcon.Core.MessageWindow.MouseEventReceivedEventArgs args)
        {
            MouseEventReceived?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the MouseEventReceived event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.MessageWindow.MouseEventReceivedEventArgs OnMouseEventReceived(
            global::H.NotifyIcon.Core.MouseEvent mouseEvent,
            global::System.Drawing.Point point)
        {
            var args = new global::H.NotifyIcon.Core.MessageWindow.MouseEventReceivedEventArgs(mouseEvent, point);
            MouseEventReceived?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired if the taskbar was created or restarted. Requires the taskbar icon to be reset
        /// </summary>
        public event global::System.EventHandler? TaskbarCreated;

        /// <summary>
        /// A helper method to subscribe the TaskbarCreated event.
        /// </summary>
        public global::System.IDisposable SubscribeToTaskbarCreated(global::System.EventHandler handler)
        {
            TaskbarCreated += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => TaskbarCreated -= handler);
        }

        /// <summary>
        /// A helper method to raise the TaskbarCreated event.
        /// </summary>
        protected virtual global::System.EventArgs OnTaskbarCreated()
        {
            var args = new global::System.EventArgs();
            TaskbarCreated?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        ///
        /// </summary>
        public class VersionChangedEventArgs : global::System.EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public global::H.NotifyIcon.Core.IconVersion Version { get; }

            /// <summary>
            ///
            /// </summary>
            public VersionChangedEventArgs(global::H.NotifyIcon.Core.IconVersion version)
            {
                Version = version;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out global::H.NotifyIcon.Core.IconVersion version)
            {
                version = Version;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(Version={Version})";
            }
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        /// TrayIcon was created.
        /// This can happen in the following cases:
        ///  - Via direct Create call
        ///  - Through the ClearNotifications call since its implementation uses TrayIcon re-creation
        /// </summary>
        public event global::System.EventHandler? Created;

        /// <summary>
        /// A helper method to subscribe the Created event.
        /// </summary>
        public global::System.IDisposable SubscribeToCreated(global::System.EventHandler handler)
        {
            Created += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => Created -= handler);
        }

        /// <summary>
        /// A helper method to raise the Created event.
        /// </summary>
        protected virtual global::System.EventArgs OnCreated()
        {
            var args = new global::System.EventArgs();
            Created?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        /// TrayIcon was removed.
        /// This can happen in the following cases:
        /// - Via direct TryRemove call
        /// - Through the ClearNotifications call since its implementation uses TrayIcon re-creation
        /// </summary>
        public event global::System.EventHandler? Removed;

        /// <summary>
        /// A helper method to subscribe the Removed event.
        /// </summary>
        public global::System.IDisposable SubscribeToRemoved(global::System.EventHandler handler)
        {
            Removed += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => Removed -= handler);
        }

        /// <summary>
        /// A helper method to raise the Removed event.
        /// </summary>
        protected virtual global::System.EventArgs OnRemoved()
        {
            var args = new global::System.EventArgs();
            Removed?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        /// Version was changed.
        /// This can happen in the following cases:
        /// - Via direct Create call
        /// - Through the ClearNotifications call since its implementation uses TrayIcon re-creation
        /// </summary>
        public event global::System.EventHandler<global::H.NotifyIcon.Core.TrayIcon.VersionChangedEventArgs>? VersionChanged;

        /// <summary>
        /// A helper method to subscribe the VersionChanged event.
        /// </summary>
        public global::System.IDisposable SubscribeToVersionChanged(global::System.EventHandler<global::H.NotifyIcon.Core.TrayIcon.VersionChangedEventArgs> handler)
        {
            VersionChanged += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => VersionChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the VersionChanged event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.TrayIcon.VersionChangedEventArgs OnVersionChanged(global::H.NotifyIcon.Core.TrayIcon.VersionChangedEventArgs args)
        {
            VersionChanged?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the VersionChanged event.
        /// </summary>
        protected virtual global::H.NotifyIcon.Core.TrayIcon.VersionChangedEventArgs OnVersionChanged(
            global::H.NotifyIcon.Core.IconVersion version)
        {
            var args = new global::H.NotifyIcon.Core.TrayIcon.VersionChangedEventArgs(version);
            VersionChanged?.Invoke(this, args);

            return args;
        }
    }
}

#nullable enable

namespace H.NotifyIcon.Core
{
    public partial class TrayIconWithContextMenu
    {
        /// <summary>
        /// Occurs before the context menu is displayed.
        /// </summary>
        public event global::System.EventHandler? ContextMenuOpening;

        /// <summary>
        /// A helper method to subscribe the ContextMenuOpening event.
        /// </summary>
        public global::System.IDisposable SubscribeToContextMenuOpening(global::System.EventHandler handler)
        {
            ContextMenuOpening += handler;

            return new global::H.NotifyIcon.Core.EventSubscription(() => ContextMenuOpening -= handler);
        }

        /// <summary>
        /// A helper method to raise the ContextMenuOpening event.
        /// </summary>
        protected virtual global::System.EventArgs OnContextMenuOpening()
        {
            var args = new global::System.EventArgs();
            ContextMenuOpening?.Invoke(this, args);

            return args;
        }
    }
}
