﻿using System;
using System.Windows.Forms;
using JejuReservation.Frm;

namespace JejuReservation
{
    internal static class Program
    {
        /// <summary>
        ///     해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartFrm());
        }
    }
}