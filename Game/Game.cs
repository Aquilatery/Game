﻿using System;
using System.Windows.Forms;

namespace Game
{
    internal static class Game
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
#if NETCOREAPP3_1 || NET5_0 || NET6_0 || NET7_0
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}