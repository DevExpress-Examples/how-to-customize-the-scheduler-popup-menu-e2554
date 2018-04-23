Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Services
Imports DevExpress.XtraScheduler.Commands
' ...
#End Region ' #usings


Namespace PopupMenuCustomization
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            MySchedulerHelper.FillResources(schedulerStorage1, 3)
            schedulerControl1.Views.DayView.DayCount = 2
            schedulerControl1.Start = Date.Now.Date
            schedulerControl1.DateNavigationBar.Visible = False
            schedulerControl1.ActiveView.NavigationButtonVisibility = NavigationButtonVisibility.Never
        End Sub

#Region "#popupmenushowing"
Private Sub schedulerControl1_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs) Handles schedulerControl1.PopupMenuShowing
    If e.Menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu Then
        ' Hide the "Change View To" menu item.
        Dim itemChangeViewTo As SchedulerPopupMenu = e.Menu.GetPopupMenuById(SchedulerMenuItemId.SwitchViewMenu)
        itemChangeViewTo.Visible = False

        ' Remove unnecessary items.
        e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent)

        ' Disable the "New Recurring Appointment" menu item.
        e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringAppointment)

        ' Find the "New Appointment" menu item and rename it.
        Dim item As SchedulerMenuItem = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment)
                If item IsNot Nothing Then
                    item.Caption = "&New Meeting"
                    item.Image = Image.FromFile("NewItem_16x16.png")
                End If

        ' Create a menu item for the Scheduler command.
        Dim service As ISchedulerCommandFactoryService = schedulerControl1.GetService(Of ISchedulerCommandFactoryService)()
        Dim cmd As SchedulerCommand = service.CreateCommand(SchedulerCommandId.SwitchToGroupByResource)
        Dim menuItemCommandAdapter As New SchedulerMenuItemCommandWinAdapter(cmd)
        Dim menuItem As DXMenuItem = CType(menuItemCommandAdapter.CreateMenuItem(DXMenuItemPriority.Normal), DXMenuItem)
        menuItem.BeginGroup = True
        e.Menu.Items.Add(menuItem)

        ' Insert a new item into the Scheduler popup menu and handle its click event.
        e.Menu.Items.Add(New SchedulerMenuItem("Click me!", AddressOf MyClickHandler))
    End If
End Sub

Public Sub MyClickHandler(ByVal sender As Object, ByVal e As EventArgs)
    MessageBox.Show("My Menu Item Clicked!")
End Sub
#End Region ' #popupmenushowing
    End Class
End Namespace