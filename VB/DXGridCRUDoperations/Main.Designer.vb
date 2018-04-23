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

Namespace DXGridCRUDoperations
    Partial Public Class Main
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.barManager = New DevExpress.XtraBars.BarManager(Me.components)
            Me.bar2 = New DevExpress.XtraBars.Bar()
            Me.mFile = New DevExpress.XtraBars.BarSubItem()
            Me.iAdd = New DevExpress.XtraBars.BarButtonItem()
            Me.iInsert = New DevExpress.XtraBars.BarButtonItem()
            Me.iCopy = New DevExpress.XtraBars.BarButtonItem()
            Me.iPaste = New DevExpress.XtraBars.BarButtonItem()
            Me.iDelete = New DevExpress.XtraBars.BarButtonItem()
            Me.barButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
            Me.mHelp = New DevExpress.XtraBars.BarSubItem()
            Me.iAbout = New DevExpress.XtraBars.BarButtonItem()
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.barButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
            Me.gridControl = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.barManager, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridControl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' barManager
            ' 
            Me.barManager.Bars.AddRange(New DevExpress.XtraBars.Bar() { Me.bar2})
            Me.barManager.DockControls.Add(Me.barDockControlTop)
            Me.barManager.DockControls.Add(Me.barDockControlBottom)
            Me.barManager.DockControls.Add(Me.barDockControlLeft)
            Me.barManager.DockControls.Add(Me.barDockControlRight)
            Me.barManager.Form = Me
            Me.barManager.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.mFile, Me.barButtonItem2, Me.iInsert, Me.iPaste, Me.iAdd, Me.iCopy, Me.iDelete, Me.mHelp, Me.iAbout, Me.barButtonItem1})
            Me.barManager.MainMenu = Me.bar2
            Me.barManager.MaxItemId = 13
            ' 
            ' bar2
            ' 
            Me.bar2.BarName = "Main menu"
            Me.bar2.DockCol = 0
            Me.bar2.DockRow = 0
            Me.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { _
                New DevExpress.XtraBars.LinkPersistInfo(Me.mFile), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.mHelp) _
            })
            Me.bar2.OptionsBar.MultiLine = True
            Me.bar2.OptionsBar.UseWholeRow = True
            Me.bar2.Text = "Main menu"
            ' 
            ' mFile
            ' 
            Me.mFile.Caption = "&Menu" & ControlChars.CrLf
            Me.mFile.Id = 0
            Me.mFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { _
                New DevExpress.XtraBars.LinkPersistInfo(Me.iAdd), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.iInsert), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.iCopy), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.iPaste), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.iDelete), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.barButtonItem1) _
            })
            Me.mFile.Name = "mFile"
            ' 
            ' iAdd
            ' 
            Me.iAdd.Caption = "&Add"
            Me.iAdd.Id = 6
            Me.iAdd.Name = "iAdd"
            ' 
            ' iInsert
            ' 
            Me.iInsert.Caption = "&Insert"
            Me.iInsert.Id = 4
            Me.iInsert.Name = "iInsert"
            ' 
            ' iCopy
            ' 
            Me.iCopy.Caption = "&Copy Row"
            Me.iCopy.Id = 7
            Me.iCopy.Name = "iCopy"
            ' 
            ' iPaste
            ' 
            Me.iPaste.Caption = "&Paste Row"
            Me.iPaste.Id = 5
            Me.iPaste.Name = "iPaste"
            ' 
            ' iDelete
            ' 
            Me.iDelete.Caption = "&Delete"
            Me.iDelete.Id = 9
            Me.iDelete.Name = "iDelete"
            ' 
            ' barButtonItem1
            ' 
            Me.barButtonItem1.Caption = "Delete selected rows"
            Me.barButtonItem1.Id = 12
            Me.barButtonItem1.Name = "barButtonItem1"
            ' 
            ' mHelp
            ' 
            Me.mHelp.Caption = "&Help"
            Me.mHelp.Id = 10
            Me.mHelp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.iAbout)})
            Me.mHelp.Name = "mHelp"
            ' 
            ' iAbout
            ' 
            Me.iAbout.Caption = "&About"
            Me.iAbout.Id = 11
            Me.iAbout.Name = "iAbout"
            ' 
            ' barDockControlTop
            ' 
            Me.barDockControlTop.CausesValidation = False
            Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlTop.Size = New System.Drawing.Size(613, 22)
            ' 
            ' barDockControlBottom
            ' 
            Me.barDockControlBottom.CausesValidation = False
            Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.barDockControlBottom.Location = New System.Drawing.Point(0, 477)
            Me.barDockControlBottom.Size = New System.Drawing.Size(613, 0)
            ' 
            ' barDockControlLeft
            ' 
            Me.barDockControlLeft.CausesValidation = False
            Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
            Me.barDockControlLeft.Size = New System.Drawing.Size(0, 455)
            ' 
            ' barDockControlRight
            ' 
            Me.barDockControlRight.CausesValidation = False
            Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.barDockControlRight.Location = New System.Drawing.Point(613, 22)
            Me.barDockControlRight.Size = New System.Drawing.Size(0, 455)
            ' 
            ' barButtonItem2
            ' 
            Me.barButtonItem2.Caption = "Open"
            Me.barButtonItem2.Id = 2
            Me.barButtonItem2.Name = "barButtonItem2"
            ' 
            ' gridControl
            ' 
            Me.gridControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl.Location = New System.Drawing.Point(0, 22)
            Me.gridControl.MainView = Me.gridView1
            Me.gridControl.Name = "gridControl"
            Me.gridControl.Size = New System.Drawing.Size(613, 455)
            Me.gridControl.TabIndex = 0
            Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
            ' 
            ' gridView1
            ' 
            Me.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.gridView1.GridControl = Me.gridControl
            Me.gridView1.Name = "gridView1"
            Me.gridView1.OptionsSelection.MultiSelect = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(613, 477)
            Me.Controls.Add(Me.gridControl)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.barManager, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridControl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private barManager As DevExpress.XtraBars.BarManager
        Private bar2 As DevExpress.XtraBars.Bar
        Private barDockControlTop As DevExpress.XtraBars.BarDockControl
        Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Private barDockControlRight As DevExpress.XtraBars.BarDockControl
        Private mFile As DevExpress.XtraBars.BarSubItem
        Private barButtonItem2 As DevExpress.XtraBars.BarButtonItem
        Private WithEvents iInsert As DevExpress.XtraBars.BarButtonItem
        Private WithEvents iPaste As DevExpress.XtraBars.BarButtonItem
        Private WithEvents iAdd As DevExpress.XtraBars.BarButtonItem
        Private WithEvents iCopy As DevExpress.XtraBars.BarButtonItem
        Private WithEvents iDelete As DevExpress.XtraBars.BarButtonItem
        Private mHelp As DevExpress.XtraBars.BarSubItem
        Private iAbout As DevExpress.XtraBars.BarButtonItem
        Private gridControl As DevExpress.XtraGrid.GridControl
        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Private WithEvents barButtonItem1 As DevExpress.XtraBars.BarButtonItem

    End Class
End Namespace
