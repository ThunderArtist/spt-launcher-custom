using System.Diagnostics;
using System.Text;

namespace SPTarkov.Core.Helpers;

public static class LinuxClipboard
{
    // TODO: Add wayland support with wl-copy, the alternative of xclip for wayland
    public static bool CopyText(string value)
    {
        value = value.Replace("\"", "\\\"").Replace("\\", "\\\\\\");    // Escapes on top of escapes
        var processInfo = new ProcessStartInfo("/usr/bin/sh", $"-c \"printf %b \\\"{value}\\\" | xclip -selection clipboard\"")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        Process? process = null;
        try
        {
            process = Process.Start(processInfo);
            process?.WaitForExit();
        }
        catch (Exception e)
        {
            // TODO: Logger!
            Console.WriteLine(e.ToString());
            process = null;
        }

        return process != null && process.ExitCode == 0;
    }
}