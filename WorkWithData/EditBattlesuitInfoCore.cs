using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Coursework_WinForms_Framework.WorkWithData
{
    /// <summary>
    /// 
    /// </summary>
    internal class EditBattlesuitInfoCore
    {
        private MainForm _mainForm;
        private List<Battlesuite> battlesuites;
        private string prevBsName;

        /// <summary>
        /// Сlass constructor
        /// </summary>
        /// <param name="form"> Referecse to MainForm </param>
        public EditBattlesuitInfoCore(MainForm form)
        {
            _mainForm = form;
        }

        /// <summary>
        /// Event fired when _findButton is pressed
        /// </summary>
        public void _findButton_Click()
        {
            string strId = _mainForm.IdTextBox.Text;

            int id = 0;

            _mainForm.IdTextBox.Enabled = false;

            battlesuites = WorkWithJson.ReadFromJson();

            if (int.TryParse(strId, out id) & id >= 0 & id < battlesuites.Count)
            {

                Battlesuite battlesuite = battlesuites[id - 1];

                _mainForm.NameEditTextBox.Text = battlesuite.Name;
                _mainForm.BattlesuitNameEditTextBox.Text = battlesuite.BattlesuiteName;
                _mainForm.BirthdayEditTextBox.Text = battlesuite.Birthday.ToShortDateString();
                _mainForm.OriginEditTextBox.Text = battlesuite.Origin;
                _mainForm.HeightEditTextBox.Text = battlesuite.Height.ToString();
                _mainForm.WeightEditTextBox.Text = battlesuite.Weight.ToString();
                _mainForm.TypeEditTextBox.Text = battlesuite.Type;
                _mainForm.ElementEditTextBox.Text = battlesuite.Element;

                _mainForm.DMGEditTextBox.Text = battlesuite.DMG.ToString();
                _mainForm.BurstEditTextBox.Text = battlesuite.Burst.ToString();
                _mainForm.SurvivalEditTextBox.Text = battlesuite.Survival.ToString();
                _mainForm.SupportEditTextBox.Text = battlesuite.Support.ToString();
                _mainForm.EaseEditTextBox.Text = battlesuite.Ease.ToString();
                _mainForm.ControlEditTextBox.Text = battlesuite.Control.ToString();

                _mainForm.EditButton.Enabled = true;
                _mainForm.DeleteButton.Enabled = true;
                _mainForm.CancelButton.Enabled = true;

                prevBsName = battlesuite.BattlesuiteName;
            }
            else
            {
                Message_Invalid("id", "Id");
            }
        }

        /// <summary>
        /// Event fired when _editButton is pressed
        /// </summary>
        public void _editButton_Click()
        {
            bool bIsOk = true;

            if (_mainForm.BattlesuitNameEditTextBox.Text != prevBsName)
            {
                for(int i = 0; i < battlesuites.Count; i++)
                {
                    if(prevBsName == battlesuites[i].BattlesuiteName)
                    {
                        bIsOk = false;
                    }
                }
            }

            if(bIsOk)
            {
                string[] atr = new string[14];

                atr[0] = _mainForm.NameEditTextBox.Text;
                atr[1] = _mainForm.BattlesuitNameEditTextBox.Text;

                atr[2] = _mainForm.BirthdayEditTextBox.Text;

                atr[3] = _mainForm.OriginEditTextBox.Text;

                atr[4] = _mainForm.HeightEditTextBox.Text;
                atr[5] = _mainForm.WeightEditTextBox.Text;

                atr[6] = _mainForm.TypeEditTextBox.Text;
                atr[7] = _mainForm.ElementEditTextBox.Text;

                atr[8] = _mainForm.DMGEditTextBox.Text;
                atr[9] = _mainForm.BurstEditTextBox.Text;
                atr[10] = _mainForm.SurvivalEditTextBox.Text;
                atr[11] = _mainForm.SupportEditTextBox.Text;
                atr[12] = _mainForm.EaseEditTextBox.Text;
                atr[13] = _mainForm.ControlEditTextBox.Text;

                bool bBirthday = DateTime.TryParse(atr[2], out DateTime d);
                bool bHeight = double.TryParse(atr[4], out double h);
                bool bWeight = double.TryParse(atr[5], out double w);
                bool bDMG = double.TryParse(atr[8], out double dmg);
                bool bBurst = double.TryParse(atr[9], out double bur);
                bool bSurvival = double.TryParse(atr[10], out double sur);
                bool bSupport = double.TryParse(atr[11], out double sup);
                bool bEase = double.TryParse(atr[12], out double e);
                bool bControl = double.TryParse(atr[13], out double c);

                if ((bBirthday | atr[2] == "-") &
                    (bHeight | atr[4] == "-") &
                    (bWeight | atr[5] == "-") &
                    (bDMG | atr[8] == "-") &
                    (bBurst | atr[9] == "-") &
                    (bSurvival | atr[10] == "-") &
                    (bSupport | atr[11] == "-") &
                    (bEase | atr[12] == "-") &
                    (bControl | atr[13] == "-"))
                {
                    string a = atr[0];

                    for (int i = 1; i < atr.Length; i++)
                    {
                        a += $";{atr[i]}";
                    }

                    WorkWithJson.WrightToTxt(a, int.Parse(_mainForm.IdTextBox.Text) - 1);

                    _mainForm.NameEditTextBox.Text = "";
                    _mainForm.BattlesuitNameEditTextBox.Text = "";
                    _mainForm.BirthdayEditTextBox.Text = "";
                    _mainForm.OriginEditTextBox.Text = "";
                    _mainForm.HeightEditTextBox.Text = "";
                    _mainForm.WeightEditTextBox.Text = "";
                    _mainForm.TypeEditTextBox.Text = "";
                    _mainForm.ElementEditTextBox.Text = "";

                    _mainForm.DMGEditTextBox.Text = "";
                    _mainForm.BurstEditTextBox.Text = "";
                    _mainForm.SurvivalEditTextBox.Text = "";
                    _mainForm.SupportEditTextBox.Text = "";
                    _mainForm.EaseEditTextBox.Text = "";
                    _mainForm.ControlEditTextBox.Text = "";

                    _mainForm.EditButton.Enabled = false;
                    _mainForm.DeleteButton.Enabled = false;
                    _mainForm.CancelButton.Enabled = false;

                    _mainForm.IdTextBox.Enabled = true;
                }
                else
                {
                    if (!bBirthday & atr[2] != "-")
                    {
                        Message_Invalid("birthday", "Birthday");
                    }
                    if (!bHeight & atr[4] != "-")
                    {
                        Message_Invalid("height", "Height");
                    }
                    if (!bWeight & atr[5] != "-")
                    {
                        Message_Invalid("weight", "Weight");
                    }
                    if (!bDMG & atr[8] != "-")
                    {
                        Message_Invalid("dmg", "DMG");
                    }
                    if (!bBurst & atr[9] != "-")
                    {
                        Message_Invalid("burst", "Burst");
                    }
                    if (!bSurvival & atr[10] != "-")
                    {
                        Message_Invalid("survival", "Survival");
                    }
                    if (!bSupport & atr[11] != "-")
                    {
                        Message_Invalid("support", "Support");
                    }
                    if (!bEase & atr[12] != "-")
                    {
                        Message_Invalid("ease", "Ease");
                    }
                    if (!bControl & atr[13] != "-")
                    {
                        Message_Invalid("control", "Control");
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Battlesuit name must not be repeated\n" +
                    "Please correct the Battlesuite name field"
                    );
            }
        }

        /// <summary>
        /// Event fired when _deleteButton is pressed
        /// </summary>
        public void _deleteButton_Click()
        {
            WorkWithJson.DeleteRowFromTXT(int.Parse(_mainForm.IdTextBox.Text) - 1);

            _mainForm.NameEditTextBox.Text = "";
            _mainForm.BattlesuitNameEditTextBox.Text = "";
            _mainForm.BirthdayEditTextBox.Text = "";
            _mainForm.OriginEditTextBox.Text = "";
            _mainForm.HeightEditTextBox.Text = "";
            _mainForm.WeightEditTextBox.Text = "";
            _mainForm.TypeEditTextBox.Text = "";
            _mainForm.ElementEditTextBox.Text = "";

            _mainForm.DMGEditTextBox.Text = "";
            _mainForm.BurstEditTextBox.Text = "";
            _mainForm.SurvivalEditTextBox.Text = "";
            _mainForm.SupportEditTextBox.Text = "";
            _mainForm.EaseEditTextBox.Text = "";
            _mainForm.ControlEditTextBox.Text = "";

            _mainForm.EditButton.Enabled = false;
            _mainForm.DeleteButton.Enabled = false;
            _mainForm.CancelButton.Enabled = false;

            _mainForm.IdTextBox.Enabled = true;
        }

        /// <summary>
        /// Event fired when _cancelButton is pressed
        /// </summary>
        public void _cancelButton_Click()
        {
            _mainForm.NameEditTextBox.Text = "";
            _mainForm.BattlesuitNameEditTextBox.Text = "";
            _mainForm.BirthdayEditTextBox.Text = "";
            _mainForm.OriginEditTextBox.Text = "";
            _mainForm.HeightEditTextBox.Text = "";
            _mainForm.WeightEditTextBox.Text = "";
            _mainForm.TypeEditTextBox.Text = "";
            _mainForm.ElementEditTextBox.Text = "";

            _mainForm.DMGEditTextBox.Text = "";
            _mainForm.BurstEditTextBox.Text = "";
            _mainForm.SurvivalEditTextBox.Text = "";
            _mainForm.SupportEditTextBox.Text = "";
            _mainForm.EaseEditTextBox.Text = "";
            _mainForm.ControlEditTextBox.Text = "";

            _mainForm.EditButton.Enabled = false;
            _mainForm.DeleteButton.Enabled = false;
            _mainForm.CancelButton.Enabled = false;

            _mainForm.IdTextBox.Enabled = true;
        }

        /// <summary>
        /// Show message when there are some errors
        /// </summary>
        /// <param name="param1">Invalid param name</param>
        /// <param name="param2">Invalid field name</param>
        private void Message_Invalid(string param1, string param2)
        {
            MessageBox.Show(
                $"Invalid {param1} format\n" +
                $"Please correct the {param2} field"
                );
        }
    }
}
