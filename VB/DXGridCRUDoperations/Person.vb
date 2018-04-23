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

Namespace DXGridCRUDoperations
	Public Class Person
		Private firstName_Renamed As String
		Private secondName_Renamed As String
		Private comments As String
		Public Sub New(ByVal firstName As String, ByVal secondName As String)
			Me.firstName_Renamed = firstName
			Me.secondName_Renamed = secondName
			comments = String.Empty
		End Sub
		Public Sub New(ByVal firstName As String, ByVal secondName As String, ByVal comments As String)
			Me.New(firstName, secondName)
			Me.comments = comments
		End Sub
		Public Sub New()

		End Sub
		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				firstName_Renamed = value
			End Set
		End Property
		Public Property SecondName() As String
			Get
				Return secondName_Renamed
			End Get
			Set(ByVal value As String)
				secondName_Renamed = value
			End Set
		End Property
		Public Property Info() As String
			Get
				Return comments
			End Get
			Set(ByVal value As String)
				comments = value
			End Set
		End Property
	End Class
End Namespace