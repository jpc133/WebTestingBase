//Copyright 2017 Jonathan Clarke
//Please see NOTICE.txt, if NOTICE.txt is not present
//email jonathan.clarke73@gmail.com for a copy
using System;
using System.IO;
using CsvHelper;

namespace CoypuTestingSetup
{
    public static class FileHandling
    {
        public static int[] getCSVLength(string path)
        {
            FileStream fs;
            try
            {
                fs = File.OpenRead(path);
            }
            catch
            {
                throw new Exception("File is either open or doesn't exist");
            }
            StreamReader sr = new StreamReader(fs);
            int y = 0;
            int x = 0;
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                x = str.Split(',').Length;
                y++;
            }
            return new int[2] { x, y };
        }

        public static string[,] readCSV(string path)
        {
            String[,] spreadArray;
            int[] lengths = getCSVLength(path);
            spreadArray = new string[lengths[0], lengths[1]];
            FileStream fs;
            try
            {
                fs = File.OpenRead(path);
            }
            catch
            {
                throw new Exception("File is either open or doesn't exist");
            }
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
            fs.Close();
            return spreadArray;
        }

        public static void writeCSV(string[,] data, string path)
        {
            FileStream fs = File.OpenWrite(path);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    string s = "";
                    for (int x = 0; x < data.GetLength(0); x++)
                    {
                        if (x < data.GetLength(0) - 1)
                        {
                            s += data[x, y] + ",";
                        }
                        else
                        {
                            s += data[x, y];
                        }
                    }
                    sw.WriteLine(s, System.Text.Encoding.UTF8);
                }
                sw.Flush();
            }
            fs.Close();
        }
    }
}
