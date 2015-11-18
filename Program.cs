using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new frmMain();            

            mainForm.trayMenu = new ContextMenu();
            mainForm.trayMenu.MenuItems.Add("Hide", (sender, e) =>
            {
                if (mainForm.trayMenu.MenuItems[0].Text == "Show")
                {
                    mainForm.Show();
                    mainForm.trayMenu.MenuItems[0].Text = "Hide";
                }
                else
                {
                    mainForm.Hide();
                    mainForm.trayMenu.MenuItems[0].Text = "Show";
                }                
            });

            mainForm.trayMenu.MenuItems.Add("Exit", (sender, e) =>
            {
                mainForm.Close();
                Application.Exit();
            });

            mainForm.trayIcon = new NotifyIcon();
            mainForm.trayIcon.Text        = "Esperantilo";
            mainForm.trayIcon.Icon        = mainForm.Icon;
            mainForm.trayIcon.ContextMenu = mainForm.trayMenu;
            mainForm.trayIcon.Visible     = true;

            Application.Run(mainForm);
        }

        static void OnExit(object sender, EventArgs e) {
            Application.Exit();
        }

    }
}
