using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace SARST_DEV {
    public class CSV {
        public List<List<string>> data = new List<List<string>>();
        public char delimiter;

        /*public void Write(string path, char delimiter = '\t') {
            using (StreamWriter sw = File.CreateText(path)) {
                foreach (List<string> row in data) {
                    foreach (string str in row) {
                        sw.Write($"{str},");
                    }
                    sw.Write("\n");
                }
            }
        }*/

        /*public CSV(string path, char delimiter = '\t') {
            data = new List<List<string>>();
            string[] file = File.ReadAllLines(path);
            foreach (string line in file) {
                List<string> row = line.Split('\t').ToList();
                data.Add(row);
            }
        }*/

        public CSV(char delimiter = '\t') { this.delimiter = delimiter; }
    }
}
