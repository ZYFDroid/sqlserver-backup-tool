using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数据库工具
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String dataPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data");

            if (!Directory.Exists(dataPath)) {
                Directory.CreateDirectory(dataPath);
            }

            Environment.CurrentDirectory = dataPath;

            if (!File.Exists("conStr.txt")) {
                File.WriteAllText("conStr.txt", "data source=localhost;initial catalog=master;integrated security=True;");
            }

            Application.Run(new Form1());
        }

        public static DateTime epoch = new DateTime(2020, 1, 1, 0, 0, 0);

        public static long toTimeStamp(this DateTime dt) {
            return (long) ((dt - epoch).TotalMilliseconds);
        }

        public static DateTime fromTimeStamp(this long dt) {
            return epoch + TimeSpan.FromMilliseconds(dt);
        }

        public static String toTimeStr(this DateTime dt) => dt.ToString("yyyy\\-MM\\-dd HH\\:mm\\:ss");
    }
}
