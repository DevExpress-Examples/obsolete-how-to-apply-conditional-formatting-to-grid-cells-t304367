Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports System.Drawing

Namespace Grid_IconRangeCondition
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
			AddHandler dashboardViewer1.CustomizeDashboardTitle, AddressOf DashboardViewer1_CustomizeDashboardTitle
			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
			dashboardViewer1.Dashboard = dashboard
			Dim grid As GridDashboardItem = CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
			Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)

			Dim rangeRule As New GridItemFormatRule(extendedPrice)
			Dim rangeBarCondition As New FormatConditionGradientRangeBar(FormatConditionRangeGradientPredefinedType.BlueRed)
			rangeBarCondition.BarOptions.ShowBarOnly = True
			rangeRule.Condition = rangeBarCondition

			grid.FormatRules.AddRange(rangeRule)
		End Sub

		Private Sub DashboardViewer1_CustomizeDashboardTitle(ByVal sender As Object, ByVal e As CustomizeDashboardTitleEventArgs)
			Dim itemUpdate As New DashboardToolbarItem(Sub(args) UpdateFormatting()) With {.Caption = "Update Formatting"}
			e.Items.Add(itemUpdate)
		End Sub

		Private Sub UpdateFormatting()
			Dim grid As GridDashboardItem = CType(dashboardViewer1.Dashboard.Items(0), GridDashboardItem)
			Dim rangeRule As GridItemFormatRule = grid.FormatRules(0)

			Dim rangeCondition As FormatConditionGradientRangeBar = CType(rangeRule.Condition, FormatConditionGradientRangeBar)
			rangeCondition.Generate(New BarStyleSettings(Color.PaleVioletRed), New BarStyleSettings(Color.PaleGreen), 9)
			Dim middleRange As RangeInfo = rangeCondition.RangeSet(4)
			middleRange.StyleSettings = New BarStyleSettings(Color.SkyBlue)

			rangeRule.Condition = rangeCondition
		End Sub
	End Class
End Namespace
