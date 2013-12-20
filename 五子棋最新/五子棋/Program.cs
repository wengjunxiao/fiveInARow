using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 五子棋
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


    }
    class cc
    {
       
        public static bool online = false;
        public static bool server = false;
        public static string ip = "";

        public static bool over = false;
        public static bool start = true;
       
        
    }
}