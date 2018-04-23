Imports DevExpress.DashboardCommon
Imports System.Drawing

Namespace Grid_IconRangeCondition
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            dashboardViewer1.Dashboard = dashboard
            Dim grid As GridDashboardItem = CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
            Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)

            Dim rangeRule As New GridItemFormatRule(extendedPrice)
            Dim rangeBarCondition As New  _
                FormatConditionGradientRangeBar(FormatConditionRangeGradientPredefinedType.BlueRed)
            rangeBarCondition.BarOptions.ShowBarOnly = True
            rangeRule.Condition = rangeBarCondition

            grid.FormatRules.AddRange(rangeRule)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            Dim grid As GridDashboardItem = CType(dashboardViewer1.Dashboard.Items(0), GridDashboardItem)
            Dim rangeRule As GridItemFormatRule = grid.FormatRules(0)

            Dim rangeCondition As FormatConditionGradientRangeBar =
                CType(rangeRule.Condition, FormatConditionGradientRangeBar)
            rangeCondition.Generate(New BarStyleSettings(Color.PaleVioletRed),
                                    New BarStyleSettings(Color.PaleGreen), 9)
            Dim middleRange As RangeInfo = rangeCondition.RangeSet(4)
            middleRange.StyleSettings = New BarStyleSettings(Color.SkyBlue)

            rangeRule.Condition = rangeCondition
        End Sub
    End Class
End Namespace
