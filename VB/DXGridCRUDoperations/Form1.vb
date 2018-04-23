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

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid


Namespace DXGridCRUDoperations
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
			InitGrid()

		End Sub
		Private gridDataList As New BindingList(Of Person)()
		Private Sub InitGrid()
			gridDataList.Add(New Person("John", "Smith"))
			gridDataList.Add(New Person("Gabriel", "Smith"))
			gridDataList.Add(New Person("Ashley", "Smith", "some comment"))
			gridDataList.Add(New Person("Adrian", "Smith", "some comment"))
			gridDataList.Add(New Person("Gabriella", "Smith", "some comment"))
			gridControl.DataSource = gridDataList
			AddHandler gridView1.InitNewRow, AddressOf gridView1_InitNewRow
		End Sub

		Private Sub gridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
			Dim view As GridView = TryCast(sender, GridView)

			If view IsNot Nothing AndAlso personToEdit IsNot Nothing Then
				view.SetRowCellValue(e.RowHandle, view.Columns("FirstName"),personToEdit.FirstName)
				view.SetRowCellValue(e.RowHandle, view.Columns("SecondName"), personToEdit.SecondName)
				view.SetRowCellValue(e.RowHandle, view.Columns("Info"), personToEdit.Info)
			End If
		End Sub
		Private f1 As EditForm
		Private personToEdit As Person
		Private personList As New BindingList(Of Person)()
		Private Sub iAdd_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iAdd.ItemClick
			personToEdit = New Person()
			EditPerson(personToEdit, "NewPerson", AddressOf CloseNewPersonHandler)
		End Sub
		Private Sub EditPerson(ByVal person As Person, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)
			f1 = New EditForm(person, False) With {.Text = windowTitle}
			AddHandler f1.FormClosing, closedDelegate
			f1.ShowDialog()
		End Sub
		Private Sub CloseNewPersonHandler(ByVal sender As Object, ByVal e As FormClosingEventArgs)

			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				Try
					' personList.Add(personToEdit); //add via Datasource                    
				   '((IList)gridView1.DataSource).Add(personToEdit);  
					gridView1.AddNewRow()
				Catch ex As Exception
					HandleExcepton(ex)
				End Try
				SetNewFocus()
			End If
			personToEdit = Nothing
		End Sub
		Private Sub SetNewFocus()
			For i As Integer = 0 To gridView1.DataRowCount - 1
				If personToEdit.FirstName = gridView1.GetRowCellValue(i, gridView1.Columns("FirstName")).ToString() Then
					gridView1.FocusedRowHandle = i
					Exit For
				End If
			Next i
		End Sub
		Private Sub HandleExcepton(ByVal ex As Exception)
			MessageBox.Show(ex.Message)
		End Sub
		Private Sub iCopy_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iCopy.ItemClick
			If gridView1.FocusedRowHandle > -1 Then
				Dim s As String = String.Empty
				For i As Integer = 0 To gridView1.Columns.Count - 1
					s &= gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns(i)) + Constants.vbLf
				Next i
				Clipboard.SetDataObject(s)
			Else
				MessageBox.Show("Row is not selected")
			End If
		End Sub
		Private Sub iPaste_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iPaste.ItemClick
			If gridView1.FocusedRowHandle > -1 Then
				Dim data As IDataObject = Clipboard.GetDataObject()
				If data.GetDataPresent(DataFormats.Text) AndAlso gridView1.FocusedRowHandle > -1 Then
					Dim s As String = data.GetData(DataFormats.Text).ToString()
					Dim a() As String = s.Split(ControlChars.Lf)
					Dim i As Integer = 0
					For Each item As GridColumn In gridView1.Columns
						gridView1.SetRowCellValue(gridView1.FocusedRowHandle, item, a(i))
						i += 1
					Next item
				End If
			Else
				MessageBox.Show("Row is not selected")
			End If
		End Sub
		Private Sub iInsert_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iInsert.ItemClick
			personToEdit = New Person()
			InsertPerson(personToEdit, "InsertForm", AddressOf InsertPersonHandler)
		End Sub
		Private Sub InsertPerson(ByVal person As Person, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)
			f1 = New EditForm(person, True) With {.Text = windowTitle}
			AddHandler f1.FormClosing, closedDelegate
			f1.ShowDialog()
		End Sub
		Private Sub InsertPersonHandler(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			Dim form As EditForm = TryCast(sender, EditForm)
			If form IsNot Nothing Then
				If form.DialogResult = System.Windows.Forms.DialogResult.OK Then
					Try
						If (Not String.IsNullOrWhiteSpace(form.NewPosition)) Then
							Dim pos As Integer = Convert.ToInt32(form.NewPosition)
							If pos > personList.Count - 1 Then

								personList.Add(personToEdit)
							Else

								personList.Insert(pos, personToEdit)
							End If
						Else
							MessageBox.Show("Incorrect position value")
						End If

					Catch ex As Exception
						HandleExcepton(ex)
					End Try
				End If
				SetNewFocus()
			End If
			personToEdit = Nothing
		End Sub
		Private Sub iDelete_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iDelete.ItemClick
			DeletePerson(gridView1.FocusedRowHandle)
		End Sub
		Public Function GetCurrentPerson() As Person
			Return TryCast(gridView1.GetRow(gridView1.FocusedRowHandle), Person)
		End Function
		Private Sub DeletePerson(ByVal focusedRowHandle As Integer)
			If focusedRowHandle < 0 Then
				MessageBox.Show("You didn't select a person to delete")
				Return
			End If
			If MessageBox.Show("Do you really want to delete the selected person?", "Delete Person", MessageBoxButtons.OKCancel) <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If
			Try
				'Deleting from datasource
				'personToEdit = GetCurrentPerson();
				'personList.Remove(personToEdit);
				'Deleting from View
				gridView1.DeleteRow(gridView1.FocusedRowHandle)
			Catch ex As Exception
				HandleExcepton(ex)
			End Try
			gridView1.FocusedRowHandle = focusedRowHandle
			personToEdit = Nothing
		End Sub

		Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButtonItem1.ItemClick
			If gridView1.IsMultiSelect AndAlso gridView1.SelectedRowsCount > 0 Then
				gridView1.DeleteSelectedRows()
			End If
		End Sub

	End Class
End Namespace