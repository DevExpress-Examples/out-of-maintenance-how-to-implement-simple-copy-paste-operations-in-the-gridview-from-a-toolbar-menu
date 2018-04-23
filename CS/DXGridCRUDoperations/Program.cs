// Developer Express Code Central Example:
// How to implement simple copy/paste operations in the GridView from a toolbar menu
// 
// This example illustrates how to implement simple copy/paste/delete operations in
// the GridView.
// You can find more in the article
// http://www.devexpress.com/scid=A1266
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4528

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace DXGridCRUDoperations
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

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Application.Run(new Main());
        }
    }
}