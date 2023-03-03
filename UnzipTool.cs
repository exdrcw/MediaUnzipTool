using System.Diagnostics;

namespace MediaUnzipTool;

public class UnzipTool
{
    const string UnZipExe = "\"" +  @"C:\Program Files\7-Zip\7z.exe" + "\"" ;

    public static void UnZip(string filePath,string outputPath, string password = "")
    {
        object resObj;
        try
        {
            string batfiledata = $@"{UnZipExe} x " + filePath + " -o" + outputPath + " -y";

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
            
            //向cmd窗口发送输入信息
            process.StandardInput.WriteLine(batfiledata + "&exit");
            process.StandardInput.AutoFlush = true;

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
            // if (output.ToUpper().IndexOf("EVERYTHING IS OK") > -1)
            // {
            //     resObj = new object[] { 0, "DeCompress file[" + filePath + "] OK!" };
            // }
            // else
            // {
            //     resObj = new object[] { 1, "DeCompress File[" + filePath + "] Error!" };
            // }

        }
        catch (Exception ex)
        {
            resObj = new object[] { 1, ex.Message };
        }
    }
}