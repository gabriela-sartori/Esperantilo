using System;
using System.Collections.Generic;
using System.Linq;
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

            // Create a simple tray menu with only one item.
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

            // Create a tray icon. In this example we use a standard system icon for simplicity,
            // but you can of course use your own custom icon too.
            mainForm.trayIcon = new NotifyIcon();
            mainForm.trayIcon.Text = "Esperanto Tool";
            mainForm.trayIcon.Icon = mainForm.Icon;
            
            // Add menu to tray icon and show it.
            mainForm.trayIcon.ContextMenu = mainForm.trayMenu;
            mainForm.trayIcon.Visible     = true;

            Application.Run(mainForm);
            //Application.Run(); // Consegue rodar sem precisar de form           
        }

        static void OnExit(object sender, EventArgs e) {
            Application.Exit();
        }

    }
}
