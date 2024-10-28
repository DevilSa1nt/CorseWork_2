using CrystalDecisions.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Coursework_WinForms_Framework
{
    public partial class MainForm : Form
    {
        private MainFormCore _core;

        #region Main tab's properties
        public DataGridView BattlesuitsDataGid
        {
            get { return _battlesuitsDataGrid; }
        }

        public System.Windows.Forms.DataVisualization.Charting.Chart BattlesuitsStatsChart
        {
            get { return _battlesuitsStatsChart; }
        }

        public ComboBox SelectParamToChartComboBox
        {
            get { return _selectParamToChartComboBox; }
        }
        #endregion

        #region Add battlesuit tab's properties
        public TextBox NameAddTextBox
        {
            get { return nameAddTextBox;}
        }
        public TextBox BattlesuitNameAddTextBox
        {
            get { return battlesuitNameAddTextBox; }
        }
        public TextBox BirthdayAddTextBox
        {
            get { return birthdayAddTextBox; }
        }
        public TextBox OriginAddTextBox
        {
            get { return originAddTextBox; }
        }
        public TextBox HeightAddTextBox
        {
            get { return heightAddTextBox; }
        }
        public TextBox WeightAddTextBox
        {
            get { return weightAddTextBox; }
        }
        public TextBox TypeAddTextBox
        {
            get { return typeAddTextBox; }
        }
        public TextBox ElementAddTextBox
        {
            get { return elementAddTextBox; }
        }
        public TextBox DMGAddTextBox
        {
            get { return dmgAddTextBox; }
        }
        public TextBox BurstAddTextBox
        {
            get { return burstAddTextBox; }
        }
        public TextBox SurvivalAddTextBox
        {
            get { return survivalAddTextBox; }
        }
        public TextBox SupportAddTextBox
        {
            get { return supportAddTextBox; }
        }
        public TextBox EaseAddTextBox
        {
            get { return easeAddTextBox; }
        }
        public TextBox ControlAddTextBox
        {
            get { return controlAddTextBox; }
        }

        public Label Label1
        {
            get { return label1; }
        }
        public Label Label2
        {
            get { return label2; }
        }
        public Label Label3
        {
            get { return label3; }
        }
        public Label Label4
        {
            get { return label4; }
        }
        public Label Label5
        {
            get { return label5; }
        }
        public Label Label6
        {
            get { return label6; }
        }
        public Label Label7
        {
            get { return label7; }
        }
        public Label Label8
        {
            get { return label8; }
        }
        public Label Label9
        {
            get { return label9; }
        }
        public Label Label10
        {
            get { return label10; }
        }
        public Label Label11
        {
            get { return label11; }
        }
        public Label Label12
        {
            get { return label12; }
        }
        public Label Label13
        {
            get { return label13; }
        }
        public Label Label14
        {
            get { return label14; }
        }

        public Button AddButton
        {
            get { return _addButton;}
        }
        #endregion

        #region Edit battlesuit tab's properties
        public TextBox IdTextBox
        {
            get { return idTaxtBox;}
        }

        public TextBox NameEditTextBox
        {
            get { return nameEditTextBox; }
        }
        public TextBox BattlesuitNameEditTextBox
        {
            get { return battlesuitNameEditTextBox; }
        }
        public TextBox BirthdayEditTextBox
        {
            get { return birthdayEditTextBox; }
        }
        public TextBox OriginEditTextBox
        {
            get { return originEditTextBox; }
        }
        public TextBox HeightEditTextBox
        {
            get { return heightEditTextBox; }
        }
        public TextBox WeightEditTextBox
        {
            get { return weightEditTextBox; }
        }
        public TextBox TypeEditTextBox
        {
            get { return typeEditTextBox; }
        }
        public TextBox ElementEditTextBox
        {
            get { return elementEditTextBox; }
        }
        public TextBox DMGEditTextBox
        {
            get { return dmgEditTextBox; }
        }
        public TextBox BurstEditTextBox
        {
            get { return burstEditTextBox; }
        }
        public TextBox SurvivalEditTextBox
        {
            get { return survivalEditTextBox; }
        }
        public TextBox SupportEditTextBox
        {
            get { return supportEditTextBox; }
        }
        public TextBox EaseEditTextBox
        {
            get { return easeEditTextBox; }
        }
        public TextBox ControlEditTextBox
        {
            get { return controlEditTextBox; }
        }

        public Label Label28
        {
            get { return label28;}
        }
        public Label Label27
        {
            get { return label27;}
        }
        public Label Label26
        {
            get { return label26;}
        }
        public Label Label25
        {
            get { return label25;}
        }
        public Label Label24
        {
            get { return label24;}
        }
        public Label Label23
        {
            get { return label23;}
        }
        public Label Label22
        {
            get { return label22;}
        }
        public Label Label21
        {
            get { return label21;}
        }
        public Label Label20
        {
            get { return label20;}
        }
        public Label Label19
        {
            get { return label19;}
        }
        public Label Label18
        {
            get { return label18;}
        }
        public Label Label17
        {
            get { return label17; }
        }
        public Label Label16
        {
            get { return label16;}
        }
        public Label Label15
        {
            get { return label15;}
        }

        public Button FindButton
        {
            get { return _findButton;}
        }
        public Button EditButton
        {
            get { return _editButton;}
        }
        public Button DeleteButton
        {
            get { return _deleteButton;}
        }
        public Button CancelButton
        {
            get { return _cancelButton;}
        }

        #endregion

        #region Crystal report tab's properties
        public CrystalReportViewer CrystalReportViewer1
        {
            get { return crystalReportViewer1; }
        }

        public RichTextBox QueriesRichTextBox
        {
            get { return _queriesRichTextBox; }
        }

        public Button AcceptQueryButton
        {
            get { return _acceptQueryButton; }
        }
        public Button ClearQueriesButton
        {
            get { return _clearQueriesButton; }
        }


        public TextBox ParamValueTextBox
        {
            get { return _paramValueTextBox; }
        }
        public ComboBox ParamConditionComboBox
        {
            get { return _paramConditionComboBox; }
        }
        public ComboBox ParamNameComboBox
        {
            get { return _paramNameComboBox; }
        }
        #endregion

        public MainForm()
        {
            InitializeComponent();

            _core = new MainFormCore(this);

            this.Load += _core.MainForm_Load;

            _selectParamToChartComboBox.SelectedIndexChanged += _core._selectParamToChartComboBox_SelectedIndexChanged;

            _addButton.Click += _core._addButton_Click;
            _findButton.Click += _core._findButton_Click;
            _editButton.Click += _core._editButton_Click;
            _deleteButton.Click += _core._deleteButton_Click;
            _cancelButton.Click += _core._cancelButton_Click;
            _paramNameComboBox.SelectedValueChanged += _core._paramNameComboBox_SelectedValueChanged;
            _acceptQueryButton.Click += _core._acceptQueryButton_Click;
            _clearQueriesButton.Click += _core._clearQueriesButton_Click;
        }

        public void ChangeDataSet(IEnumerable<Battlesuite> battlesuites)
        {
            _core.ChangeDataSet(battlesuites);
        }
    }
}