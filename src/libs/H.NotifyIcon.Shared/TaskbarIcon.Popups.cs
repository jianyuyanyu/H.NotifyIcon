﻿namespace H.NotifyIcon;

public partial class TaskbarIcon
{
    #region Properties

    #region PopupActivation

    /// <summary>Identifies the <see cref="PopupActivation"/> dependency property.</summary>
    public static readonly DependencyProperty PopupActivationProperty =
        DependencyProperty.Register(
            nameof(PopupActivation),
            typeof(PopupActivationMode),
            typeof(TaskbarIcon),
            new PropertyMetadata(PopupActivationMode.LeftClick));

    /// <summary>
    /// A property wrapper for the <see cref="PopupActivationProperty"/>
    /// dependency property:<br/>
    /// Defines what mouse events trigger the <see cref="TrayPopup" />.
    /// Default is <see cref="PopupActivationMode.LeftClick" />.
    /// </summary>
    [Category(CategoryName)]
    [Description("Defines what mouse events display the TaskbarIconPopup.")]
#if !HAS_WPF
    [CLSCompliant(false)]
#endif
    public PopupActivationMode PopupActivation
    {
        get { return (PopupActivationMode)GetValue(PopupActivationProperty); }
        set { SetValue(PopupActivationProperty, value); }
    }

    #endregion

    #region TrayPopup

    /// <summary>Identifies the <see cref="TrayPopup"/> dependency property.</summary>
    public static readonly DependencyProperty TrayPopupProperty =
        DependencyProperty.Register(nameof(TrayPopup),
            typeof(UIElement),
            typeof(TaskbarIcon),
            new PropertyMetadata(null, (d, e) => ((TaskbarIcon)d).OnTrayPopupPropertyChanged(e)));

    /// <summary>
    /// A property wrapper for the <see cref="TrayPopupProperty"/>
    /// dependency property:<br/>
    /// A control that is displayed as a popup when the taskbar icon is clicked.
    /// </summary>
    [Category(CategoryName)]
    [Description("Displayed as a Popup if the user clicks on the taskbar icon.")]
    public UIElement? TrayPopup
    {
        get { return (UIElement?)GetValue(TrayPopupProperty); }
        set { SetValue(TrayPopupProperty, value); }
    }

    private void OnTrayPopupPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
#if HAS_WPF
        if (e.OldValue != null)
        {
            //remove the taskbar icon reference from the previously used element
            SetParentTaskbarIcon((DependencyObject)e.OldValue, null);
        }


        if (e.NewValue != null)
        {
            //set this taskbar icon as a reference to the new tooltip element
            SetParentTaskbarIcon((DependencyObject)e.NewValue, this);
        }
#endif

        //create a pop
        CreatePopup();
    }

    #endregion

    #region TrayPopupResolved

    /// <summary>Identifies the <see cref="TrayPopupResolved"/> dependency property.</summary>
    public static readonly DependencyProperty TrayPopupResolvedProperty =
        DependencyProperty.Register(
            nameof(TrayPopupResolved),
            typeof(Popup),
            typeof(TaskbarIcon),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets the TrayPopupResolved property. Returns
    /// a <see cref="Popup"/> which is either the
    /// <see cref="TrayPopup"/> control itself or a
    /// <see cref="Popup"/> control that contains the
    /// <see cref="TrayPopup"/>.
    /// </summary>
    [Category(CategoryName)]
    public Popup? TrayPopupResolved => (Popup?)GetValue(TrayPopupResolvedProperty);

    /// <summary>
    /// Provides a secure method for setting the TrayPopupResolved property.  
    /// This dependency property indicates ....
    /// </summary>
    /// <param name="value">The new value for the property.</param>
    protected void SetTrayPopupResolved(Popup? value)
    {
        SetValue(TrayPopupResolvedProperty, value);
    }

    #endregion

    #region PopupPlacement

    /// <summary>Identifies the <see cref="PopupPlacement"/> dependency property.</summary>
    public static readonly DependencyProperty PopupPlacementProperty =
        DependencyProperty.Register(
            nameof(PopupPlacement),
            typeof(PlacementMode),
            typeof(TaskbarIcon),
#if HAS_WPF
            new PropertyMetadata(PlacementMode.AbsolutePoint));
#else
            new PropertyMetadata(PlacementMode.Mouse));
