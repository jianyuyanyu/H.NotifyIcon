﻿using System.Drawing;
using H.NotifyIcon.Interop;

using var trayIcon = new TrayIcon(false);
using var iconStream = H.Resources.Red_ico.AsStream();
using var icon = new Icon(iconStream);
trayIcon.SetIcon(icon.Handle);
trayIcon.SetToolTip(nameof(TrayIcon));

while(true)
{
    var line = Console.ReadLine();
    var result = false;
    if (line.StartsWith("message"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.None),
            message: line.Substring("message".Length + 1),
            icon: NotificationIcon.None);
    }
    else if (line.StartsWith("info"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.Info),
            message: line.Substring("info".Length + 1),
            icon: NotificationIcon.Info);
    }
    else if (line.StartsWith("warning"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.Warning),
            message: line.Substring("warning".Length + 1),
            icon: NotificationIcon.Warning);
    }
    else if (line.StartsWith("error"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.Error),
            message: line.Substring("error".Length + 1),
            icon: NotificationIcon.Error,
            realtime: true);
    }
    else if (line.StartsWith("clear"))
    {
        result = trayIcon.ClearNotifications();
    }
    else if (line.StartsWith("set-focus"))
    {
        result = trayIcon.SetFocus();
    }

    Console.WriteLine($"{line}: {result}");
}