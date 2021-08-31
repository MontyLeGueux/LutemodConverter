using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuteMod.IO
{
    public class SaveManager
    {
        private static int fileSize = 5000;
        private static List<byte> fileHeader;
        private static List<byte> fileEnd;

        public static readonly string SaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\Mordhau\Saved\SaveGames\";

        public static string ReadSavFile(string filePath)
        {
            StringBuilder strbld = new StringBuilder();
            bool fileFound = true;
            string temp;
            int i = 0;

            while (fileFound)
            {
                temp = GetDataFromFile(filePath + "[" + i + "].sav");
                fileFound = temp != null;
                strbld.Append(temp);
                i++;
            }

            return strbld.ToString();
        }

        public static void WriteSaveFile(string filePath, string content)
        {
            int i = 0;
            while (SaveDataInFile(filePath, content, i))
            {
                i++;
            }
        }

        public static void DeleteData(string filePath)
        {
            int i = 0;
            while (FileIO.DeleteFile(filePath + "[" + i + "].sav"))
            {
                i++;
            }
        }

        private static string GetDataFromFile(string filePath)
        {
            byte[] readResult = FileIO.LoadFile(filePath);
            int i;
            List<byte> retrievedData = new List<byte>();
            if (readResult == null)
            {
                return null;
            }
            else
            {
                fileHeader = new List<byte>();
                fileEnd = new List<byte>();
                i = readResult.Length - 1;
                while (i >= 0 && !(readResult[i] == 124 || readResult[i] == 64))
                {
                    i--;
                    fileEnd.Add(readResult[i]);
                }
                fileEnd.RemoveAt(fileEnd.Count - 1);
                while (i >= 0 && !(readResult[i] == 0))
                {
                    retrievedData.Add(readResult[i]);
                    i--;
                }
                while (i >= 0)
                {
                    fileHeader.Add(readResult[i]);
                    i--;
                }
                retrievedData.Reverse();
                fileEnd.Reverse();
                fileHeader.Reverse();
                fileSize = retrievedData.Count;
                string debug1 = Encoding.UTF8.GetString(fileEnd.ToArray());
                string debug2 = Encoding.UTF8.GetString(retrievedData.ToArray());
                string debug3 = Encoding.UTF8.GetString(fileHeader.ToArray());
                return Encoding.UTF8.GetString(retrievedData.ToArray()).Replace("\0", "").Replace("@", "");
            }
        }

        private static bool SaveDataInFile(string filePath, string stringData, int offset)
        {
            byte[] data = Encoding.UTF8.GetBytes(stringData);
            int i = 0;
            byte[] fileContent = new byte[fileSize];
            while (((offset * fileSize) + i < data.Length) && i < fileSize)
            {
                fileContent[i] = data[(offset * fileSize) + i];
                i++;
            }
            if (!((offset * fileSize) + i < data.Length))
            {
                while (i < fileSize)
                {
                    fileContent[i] = 64;
                    i++;
                }
            }
            SaveDataOnDisk(filePath + "[" + offset + "].sav", fileContent);
            return ((offset * fileSize) + i < data.Length);
        }

        private static void SaveDataOnDisk(string filePath, byte[] value)
        {
            byte[] data = new byte[fileHeader.Count + value.Length + fileEnd.Count];
            int i, y;
            for (i = 0; i < fileHeader.Count; i++)
            {
                data[i] = fileHeader[i];
            }
            for (y = 0; y < value.Length; i++, y++)
            {
                data[i] = value[y];
            }
            for (y = 0; y < fileEnd.Count; i++, y++)
            {
                data[i] = fileEnd[y];
            }
            FileIO.SaveFile(filePath, data);
        }
    }
}
