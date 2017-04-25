using System;
using System.IO;
using CsvHelper;

namespace CoypuTestingSetup
{
    static class FileHandling
    {
        public static int[] getCSVLength(string path)
        {
            FileStream fs = File.OpenRead(path);
            StreamReader sr = new StreamReader(fs);
            int y = 0;
            int x = 0;
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                x = str.Split(',').Length;
                y++;
            }
            return new int[2] {x,y};
        }

        public static string[,] readCSV(string path)
        {
            String[,] spreadArray;
            int[] lengths = getCSVLength(path);
            spreadArray = new string[lengths[0], lengths[1]];

            FileStream fs = File.OpenRead(path);
            StreamReader sr = new StreamReader(fs);
            CsvReader csvReader = new CsvReader(sr);

            int lineNum = 0;
            var parser = new CsvParser(sr);
            while (true)
            {
                var row = parser.Read();
                if (row == null)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        spreadArray[i, lineNum] = row[i];
                    }
                }
                lineNum++;
            }

            return spreadArray;
        }
    }
}
