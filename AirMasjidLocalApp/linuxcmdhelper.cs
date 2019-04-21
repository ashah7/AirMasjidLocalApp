using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirMasjidLocalApp
{
    public static class Linuxcmdhelper
    {


        public static string Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                   // FileName = "/bin/bash",
                         FileName = "C:\\MediaToolkit\\ffmpeg.exe",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,

                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();

            process.WaitForExit();


            return result.Trim() + ";" + process.ExitCode;
            //return process;

        }




    }
}
