using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_1.Models
{
    public class CSVHelper
    {
        #region =================== costanti ===================
        public const string DEFAULTSEPARATOR = ",";
        #endregion

        #region =================== membri statici =============
        #endregion

        #region =================== membri & proprietà =========
        /// <summary>
        /// The path and name of the csv file to create and / or write to
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The separator between the data saved in the file
        /// </summary>
        public string Separator { get; set; }

        /// <summary>
        /// The values of the column headers which define the format of the file's data
        /// </summary>
        public string[] Columns { get; set; }
        #endregion

        #region =================== costruttori ================
        /// <summary>
        /// Creates a new instance of the CSVHelper class
        /// </summary>
        /// <param name="path">The path and name of the csv file to create and / or write to</param>
        /// <param name="separator">The separator between the data saved in the file</param>
        /// <param name="columns">The values of the column headers which define the format of the file's data</param>
        public CSVHelper(string path, string separator, string[] columns)
        {
            Path = path;
            Separator = separator;
            Columns = columns;
        }

        /// <summary>
        /// Creates a new instance of the CSVHelper class using a default ',' separator
        /// </summary>
        /// <param name="path">The path and name of the csv file to create and / or write to</param>
        /// <param name="columns">The values of the column headers which define the format of the file's data</param>
        public CSVHelper(string path, string[] columns) : this(path, DEFAULTSEPARATOR, columns)
        {

        }
        #endregion

        #region =================== metodi generali ============
        /// <summary>
        /// Writes values in a new line of the file in the Path property or creates it when it's missing
        /// </summary>
        /// <param name="values">The values, separated by Separator, to write in the file</param>
        public void Write(string[] values)
        {
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(Path))
            {
                foreach (string column in Columns)
                {
                    sb.Append(column + Separator);
                }
                sb.Append(Environment.NewLine);
            }

            if (values.Length == Columns.Length)
            {
                StreamWriter sw = new StreamWriter(Path);
                foreach (string value in values)
                {
                    sb.Append(value + Separator);
                }
                sw.WriteLine(sb);
                sw.Close();
            }
            else
            {
                throw new FormatException("Il numero di colonne e di valori sono differenti.");
            }
        }
        #endregion
    }
}
