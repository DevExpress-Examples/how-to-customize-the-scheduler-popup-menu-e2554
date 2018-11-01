Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraScheduler

Namespace PopupMenuCustomization
    Friend Class MySchedulerHelper
        Public Shared Users() As String = { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett", "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" }
        Public Shared Sub FillResources(ByVal storage As SchedulerDataStorage, ByVal count As Integer)
            Dim resources As ResourceCollection = storage.Resources.Items
            Dim cnt As Integer = Math.Min(count, Users.Length)
            For i As Integer = 1 To cnt
                Dim resource As Resource = storage.CreateResource(i)
                resource.Caption = Users(i - 1)
                resources.Add(resource)
            Next i
        End Sub
    End Class
End Namespace
