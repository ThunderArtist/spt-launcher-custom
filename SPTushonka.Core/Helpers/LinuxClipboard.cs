using System.Diagnostics;
using System.Text;

namespace SPTarkov.Core.Helpers;

public static class LinuxClipboard
{
    // Check whether the user is using X11 or Wayland
    private static string GetSessionType()
    {
        var process = ExecuteCommand("echo $XDG_SESSION_TYPE");
        return process.StandardOutput.ReadToEnd().Trim();
    }
    
    public static bool CopyText(string value)
    {
        var sessionType = GetSessionType();

        if (sessionType == "x11")
            return CopyTextX11(value);
        
        if (sessionType == "wayland")
            return CopyTextWayland(value);

        throw new Exception($"Your window manager \"{sessionType}\" is not supported.");
    }

    public static bool CopyTextX11(string value)
    {
        value = value.Replace("\\", "\\\\").Replace("\"", "\\\"");      // Escapes on top of escapes
        var process = ExecuteCommand($"printf %b \"{value}\" | xclip -selection clipboard");
        return process.ExitCode == 0;
    }

    public static bool CopyTextWayland(string value)
    {
        // TODO: Add wayland support with wl-copy, the alternative of xclip for wayland
        throw new NotImplementedException("Wayland clipboard is not supported yet. Make a pull request :)");

        // Sample implementation, HAS NOT BEEN TESTED
        // value = value.Replace("\\", "\\\\").Replace("\"", "\\\"");      // Escapes on top of escapes
        // var process = ExecuteCommand($"printf %b \"{value}\" | wl-copy --primary");
        // return process.ExitCode == 0;
    }

    private static Process ExecuteCommand(string command)
    {
        command = command.Replace("\\", "\\\\").Replace("\"", "\\\"");    // Escapes on top of escapes
        var processInfo = new ProcessStartInfo("/usr/bin/sh", $"-c \"{command}\"")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };
    
        Process? process = Process.Start(processInfo);
        if (process == null)
            throw new Exception("Process is null.");

        process.WaitForExit();

        return process;
    }
}
