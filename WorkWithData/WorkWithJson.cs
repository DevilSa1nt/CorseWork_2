using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Coursework_WinForms_Framework
{
    /// <summary>
    /// Class that work with data (JSON and txt)
    /// </summary>
    internal class WorkWithJson
    {
        /// <summary>
        /// Write data to JSON
        /// </summary>
        public static void WriteToJson()
        {
            List<Battlesuite> battlesuites;

            battlesuites = GetBattlesuitsFromTxt();

            using (StreamWriter sw = new StreamWriter(GetPathToJson()))
            {
                for (int i = 0; i < battlesuites.Count; i++)
                {
                    sw.WriteLine(JsonSerializer.Serialize(battlesuites[i]));
                }
            }
        }

        /// <summary>
        /// Get data from JSON
        /// </summary>
        /// <returns> List of battlesuits from JSON </returns>
        public static List<Battlesuite> ReadFromJson()
        {
            List<Battlesuite> battlesuites = new List<Battlesuite>();

            using (StreamReader sr = new StreamReader(GetPathToJson()))
            {
                string a = sr.ReadLine();

                while (a != null)
                {
                    battlesuites.Add(JsonSerializer.Deserialize<Battlesuite>(a));

                    a = sr.ReadLine();
                }
            }

            return battlesuites;
        }

        /// <summary>
        /// Get path to JSON file
        /// </summary>
        /// <returns> Path to JSON file</returns>
        private static string GetPathToJson()
        {
            return Environment.CurrentDirectory + @"\\json.json";
        }

        /// <summary>
        /// Get path to TXT file
        /// </summary>
        /// <returns> Path to TXT file </returns>
        private static string GetPathToTxt()
        {
            return Environment.CurrentDirectory + @"\\TextFile1.txt";
        }

        /// <summary>
        /// Get data from TXT
        /// </summary>
        /// <returns> List of strings array from TXT file</returns>
        private static List<string[]> GetDataFromTxt()
        {
            List<string[]> bs = new List<string[]>();

            using (StreamReader sr = new StreamReader(GetPathToTxt()))
            {
                string a = sr.ReadLine();

                while (a != null)
                {
                    bs.Add(a.Split(';'));

                    a = sr.ReadLine();
                }
            }

            return bs;
        }

        /// <summary>
        /// Add data to TXT file
        /// </summary>
        /// <param name="newData"> </param>
        public static void WrightToTxt(string newData)
        {
            List<string> strings = new List<string>();

            using (StreamReader sr = new StreamReader(GetPathToTxt()))
            {
                string a = sr.ReadLine();

                while (a != null)
                {
                    strings.Add(a);

                    a = sr.ReadLine();
                }
            }

            for(int i = 0; i < strings.Count; i++)
            {
                if(strings[i] != null)
                {
                    string[] str = strings[i].Split(';');

                    string a = str[1];

                    for(int j = 2; j < str.Length; j++)
                    {
                        a += ";";
                        a += str[j];
                    }

                    strings[i] = a;
                }
            }
            
            strings.Add(newData);

            strings.Sort();

            for(int i = 0; i < strings.Count; i++)
            {
                strings[i] = $"{i+1};" + strings[i];
            }

            using(StreamWriter sw = new StreamWriter(GetPathToTxt()))
            {
                for(int i = 0; i < strings.Count; i++)
                {
                    sw.WriteLine(strings[i]);
                }
            }

            WriteToJson();
        }

        /// <summary>
        /// Add data to TXT file by index
        /// </summary>
        /// <param name="newData"> Data for adding</param>
        /// <param name="index"> Index </param>
        public static void WrightToTxt(string newData, int index)
        {
            List<string> strings = new List<string>();

            using (StreamReader sr = new StreamReader(GetPathToTxt()))
            {
                string a = sr.ReadLine();

                while (a != null)
                {
                    strings.Add(a);

                    a = sr.ReadLine();
                }
            }

            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i] != null)
                {
                    if (i == index)
                    {
                        strings[i] = newData;
                    }
                    else
                    {
                        string[] str = strings[i].Split(';');

                        string a = str[1];

                        for (int j = 2; j < str.Length; j++)
                        {
                            a += ";";
                            a += str[j];
                        }

                        strings[i] = a;
                    }
                }
            }

            strings.Sort();

            for (int i = 0; i < strings.Count; i++)
            {
                strings[i] = $"{i + 1};" + strings[i];
            }

            using (StreamWriter sw = new StreamWriter(GetPathToTxt()))
            {
                for (int i = 0; i < strings.Count; i++)
                {
                    sw.WriteLine(strings[i]);
                }
            }

            WriteToJson();
        }

        /// <summary>
        /// Delete data from TXT by index
        /// </summary>
        /// <param name="index"> Index </param>
        public static void DeleteRowFromTXT(int index)
        {
            List<string> strings = new List<string>();

            using (StreamReader sr = new StreamReader(GetPathToTxt()))
            {
                string a = sr.ReadLine();

                while (a != null)
                {
                    strings.Add(a);

                    a = sr.ReadLine();
                }
            }

            if(index >= 0)
            {
                strings.RemoveAt(index);
            }

            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i] != null)
                {
                    string[] str = strings[i].Split(';');

                    string a = str[1];

                    for (int j = 2; j < str.Length; j++)
                    {
                        a += ";";
                        a += str[j];
                    }

                    strings[i] = a;
                }
            }

            strings.Sort();

            for (int i = 0; i < strings.Count; i++)
            {
                strings[i] = $"{i + 1};" + strings[i];
            }

            using (StreamWriter sw = new StreamWriter(GetPathToTxt()))
            {
                for (int i = 0; i < strings.Count; i++)
                {
                    sw.WriteLine(strings[i]);
                }
            }

            WriteToJson();
        }

        /// <summary>
        /// Get data from TXT
        /// </summary>
        /// <returns> List of battlesuits from TXT </returns>
        private static List<Battlesuite> GetBattlesuitsFromTxt()
        {
            List<Battlesuite> bs = new List<Battlesuite>();

            List<string[]> bsStr = GetDataFromTxt();

            int id;
            bool bId;

            string name;

            string battlesuiteName;

            DateTime birthday;
            bool bBirthday;

            string origin;

            int height;
            bool bHeight;

            double weight;
            bool bWeight;

            string type;

            string element;

            double dmg;
            bool bDmg;

            double burst;
            bool bBurst;

            double survival;
            bool bSurvival;

            double support;
            bool bSupport;

            double ease;
            bool bEase;

            double control;
            bool bControl;

            for (int i = 0; i < bsStr.Count; i++)
            {
                bId = int.TryParse(bsStr[i][0], out id);
                name = bsStr[i][1];
                battlesuiteName = bsStr[i][2];
                bBirthday = DateTime.TryParse(bsStr[i][3], out birthday);
                origin = bsStr[i][4];
                bHeight = int.TryParse(bsStr[i][5], out height);
                bWeight = double.TryParse(bsStr[i][6], out weight);
                type = bsStr[i][7];
                element = bsStr[i][8];
                bDmg = double.TryParse(bsStr[i][9], out dmg);
                bBurst = double.TryParse(bsStr[i][10], out burst);
                bSurvival = double.TryParse(bsStr[i][11], out survival);
                bSupport = double.TryParse(bsStr[i][12], out support);
                bEase = double.TryParse(bsStr[i][13], out ease);
                bControl = double.TryParse(bsStr[i][14], out control);

                if (bsStr[i][3] == "-")
                {
                    birthday = new DateTime(1999 / 12 / 31);
                    bBirthday = true;
                }
                if(bsStr[i][5] == "-")
                {
                    height = 0;
                    bHeight = true;
                }
                if(bsStr[i][6] == "-")
                {
                    weight = 0;
                    bWeight = true;
                }
                if (bsStr[i][9] == "-")
                {
                    dmg = 0;
                    bDmg = true;
                }

                if (bsStr[i][10] == "-")
                {
                    burst = 0;
                    bBurst = true;
                }
                if (bsStr[i][11] == "-")
                {
                    survival = 0;
                    bSurvival = true;
                }
                if (bsStr[i][12] == "-")
                {
                    support = 0;
                    bSupport = true;
                }
                if (bsStr[i][13] == "-")
                {
                    ease = 0;
                    bEase = true;
                }
                if (bsStr[i][14] == "-")
                {
                    control = 0;
                    bControl = true;
                }

                if (bId && bBirthday && bHeight && bWeight && bDmg && bBurst && bSurvival && bSupport && bEase && bControl)
                {
                    Battlesuite b = new Battlesuite(id, name, battlesuiteName, birthday, origin, height, weight, type, element, dmg, burst, survival, support, ease, control);

                    bs.Add(b);
                }
            }

            return bs;
        }
    }
}
