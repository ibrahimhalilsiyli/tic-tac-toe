﻿using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace XOX_Game
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
