using System;
using System.Collections.Generic;
using System.Windows;

namespace Coursework_WinForms_Framework
{
    internal class AddNewBattlesuitsCore
    {
        private MainForm _mainForm;
        private List<Battlesuite> battlesuites;

        /// <summary>
        /// Сlass constructor
        /// </summary>
        /// <param name="form"> Referecse to MainForm </param>
        public AddNewBattlesuitsCore(MainForm form)
        {
            _mainForm = form;
        }

        /// <summary>
        /// Event fired when _addButton is pressed 
        /// </summary>
        public void _addButton_Click()
        {
            bool bIsOk = true;

            battlesuites = WorkWithJson.ReadFromJson();

            for (int i = 0; i < battlesuites.Count; i++)
            {
                if (_mainForm.BattlesuitNameAddTextBox.Text == battlesuites[i].BattlesuiteName)
                {
                    bIsOk = false;
                }
            }

            if(bIsOk)
            {
                string[] atr = new string[14];

                atr[0] = _mainForm.NameAddTextBox.Text;
                atr[1] = _mainForm.BattlesuitNameAddTextBox.Text;

                atr[2] = _mainForm.BirthdayAddTextBox.Text;

                atr[3] = _mainForm.OriginAddTextBox.Text;

                atr[4] = _mainForm.HeightAddTextBox.Text;
                atr[5] = _mainForm.WeightAddTextBox.Text;

                atr[6] = _mainForm.TypeAddTextBox.Text;
                atr[7] = _mainForm.ElementAddTextBox.Text;

                atr[8] = _mainForm.DMGAddTextBox.Text;
                atr[9] = _mainForm.BurstAddTextBox.Text;
                atr[10] = _mainForm.SurvivalAddTextBox.Text;
                atr[11] = _mainForm.SupportAddTextBox.Text;
                atr[12] = _mainForm.EaseAddTextBox.Text;
                atr[13] = _mainForm.ControlAddTextBox.Text;

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

                    WorkWithJson.WrightToTxt(a);
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
