using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursework_WinForms_Framework.WorkWithData
{
    /// <summary>
    /// Class which work with LINQ queries
    /// </summary>
    internal class QueriesCore
    {
        private MainForm _mainForm;
        private IEnumerable<Battlesuite> iebs;
        private List<Battlesuite> bs;

        /// <summary>
        /// Сlass constructor
        /// </summary>
        /// <param name="mainForm"> Referecse to MainForm </param>
        public QueriesCore(MainForm mainForm)
        {
            _mainForm = mainForm;

            Init();
        }

        /// <summary>
        /// Init main components of this class
        /// </summary>
        private void Init()
        {
            iebs = null;
            bs = WorkWithJson.ReadFromJson();

            iebs = from b in bs
                   select b;
        }

        /// <summary>
        /// Event fired when _acceptQueryButton is pressed
        /// </summary>
        public void _acceptQueryButton_Click()
        {
            string name = _mainForm.ParamNameComboBox.Text;
            string condition = _mainForm.ParamConditionComboBox.Text;
            string value = _mainForm.ParamValueTextBox.Text;

            bool bIsQueryOk = false;

            switch (name)
            {
                case "name":
                case "battlesuiteName":
                case "origin":
                case "type":
                case "element":
                    {
                        switch(condition)
                        {
                            case "Equal":
                                {
                                    iebs = from b in iebs
                                         where (string)b[name] == value
                                         select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "Unequal":
                                {
                                    iebs = from b in iebs
                                           where (string)b[name] != value
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "Contain":
                                {
                                    bool bbb = bs[0].Name.Contains(value);

                                    iebs = from b in iebs
                                           where ((string)b[name]).Contains(value)
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "Doesn't conrain":
                                {
                                    iebs = from b in iebs
                                           where !((string)b[name]).Contains(value)
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }   
                        }

                        break;
                    }

                case "weight":
                case "DMG":
                case "burst":
                case "survival":
                case "support":
                case "ease":
                case "control":
                    {
                        double dValue;
                        bool bIsValueOk = Double.TryParse(value, out dValue);

                        if(bIsValueOk == false)
                        {


                            break;
                        }

                        switch(condition)
                        {
                            case ">":
                                {
                                    iebs = from b in iebs
                                           where (double)(b[name]) > dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case ">=":
                                {
                                    iebs = from b in iebs
                                           where (double)b[name] >= dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "<":
                                {
                                    iebs = from b in iebs
                                           where (double)b[name] < dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "<=":
                                {
                                    iebs = from b in iebs
                                           where (double)b[name] <= dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "=":
                                {
                                    iebs = from b in iebs
                                           where (double)b[name] == dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "!=":
                                {
                                    iebs = from b in iebs
                                           where (double)b[name] != dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                        }

                        break;
                    }

                case "id":
                case "height":
                    {
                        int dValue;
                        bool bIsValueOk = int.TryParse(value, out dValue);

                        if (bIsValueOk == false)
                        {
                            break;
                        }

                        switch (condition)
                        {
                            case ">":
                                {
                                    iebs = from b in iebs
                                           where (int)(b[name]) > dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case ">=":
                                {
                                    iebs = from b in iebs
                                           where (int)b[name] >= dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "<":
                                {
                                    iebs = from b in iebs
                                           where (int)b[name] < dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "<=":
                                {
                                    iebs = from b in iebs
                                           where (int)b[name] <= dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "=":
                                {
                                    iebs = from b in iebs
                                           where (int)b[name] == dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "!=":
                                {
                                    iebs = from b in iebs
                                           where (int)b[name] != dValue
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                        }

                        break;
                    }

                case "birthday":
                    {
                        switch(condition)
                        {
                            case "Day equal":
                                {
                                    int day;
                                    bool bIsDay = int.TryParse(value, out day);

                                    if(bIsDay == false)
                                    {
                                        break;
                                    }

                                    iebs = from b in iebs
                                           where ((DateTime)b[name]).Day == day
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }

                            case "Month equal":
                                {
                                    int month;
                                    bool bIsMonth = int.TryParse(value, out month);

                                    if (bIsMonth == false)
                                    {
                                        break;
                                    }

                                    iebs = from b in iebs
                                           where ((DateTime)b[name]).Month == month
                                           select b;

                                    bIsQueryOk = true;

                                    break;
                                }
                            case "After date":
                                {
                                    int day;
                                    int month;

                                    bool bIsDay = int.TryParse(value, out day);
                                    bool bIsMonth = int.TryParse(value, out month);

                                    if(bIsDay && bIsMonth)
                                    {
                                        iebs = from b in iebs
                                               where ((DateTime)b[name]).CompareTo(new DateTime(2000, month, day)) > 0
                                               select b;

                                        bIsQueryOk = true;
                                    }

                                    break;
                                }

                            case "Befor date":
                                {
                                    int day;
                                    int month;

                                    bool bIsDay = int.TryParse(value, out day);
                                    bool bIsMonth = int.TryParse(value, out month);

                                    if (bIsDay && bIsMonth)
                                    {
                                        iebs = from b in iebs
                                               where ((DateTime)b[name]).CompareTo(new DateTime(2000, month, day)) < 0
                                               select b;

                                        bIsQueryOk = true;
                                    }

                                    break;
                                }
                            case "Equal date":
                                {
                                    int day;
                                    int month;

                                    bool bIsDay = int.TryParse(value, out day);
                                    bool bIsMonth = int.TryParse(value, out month);

                                    if (bIsDay && bIsMonth)
                                    {
                                        iebs = from b in iebs
                                               where ((DateTime)b[name]).CompareTo(new DateTime(2000, month, day)) == 0
                                               select b;

                                        bIsQueryOk = true;
                                    }

                                    break;
                                }
                        }

                        break ;
                    }
            }

            _mainForm.ChangeDataSet(iebs);

            if(bIsQueryOk)
            {
                string query = $"{name}   {condition}   {value}\n";

                _mainForm.QueriesRichTextBox.Text += query;
            }

            NextQuery();
        }

        /// <summary>
        /// Event fired when _clearQueriesButton is pressed
        /// </summary>
        public void _clearQueriesButton_Click()
        {
            _mainForm.QueriesRichTextBox.Text = "";

            NextQuery();

            Init();

            _mainForm.ChangeDataSet(iebs);
        }

        /// <summary>
        /// Prepare fields for new query
        /// </summary>
        public void NextQuery()
        {
            _mainForm.ParamValueTextBox.Text = "";
            _mainForm.ParamNameComboBox.SelectedItem = null;
            _mainForm.ParamConditionComboBox.SelectedItem = null;
            _mainForm.ParamConditionComboBox.Items.Clear();
        }

        /// <summary>
        /// Event fired when _paramNameComboBox's value is changed
        /// </summary>
        public void _paramNameComboBox_SelectedValueChanged()
        {
            string name = _mainForm.ParamNameComboBox.Text;

            switch (name)
            {
                case "name":
                case "battlesuiteName":
                case "origin":
                case "type":
                case "element":
                    {
                        string[] conditions = GetNewItems("string");

                        if (conditions != null)
                        {
                            _mainForm.ParamConditionComboBox.Items.Clear();

                            for (int i = 0; i < conditions.Length; i++)
                            {
                                _mainForm.ParamConditionComboBox.Items.Add(conditions[i]);
                            }
                        }

                        break;
                    }

                case "id":
                case "haight":
                case "weight":
                case "DMG":
                case "burst":
                case "survival":
                case "support":
                case "ease":
                case "control":
                    {
                        string[] conditions = GetNewItems("number");

                        if (conditions != null)
                        {
                            _mainForm.ParamConditionComboBox.Items.Clear();

                            for (int i = 0; i < conditions.Length; i++)
                            {
                                _mainForm.ParamConditionComboBox.Items.Add(conditions[i]);
                            }
                        }

                        break;
                    }

                case "birthday":
                    {
                        string[] conditions = GetNewItems("s");

                        if (conditions != null)
                        {
                            _mainForm.ParamConditionComboBox.Items.Clear();

                            for (int i = 0; i < conditions.Length; i++)
                            {
                                _mainForm.ParamConditionComboBox.Items.Add(conditions[i]);
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Get items for combo box by tipe of param
        /// </summary>
        /// <param name="item"> Name of param </param>
        /// <returns> String array </returns>
        private string[] GetNewItems(string item)
        {
            switch (item)
            {
                case "number":
                    {
                        return new string[] { ">", ">=", "=", "<=", "<", "!=" };
                    }
                case "string":
                    {
                        return new string[] { "Equal", "Unequal", "Contain", "Doesn't conrain" };
                    }
                case "date":
                    {
                        return new string[] { "Day equal", "Month equal", "After date", "Befor date", "Equal date" };
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        //private void Message_Invalid(string param1, string param2)
        //{
        //    MessageBox.Show(
        //        $"Invalid {param1} format\n" +
        //        $"Please correct the {param2} field"
        //        );
        //}
    }
}
