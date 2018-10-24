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

        /// <summary>
        ///The encoding with which to open, write to or read from the file
        /// </summary>
        public Encoding Encoding { get; set; }
        #endregion

        #region =================== costruttori ================
        /// <summary>
        /// Creates a new instance of the CSVHelper class
        /// </summary>
        /// <param name="path">The path and name of the csv file to create and / or write to</param>
        /// <param name="separator">The separator between the data saved in the file</param>
        /// <param name="columns">The values of the column headers which define the format of the file's data</param>
        /// <param name="encoding">The encoding with which to open, write to or read from the file</param>
        public CSVHelper(string path, string separator, string[] columns, Encoding encoding)
        {
            Path = path;
            Separator = separator;
            Columns = columns;
            Encoding = encoding;
        }

        /// <summary>
        /// Creates a new instance of the CSVHelper class using a default ',' separator
        /// </summary>
        /// <param name="path">The path and name of the csv file to create and / or write to</param>
        /// <param name="columns">The values of the column headers which define the format of the file's data</param>
        /// <param name="encoding">The encoding with which to open, write to or read from the file</param>
        public CSVHelper(string path, string[] columns, Encoding encoding) : this(path, ",", columns, encoding)
        {

        }

        /// <summary>
        /// Creates a new instance of the CSVHelper class using a default ',' separator and encoding
        /// </summary>
        /// <param name="path">The path and name of the csv file to create and / or write to</param>
        /// <param name="columns">The values of the column headers which define the format of the file's data</param>
        public CSVHelper(string path, string[] columns) : this(path, DEFAULTSEPARATOR, columns, Encoding.Unicode)
        {

        }

        public CSVHelper(string path, string separator, string[] columns) : this(path, separator, columns, Encoding.Unicode)
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
            if (!Directory.Exists(Path.Remove(Path.LastIndexOf("/"))))
            {
                Directory.CreateDirectory(Path.Remove(Path.LastIndexOf("/")));
            }
            //The values to write in a new row
            StringBuilder valuesToWrite = new StringBuilder();

            //The header of the file, to be added if missing
            StringBuilder header = new StringBuilder();

            //Create the header
            foreach (string column in Columns)
            {
                header.Append(column + Separator);
            }

            //Remove the last separator
            header.Remove(header.Length - 1, 1);

            //Add a new line
            header.Append(Environment.NewLine);

            //Check if the file doesn't exist
            if (!File.Exists(Path))
            {
                valuesToWrite.Append(header);
            } //If the file exists, isn't empty and its first line isn't the header
            else if (File.Exists(Path) &&
                File.ReadAllLines(Path, Encoding).Length > 0 &&
                !(File.ReadAllLines(Path, Encoding).FirstOrDefault().Equals(header.ToString().TrimEnd(Environment.NewLine.ToCharArray()))))
            {
                //Write the header to the first line of the file
                AddToBeginning(header.ToString().TrimEnd(Environment.NewLine.ToCharArray()), Path);
            }

            //If there's as many values as the columns of the file
            if (values.Length == Columns.Length)
            {
                //Create the row
                foreach (string value in values)
                {
                    valuesToWrite.Append(value + Separator);
                }

                //Remove the last separator
                valuesToWrite.Remove(valuesToWrite.Length - 1, 1);

                //Add the text to the file and create it
                File.AppendAllText(Path, valuesToWrite.ToString() + "\n", Encoding);
            }
            else
            {
                throw new FormatException("Il numero di colonne e di valori sono differenti.");
            }
        }

        /// <summary>
        /// Writes the specified text to the beginning of the file as the first line
        /// </summary>
        /// <param name="text">The text to write to the beginning of the file</param>
        /// <param name="path">The path of the file in which to write</param>
        public static void AddToBeginning(string text, string path)
        {
            string tempfile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(path))
            {
                writer.WriteLine(text);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, path, true);
        }

        /// <summary>
        /// Opens the CSV file, reads all lines of the file and then closes the file.
        /// </summary>
        /// <returns>An ArrayList where each element corresponds to an array containing the values of a row without separator</returns>
        public List<string[]> ReadAllLines()
        {
            List<string[]> re = new List<string[]>();
            string[] lines = File.ReadAllLines(Path, Encoding);
            foreach (string line in lines)
            {
                re.Add(line.Split(Separator));
            }
            return re;
        }
        #endregion
    }
}
