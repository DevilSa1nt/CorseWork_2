using Coursework_WinForms_Framework.WorkWithData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Coursework_WinForms_Framework
{
    /// <summary>
    /// Class that contains main logic
    /// </summary>
    internal class MainFormCore
    {
        private MainForm _mainForm;
        private CrystalReport1 cr;
        private List<Battlesuite> battlesuites;
        private DataSet1 ds1;
        private Dictionary<string, double> dc;
        private AddNewBattlesuitsCore _addNewBattlesuitsCore;
        private EditBattlesuitInfoCore _editBattlesuitInfoCore;
        private QueriesCore _queriesCore;

        /// <summary>
        /// Сlass constructor
        /// </summary>
        /// <param name="mainForm"></param>
        public MainFormCore(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        #region Events
        /// <summary>
        /// Event fired when MainForm is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MainForm_Load(object sender, EventArgs e)
        {
            WorkWithJson.WriteToJson();
            battlesuites = WorkWithJson.ReadFromJson();

            _addNewBattlesuitsCore = new AddNewBattlesuitsCore(_mainForm);
            _editBattlesuitInfoCore = new EditBattlesuitInfoCore(_mainForm);
            _queriesCore = new QueriesCore(_mainForm);

            int errorIndex = CheckBattlesuitsNames();

            if (errorIndex == -1)
            {
                InitDataSet();
                InitCrystalReport();
                InitChart();
                InitDataGrid();
                InitComboBoxes();

                _mainForm.SelectParamToChartComboBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(
                    "Battlesuit name must not be repeated\n" +
                    $"Please correct the Battlesuite name field in line {errorIndex}"
                    );
            }
        }

        #region Main tab
        /// <summary>
        /// Event fired when _selectParamToChartComboBox's selected index is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _selectParamToChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeChart(((System.Windows.Forms.ComboBox)sender).SelectedIndex);
        }
        #endregion

        #region  Add battlesuit tab
        /// <summary>
        /// vEvent fired when _addButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _addButton_Click(object sender, EventArgs e)
        {
            _addNewBattlesuitsCore._addButton_Click();

            ReInit();
        }
        #endregion

        #region Edit battlesuit tab
        /// <summary>
        /// Event fired when _findButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _findButton_Click(object sender, EventArgs e)
        {
            _editBattlesuitInfoCore._findButton_Click();
        }

        /// <summary>
        /// Event fired when _editButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _editButton_Click(object sender, EventArgs e)
        {
            _editBattlesuitInfoCore._editButton_Click();

            ReInit();
        }

        /// <summary>
        /// Event fired when _deleteButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _deleteButton_Click(object sender, EventArgs e)
        {
            _editBattlesuitInfoCore._deleteButton_Click();

            ReInit();
        }

        /// <summary>
        /// Event fired when _cancelButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _cancelButton_Click(object sender, EventArgs e)
        {
            _editBattlesuitInfoCore._cancelButton_Click();
        }
        #endregion

        #region Crystal report tab
        /// <summary>
        /// Event fired when _acceptQueryButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _acceptQueryButton_Click(object sender, EventArgs e)
        {
            _queriesCore._acceptQueryButton_Click();
        }

        /// <summary>
        /// Event fired when _clearQueriesButton is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _clearQueriesButton_Click(object sender, EventArgs e)
        {
            _queriesCore._clearQueriesButton_Click();
        }

        /// <summary>
        /// Event fired when _paramNameComboBox's selectes value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _paramNameComboBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            _queriesCore._paramNameComboBox_SelectedValueChanged();
        }

        #endregion


        #endregion
        /// <summary>
        /// Change chart
        /// </summary>
        /// <param name="param"> Index of param </param>
        private void ChangeChart(int param)
        {
            if (param >= 0)
            {
                dc = new Dictionary<string, double>();

                _mainForm.BattlesuitsStatsChart.Series[0].Points.Clear();

                for (int i = 0; i < battlesuites.Count; i++)
                {
                    dc.Add(battlesuites[i].BattlesuiteName, battlesuites[i].GetStats()[param]);
                }

                foreach (var item in dc)
                {
                    _mainForm.BattlesuitsStatsChart.Series[0].Points.AddXY(item.Key, item.Value);
                }

                _mainForm.BattlesuitsStatsChart.Invalidate();

                string newParam = _mainForm.SelectParamToChartComboBox.Items[param].ToString();

                _mainForm.BattlesuitsStatsChart.Series[0].Name = newParam;
            }
            else
            {

            }
        }

        /// <summary>
        /// Check is there are any battlesuits with same name
        /// </summary>
        /// <returns> If there are any battlesuts with same name return index of second one. Else return -1</returns>
        private int CheckBattlesuitsNames()
        {
            string[] bsNames = new string[battlesuites.Count];

            for(int i = 0; i < bsNames.Length; i++)
            {
                if (!bsNames.Contains(battlesuites[i].BattlesuiteName))
                {
                    bsNames[i] = battlesuites[i].BattlesuiteName;
                }
                else
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Reinit all components
        /// </summary>
        private void ReInit()
        {
            battlesuites = WorkWithJson.ReadFromJson();

            InitDataGrid();
            InitDataSet();
            InitChart();
            InitCrystalReport();
        }

        #region Init
        /// <summary>
        /// Init datagrid
        /// </summary>
        private void InitDataGrid()
        {
            _mainForm.BattlesuitsDataGid.DataSource = battlesuites;
        }

        /// <summary>
        /// Init dataset
        /// </summary>
        private void InitDataSet()
        {
            ds1 = new DataSet1();

            for (int i = 0; i < battlesuites.Count; i++)
            {
                var b = battlesuites[i];

                DataRow dr = ds1.DataTable1.NewRow();

                for (int j = 0; j <= 14; j++)
                {
                    dr[j] = b[j];
                }

                ds1.DataTable1.Rows.Add(dr);
            }
        }

        /// <summary>
        /// Change dataset
        /// </summary>
        /// <param name="battlesuites"> New data</param>
        public void ChangeDataSet(IEnumerable<Battlesuite> battlesuites)
        {
            if(battlesuites != null)
            {
                ds1 = new DataSet1();

                foreach (var b in battlesuites)
                {
                    DataRow dr = ds1.DataTable1.NewRow();

                    for (int j = 0; j <= 14; j++)
                    {
                        dr[j] = b[j];
                    }

                    ds1.DataTable1.Rows.Add(dr);
                }

                InitCrystalReport();
            }
        }

        /// <summary>
        /// Init chart
        /// </summary>
        private void InitChart()
        {
            dc = new Dictionary<string, double>();

            for (int i = 0; i < battlesuites.Count; i++)
            {
                dc.Add(battlesuites[i].BattlesuiteName, battlesuites[i].DMG);
            }

            _mainForm.BattlesuitsStatsChart.Series[0].Points.Clear();

            foreach (var item in dc)
            {
                _mainForm.BattlesuitsStatsChart.Series[0].Points.AddXY(item.Key, item.Value);
            }

            _mainForm.BattlesuitsStatsChart.ChartAreas[0].AxisX.Interval = 1;
        }

        /// <summary>
        /// Init CrustalReport
        /// </summary>
        private void InitCrystalReport()
        {
            cr = new CrystalReport1();

            cr.SetDataSource(ds1);

            _mainForm.CrystalReportViewer1.ReportSource = cr;
            cr.Refresh();
        }

        /// <summary>
        /// Init all comboBoxes
        /// </summary>
        private void InitComboBoxes()
        {
            string[] names = Battlesuite.GetAtributes();

            for (int i = 0; i <names.Length; i++)
            {
                _mainForm.ParamNameComboBox.Items.Add(names[i].Split('_')[0]);
            }
        }
        #endregion
    }
}
