using LuteMod.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LuteMod.Indexing
{
    public class PartitionIndex
    {
        public static readonly string Header = "PartitionIndex";

        private List<string> partitionNames;
        private bool loaded;

        public List<string> PartitionNames { get => partitionNames; set => partitionNames = value; }
        public bool Loaded { get => loaded;}

        public PartitionIndex()
        {
            PartitionNames = new List<string>();
        }

        public void LoadIndex()
        {
            string temp = SaveManager.ReadSavFile(SaveManager.SaveFilePath + @"PartitionIndex");
            if (temp.Length == 0)
            {
                loaded = false;
                return;
            }
            FromString(temp);
            loaded = true;
        }

        public void AddFileInIndex(string fileName)
        {
            string[] tempSplit = fileName.Split('\\');
            string name = tempSplit[tempSplit.Length - 1];
            string filteredName = Regex.Replace(name, @"\[[0-9]*\]\.sav", "");

            FileIO.CopyPasteFile(fileName, SaveManager.SaveFilePath + name);
            if (!partitionNames.Contains(filteredName))
            {
                partitionNames.Add(filteredName);
            }

        }

        public void SaveIndex()
        {
            SaveManager.WriteSaveFile(SaveManager.SaveFilePath + @"PartitionIndex", ToString());
        }

        public override string ToString()
        {
            StringBuilder strbld = new StringBuilder();

            strbld.Append("|PartitionIndex|");
            foreach (string partitionName in PartitionNames)
            {
                strbld.Append(partitionName).Append("|");
            }

            return strbld.ToString();
        }

        public void FromString(string content)
        {
            string[] splitContent = content.Split('|');
            if (splitContent[1] == "PartitionIndex")
            {
                for (int i = 2; i < splitContent.Length - 1; i++)
                {
                    PartitionNames.Add(splitContent[i]);
                }
            }
        }
    }
}
