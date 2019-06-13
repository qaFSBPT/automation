using AutomationFramework.Helpers;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace AutomationFramework.Helpers {

    public static class DataReader
    {
        /// <summary>
        /// Used for reading in page elements. Will read the entire CSV.
        /// </summary>
        /// <param name="path">Path to CSV</param>
        /// <param name="delimiters">Custom delimiters. If blank will us default ","</param>
        /// <returns>A list containing each rows</returns>
        public static List<string[]> ReadCSV(string path, params string[] delimiters)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            else if (delimiters == null)
            {
                throw new ArgumentNullException("delimiters");
            }

            List<string[]> results = new List<string[]>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.Delimiters = delimiters.Length != 0 ? delimiters : new string[] { "," };
                    while (!parser.EndOfData)
                    {
                        results.Add(parser.ReadFields());
                    }
                    parser.ReadLine();
                }

                return results;
            }
            catch (FileNotFoundException ex)
            {
                // TODO: Log
                throw;
            }
            catch (ArgumentException ex)
            {
                // TODO: Log
                throw;
            }
        }

        /// <summary>
        /// Used for reading the steps for a given test. If the row is 0 or default(int) it will read the entire document.
        /// </summary>
        /// <param name="path">Path to CSV</param>
        /// <param name="row">Row index to gather</param>
        /// <param name="delimiters">Custom delmiters</param>
        /// <returns>Run number, Dictionary of header, value</returns>
        public static Dictionary<string, Dictionary<string, string>> ReadCSVKV(string path, int row, params string[] delimiters)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            else if(!(row >= 0))
            {
                throw new ArgumentOutOfRangeException("row", "row must be greater than 0");
            }
            else if (delimiters == null)
            {
                throw new ArgumentNullException("delimiters");
            }

            Dictionary<string, Dictionary<string, string>> toReturn = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> toReturnTemp;
            List<string> headersList = null;
            string currentLine;

            try
            {
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.Delimiters = delimiters.Length != 0 ? delimiters : new string[] { "," };
                    while (!parser.EndOfData)
                    {
                        toReturnTemp = new Dictionary<string, string>();
                        if (parser.LineNumber == 1)
                        {
                            headersList = new List<string>(parser.ReadFields());
                        }

                        currentLine = Math.Abs(parser.LineNumber).ToString();

                        if (row != default(int))
                        {
                            if (parser.LineNumber == row)
                            {
                                var rowFields = parser.ReadFields();
                                toReturnTemp = headersList.Select((k, i) => new { k, v = rowFields[i] }).ToDictionary(x => x.k, x => x.v);
                                toReturn[currentLine] = toReturnTemp;
                                return toReturn;
                            }
                            parser.ReadLine();
                        }
                        else
                        {
                            var fields = parser.ReadFields();
                            toReturnTemp = headersList.Select((k, i) => new { k, v = fields[i] }).ToDictionary(x => x.k, x => x.v);
                            toReturn[currentLine] = toReturnTemp;
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                // TODO: Log
                throw;
            }

            return toReturn;
        }
    }
}