#endif

    /// <summary>
    /// A property wrapper for the <see cref="PopupPlacementProperty"/>
    /// dependency property:<br/>
    /// Defines popup placement mode <see cref="TrayPopup" />.
    /// Default is PlacementMode.AbsolutePoint for WPF and PlacementMode.Mouse for other platforms.
    /// </summary>
    [Category(CategoryName)]
    [Description("Defines popup placement mode of TaskbarIconPopup.")]
    public PlacementMode PopupPlacement
    {
        get { return (PlacementMode)GetValue(PopupPlacementProperty); }
        set { SetValue(PopupPlacementProperty, value); }
    }

    #endregion

    #region PopupOffset

    /// <summary>Identifies the <see cref="PopupOffset"/> dependency property.</summary>
    public static readonly DependencyProperty PopupOffsetProperty =
        DependencyProperty.Register(
            nameof(PopupOffset),
            typeof(Thickness),
            typeof(TaskbarIcon),
            new PropertyMetadata(new Thickness(0.0)));

    /// <summary>
    /// A property wrapper for the <see cref="PopupOffsetProperty"/>
    /// dependency property:<br/>
    /// Defines popup offset for <see cref="TrayPopup" />.
    /// </summary>
    [Category(CategoryName)]
    [Description("Defines popup offset of TaskbarIconPopup.")]
    public Thickness PopupOffset
    {
        get { return (Thickness)GetValue(PopupOffsetProperty); }
        set { SetValue(PopupOffsetProperty, value); }
    }

    #endregion

    #endregion

    #region Events

#if HAS_WPF

    #region TrayPopupOpen

    /// <summary>Identifies the <see cref="TrayPopupOpen"/> routed event.</summary>
    public static readonly RoutedEvent TrayPopupOpenEvent =
        EventManager.RegisterRoutedEvent(
            nameof(TrayPopupOpen),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(TaskbarIcon));

    /// <summary>
    /// Bubbled event that occurs when the custom popup is being opened.
    /// </summary>
    public event RoutedEventHandler TrayPopupOpen
    {
        add { AddHandler(TrayPopupOpenEvent, value); }
        remove { RemoveHandler(TrayPopupOpenEvent, value); }
    }

    /// <summary>
    /// A helper method to raise the TrayPopupOpen event.
    /// </summary>
    protected RoutedEventArgs RaiseTrayPopupOpenEvent()
    {
        return this.RaiseRoutedEvent(new RoutedEventArgs(TrayPopupOpenEvent));
    }

    #endregion

    #region PreviewTrayPopupOpen

    /// <summary>Identifies the <see cref="PreviewTrayPopupOpen"/> routed event.</summary>
    public static readonly RoutedEvent PreviewTrayPopupOpenEvent =
        EventManager.RegisterRoutedEvent(
            nameof(PreviewTrayPopupOpen),
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(TaskbarIcon));

    /// <summary>
    /// Tunneled event that occurs when the custom popup is being opened.
    /// </summary>
    public event RoutedEventHandler PreviewTrayPopupOpen
    {
        add { AddHandler(PreviewTrayPopupOpenEvent, value); }
        remove { RemoveHandler(PreviewTrayPopupOpenEvent, value); }
    }

    /// <summary>
    /// A helper method to raise the PreviewTrayPopupOpen event.
    /// </summary>
    protected RoutedEventArgs RaisePreviewTrayPopupOpenEvent()
    {
        return this.RaiseRoutedEvent(new RoutedEventArgs(PreviewTrayPopupOpenEvent));
    }

    #endregion

    #region PopupOpened

    /// <summary>
    /// PopupOpened Attached Routed Event
    /// </summary>
    public static readonly RoutedEvent PopupOpenedEvent =
        EventManager.RegisterRoutedEvent(
            "PopupOpened",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(TaskbarIcon));

    /// <summary>
    /// Adds a handler for the PopupOpened attached event
    /// </summary>
    /// <param name="element">UIElement or ContentElement that listens to the event</param>
    /// <param name="handler">Event handler to be added</param>
    public static void AddPopupOpenedHandler(DependencyObject element, RoutedEventHandler handler)
    {
        RoutedEventHelper.AddHandler(element, PopupOpenedEvent, handler);
    }

    /// <summary>
    /// Removes a handler for the PopupOpened attached event
    /// </summary>
    /// <param name="element">UIElement or ContentElement that listens to the event</param>
    /// <param name="handler">Event handler to be removed</param>
    public static void RemovePopupOpenedHandler(DependencyObject element, RoutedEventHandler handler)
    {
        RoutedEventHelper.RemoveHandler(element, PopupOpenedEvent, handler);
    }

    #endregion

