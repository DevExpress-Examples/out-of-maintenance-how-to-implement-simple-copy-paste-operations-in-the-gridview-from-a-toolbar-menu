' Developer Express Code Central Example:
' How to implement simple copy/paste operations in the GridView from a toolbar menu
' 
' This example illustrates how to implement simple copy/paste/delete operations in
' the GridView.
' You can find more in the article
' http://www.devexpress.com/scid=A1266
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4528

Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.LookAndFeel

Namespace DXGridCRUDoperations
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            DevExpress.Skins.SkinManager.EnableFormSkins()
            DevExpress.UserSkins.BonusSkins.Register()
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")

            Application.Run(New Main())
        End Sub
    End Class
End Namespace