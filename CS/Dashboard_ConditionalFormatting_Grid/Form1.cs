using DevExpress.DashboardCommon;
using System.Drawing;

namespace Grid_IconRangeCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            Dashboard dashboard = new Dashboard(); dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];

            GridItemFormatRule rangeRule = new GridItemFormatRule(extendedPrice);
            FormatConditionGradientRangeBar rangeBarCondition =
                new FormatConditionGradientRangeBar(FormatConditionRangeGradientPredefinedType.BlueRed);
            rangeBarCondition.BarOptions.ShowBarOnly = true;
            rangeRule.Condition = rangeBarCondition;

            grid.FormatRules.AddRange(rangeRule);
        }

        private void button1_Click(object sender, System.EventArgs e) {
            GridDashboardItem grid = (GridDashboardItem)dashboardViewer1.Dashboard.Items[0];
            GridItemFormatRule rangeRule = grid.FormatRules[0];

            FormatConditionGradientRangeBar rangeCondition =
                (FormatConditionGradientRangeBar)rangeRule.Condition;
            rangeCondition.Generate(new BarStyleSettings(Color.PaleVioletRed),
                                    new BarStyleSettings(Color.PaleGreen), 9);
            RangeInfo middleRange = rangeCondition.RangeSet[4];
            middleRange.StyleSettings = new BarStyleSettings(Color.SkyBlue);

            rangeRule.Condition = rangeCondition;
        }
    }
}