#endif

    #endregion

    #region Methods

    /// <summary>
    /// Creates a <see cref="ToolTip"/> control that either
    /// wraps the currently set <see cref="TrayToolTip"/>
    /// control or the <see cref="ToolTipText"/> string.<br/>
    /// If <see cref="TrayToolTip"/> itself is already
    /// a <see cref="ToolTip"/> instance, it will be used directly.
    /// </summary>
    /// <remarks>We use a <see cref="ToolTip"/> rather than
    /// <see cref="Popup"/> because there was no way to prevent a
    /// popup from causing cyclic open/close commands if it was
    /// placed under the mouse. ToolTip internally uses a Popup of
    /// its own, but takes advance of Popup's internal <see cref="UIElement.IsHitTestVisible"/>
    /// property which prevents this issue.</remarks>
    private void CreatePopup()
    {
        // check if the item itself is a popup
        var popup = TrayPopup as Popup;

        if (popup == null && TrayPopup != null)
        {
            // create an invisible popup that hosts the UIElement
            popup = new Popup
            {
#if HAS_WPF
                AllowsTransparency = true,
                // don't animate by default - developers can use attached events or override
                PopupAnimation = PopupAnimation.None,
                // the CreateRootPopup method outputs binding errors in the debug window because
                // it tries to bind to "Popup-specific" properties in case they are provided by the child.
                // We don't need that so just assign the control as the child.
                // do *not* set the placement target, as it causes the popup to become hidden if the
                // TaskbarIcon's parent is hidden, too. At runtime, the parent can be resolved through
                // the ParentTaskbarIcon attached dependency property:
                // PlacementTarget = this;

                Placement = PopupPlacement,
                StaysOpen = false,
#endif
                Child = TrayPopup,
            };
        }

        // the popup explicitly gets the DataContext of this instance.
        // If there is no DataContext, the TaskbarIcon assigns itself
        if (popup != null)
        {
            UpdateDataContext(popup, null, DataContext);
        }

        // store a reference to the used tooltip
        SetTrayPopupResolved(popup);
    }

    /// <summary>
    /// Hide the <see cref="TrayPopup"/> control if it was visible.
    /// </summary>
    public void CloseTrayPopup()
    {
        if (IsDisposed)
        {
            return;
        }

#if HAS_WPF
        var args = RaisePreviewTrayPopupOpenEvent();
        if (args.Handled)
        {
            return;
        }
#endif

        if (TrayPopup == null)
        {
            return;
        }

        if (TrayPopupResolved != null)
        {
            TrayPopupResolved.IsOpen = false;
        }
    }

    /// <summary>
    /// Displays the <see cref="TrayPopup"/> control if it was set.
    /// </summary>
    public void ShowTrayPopup(System.Drawing.Point cursorPosition)
    {
        if (IsDisposed)
        {
            return;
        }

#if HAS_WPF
        // raise preview event no matter whether popup is currently set
        // or not (enables client to set it on demand)
        var args = RaisePreviewTrayPopupOpenEvent();
        if (args.Handled)
        {
            return;
        }
#endif

        if (TrayPopup == null)
        {
            return;
        }
        if (TrayPopupResolved == null)
        {
            return;
        }

        PlacePopup(cursorPosition);

        // open popup
        TrayPopupResolved.IsOpen = true;

#if HAS_WPF
        var handle = (nint)0;
        if (TrayPopupResolved.Child != null)
        {
            // try to get a handle on the popup itself (via its child)
            if (PresentationSource.FromVisual(TrayPopupResolved.Child) is HwndSource source)
            {
                handle = source.Handle;
            }
        }

        // if we don't have a handle for the popup, fall back to the message sink
        if (handle == 0)
        {
            handle = TrayIcon.WindowHandle;
        }

        // activate either popup or message sink to track deactivation.
        // otherwise, the popup does not close if the user clicks somewhere else
        WindowUtilities.SetForegroundWindow(handle);

        // raise attached event - item should never be null unless developers
        // changed the CustomPopup directly...
        TrayPopup?.RaiseRoutedEvent(new RoutedEventArgs(PopupOpenedEvent));

        // bubble routed event
        RaiseTrayPopupOpenEvent();
#endif
    }

    private void PlacePopup(System.Drawing.Point cursorPosition)
    {
        if (TrayPopupResolved == null)
        {
            return;
        }

#if HAS_WPF
        TrayPopupResolved.Placement = PopupPlacement;
#endif
        if (PopupPlacement == PlacementMode.Bottom)
        {
            // place popup above system taskbar
            var point = TrayInfo.GetTrayLocation(0);
#if HAS_WPF
            TrayPopupResolved.Placement = PlacementMode.AbsolutePoint;
#endif
            TrayPopupResolved.HorizontalOffset = point.X;
            TrayPopupResolved.VerticalOffset = point.Y;
        }
#if HAS_WPF
        else if (PopupPlacement == PlacementMode.AbsolutePoint)
#else
        else if (PopupPlacement == PlacementMode.Mouse)
#endif
        {
            // place popup near mouse cursor
            TrayPopupResolved.HorizontalOffset = cursorPosition.X;
            TrayPopupResolved.VerticalOffset = cursorPosition.Y;
        }

        TrayPopupResolved.HorizontalOffset += PopupOffset.Left;
        TrayPopupResolved.VerticalOffset += PopupOffset.Top;
    }

    #endregion
}
