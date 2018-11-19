
using S7.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatsonTcp;
using Ninject;
using TVM_WMS.SERVER.Infrastructure.Logger;
using TVM_WMS.SERVER.Interfaces;
using Packet;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER
{
    static class Program
    {
        private static string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        public static IKernel kernel;

        [STAThread]
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool flag = false;
            Mutex mutex = new Mutex(false, "WMS.SERVER", out flag);
            if (!flag)
            {
                MessageBox.Show("Программа уже запущена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ConfigClass.Instance.GetLocaSettings(HomePath + @"\Settings.xml");

                kernel = new StandardKernel(new ServiceModule(ConfigClass.Instance.ConnectionDbString));

                ISettingsService settingsService = kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigLoad(settingsService);

                Logger.InitLogger();

                Logger.Log.Debug("Запуск программы.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при запуске программы.\n" + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new MainTabFm());

            mutex.Close();
    
        }
    }
}
