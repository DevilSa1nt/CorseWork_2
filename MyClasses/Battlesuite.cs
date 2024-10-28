using System;
using System.Collections.Generic;

namespace Coursework_WinForms_Framework
{
    /// <summary>
    /// Class that contains information about battlesuite
    /// </summary>
    public class Battlesuite
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _battlesuiteName;
        public string BattlesuiteName
        {
            get { return _battlesuiteName; }
            set { _battlesuiteName = value; }
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _origin;
        public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight;}
            set { _weight = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type;}
            set { _type = value; }
        }

        private string _element;
        public string Element
        {
            get { return _element;}
            set { _element = value; }
        }

        private double _DMG;
        public double DMG
        {
            get { return _DMG;}
            set { _DMG = value; }
        }

        private double _burst;
        public double Burst
        {
            get { return _burst;}
            set { _burst = value; }
        }

        private double _survival;
        public double Survival
        {
            get { return _survival;}
            set { _survival = value; }
        }

        private double _support;
        public double Support
        {
            get { return _support;}
            set { _support = value; }
        }

        private double _ease;
        public double Ease
        {
            get { return _ease;}
            set { _ease = value; }
        }

        private double _control;
        public double Control
        {
            get { return _control;}
            set { _control = value; }
        }

        public object this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0:
                        {
                            return _id;
                        }
                    case 1:
                        {
                            return _name;
                        }
                    case 2:
                        {
                            return _battlesuiteName;
                        }
                    case 3:
                        {
                            return _birthday;
                        }
                    case 4:
                        {
                            return _origin;
                        }
                    case 5:
                        {
                            return _height;
                        }
                    case 6:
                        {
                            return _weight;
                        }
                    case 7:
                        {
                            return _type;
                        }
                    case 8:
                        {
                            return _element;
                        }
                    case 9:
                        {
                            return _DMG;
                        }
                    case 10:
                        {
                            return _burst;
                        }
                    case 11:
                        {
                            return _survival;
                        }
                    case 12:
                        {
                            return _support;
                        }
                    case 13:
                        {
                            return _ease;
                        }
                    case 14:
                        {
                            return _control;
                        }
                }

                return null;
            }
        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "id":
                        {
                            return _id;
                        }
                    case "name":
                        {
                            return _name;
                        }
                    case "battlesuiteName":
                        {
                            return _battlesuiteName;
                        }
                    case "birthday":
                        {
                            return _birthday;
                        }
                    case "origin":
                        {
                            return _origin;
                        }
                    case "height":
                        {
                            return _height;
                        }
                    case "weight":
                        {
                            return _weight;
                        }
                    case "type":
                        {
                            return _type;
                        }
                    case "element":
                        {
                            return _element;
                        }
                    case "DMG":
                        {
                            return _DMG;
                        }
                    case "burst":
                        {
                            return _burst;
                        }
                    case "survival":
                        {
                            return _survival;
                        }
                    case "support":
                        {
                            return _support;
                        }
                    case "ease":
                        {
                            return _ease;
                        }
                    case "control":
                        {
                            return _control;
                        }
                }

                return null;
            }
        }

        /// <summary>
        /// Сlass constructor
        /// </summary>
        public Battlesuite()
        {

        }

        /// <summary>
        /// Сlass constructor
        /// </summary>
        /// <param name="id"> Battlesuit id</param>
        /// <param name="name">Valkyrie name</param>
        /// <param name="battlesuiteName">Battlesuite name</param>
        /// <param name="birthday">Battlesuite birthday</param>
        /// <param name="origin">Valkyrie origin</param>
        /// <param name="height">Valkyrie height</param>
        /// <param name="weight">Valkyrie weight</param>
        /// <param name="type">Battlesuite type</param>
        /// <param name="element">Battlesuite element</param>
        /// <param name="dmg">Battlesuite dmg</param>
        /// <param name="burst">Battlesuite butst</param>
        /// <param name="survival">Battlesuite survival</param>
        /// <param name="support">Battlesuite support</param>
        /// <param name="ease">Battlesuite ease</param>
        /// <param name="control">Battlesuite control</param>
        public Battlesuite(int id, string name, string battlesuiteName, DateTime birthday, string origin, int height, double weight, string type, string element, double dmg, double burst, double survival, double support, double ease, double control)
        {
            _id = id;
            _name = name;
            _battlesuiteName = battlesuiteName;
            _birthday = birthday;
            _origin = origin;
            _height = height;
            _weight = weight;
            _type = type;
            _element = element;
            _DMG = dmg;
            _burst = burst;
            _survival = survival;
            _support = support;
            _ease = ease;
            _control = control;
        }

        /// <summary>
        /// Comparison of two battlesuites
        /// </summary>
        /// <param name="b1">First battlesuite</param>
        /// <param name="b2">Second battlesuite</param>
        /// <returns>Return true if first battlesuite equal second battlesuite. Else return false</returns>
        public static bool operator ==(Battlesuite b1, Battlesuite b2)
        {            
            if (!(b1 is null) && !(b2 is null))
            {
                bool bID = b1._id == b2._id;
                bool bName = b1._name == b2._name;
                bool bBattlesuiteName = b1._battlesuiteName == b2._battlesuiteName;
                bool bBirthday = b1._birthday == b2._birthday;
                bool bOrigin = b1._origin == b2._origin;
                bool bHeight = b1._height == b2._height;
                bool bWeight = b1._weight == b2._weight;
                bool bType = b1._type == b2._type;
                bool bElement = b1._element == b2._element;

                if(bID && bName && bBattlesuiteName && bBirthday && bOrigin && bHeight && bWeight && bType && bElement)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Comparison of two battlesuites
        /// </summary>
        /// <param name="b1">First battlesuite</param>
        /// <param name="b2">Second battlesuite</param>
        /// <returns>Return true if first battlesuite doesn't equal second battlesuite. Else return false</returns>
        public static bool operator !=(Battlesuite b1, Battlesuite b2)
        {
            if(!(b1 is null) && !(b2 is null))
            {
                bool bID = b1._id != b2._id;
                bool bName = b1._name != b2._name;
                bool bBattlesuiteName = b1._battlesuiteName != b2._battlesuiteName;
                bool bBirthday = b1._birthday != b2._birthday;
                bool bOrigin = b1._origin != b2._origin;
                bool bHeight = b1._height != b2._height;
                bool bWeight = b1._weight != b2._weight;
                bool bType = b1._type != b2._type;
                bool bElement = b1._element != b2._element;

                if (bID || bName || bBattlesuiteName || bBirthday || bOrigin || bHeight || bWeight || bType || bElement)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get atributes of battlesuite
        /// </summary>
        /// <returns>Return string array that contains all atributes of battlesuite</returns>
        public static string[] GetAtributes()
        {
            return new string[] { "id_i", "name_s", "battlesuiteName_s", "birthday_dt", "origin_s", "height_i", "weight_d", "type_s", "element_s", "DMG_d", "burst_d", "survival_d", "support_d", "ease_d", "control_d"};
        }

        /// <summary>
        /// Override ToString() for battlesuite
        /// </summary>
        /// <returns>Return battlesuite which convert to string</returns>
        public override string ToString()
        {
            return $"{_id} {_name} {_battlesuiteName} {_birthday} {_origin} {_height} {_weight} {_type} {_element}";
        }

        /// <summary>
        /// Get stats of battlesuite
        /// </summary>
        /// <returns>Return double array of stats of battlesuite such as DMG, burst, survival, support, ease and contol</returns>
        public double[] GetStats()
        {
            List<double> stats = new List<double>();

            stats.Add(_DMG);
            stats.Add(_burst);
            stats.Add(_survival);
            stats.Add(_support);
            stats.Add(_ease);
            stats.Add(_control);

            return stats.ToArray();
        }
    }
}