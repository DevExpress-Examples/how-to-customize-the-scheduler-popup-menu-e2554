Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraScheduler

Namespace PopupMenuCustomization
	Friend Class Helper
		Public Shared Users() As String = { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett", "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" }
		Public Shared Sub FillResources(ByVal storage As SchedulerStorage, ByVal count As Integer)
			Dim resources As ResourceCollection = storage.Resources.Items
			storage.BeginUpdate()
			Try
				Dim cnt As Integer = Math.Min(count, Users.Length)
				For i As Integer = 1 To cnt
					Dim resource As Resource = storage.CreateResource(i)
					resource.Caption = Users(i - 1)
					resources.Add(resource)
				Next i
			Finally
				storage.EndUpdate()
			End Try
		End Sub

	End Class
End Namespace
