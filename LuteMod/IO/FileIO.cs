using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LuteMod.IO
{
    public class FileIO
    {
        public static T LoadXML<T>(string path)
        {
            T result = default(T);
            try
            {
                if (path != null)
                {
                    path = path + ".xml";
                    Directory.CreateDirectory(path);
                    if (File.Exists(path))
                    {
                        using (var stream = File.Open(path, FileMode.OpenOrCreate))
                        {
                            var serializer = new XmlSerializer(typeof(T));
                            result = (T)serializer.Deserialize(stream);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //todo
            }
            return result;
        }

        public static void SaveXML<T>(T target, string path)
        {
            try
            {
                if (path != null)
                {
                    path = path + ".xml";
                    using (var stream = File.Create(path))
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(stream, target);
                    }
                }
            }
            catch (Exception ex)
            {
                //todo
            }
        }
        public static void SaveTextFile(string fileName, string fileContent)
        {
            using (var stream = File.Create(fileName))
            {
                stream.Write(Encoding.UTF8.GetBytes(fileContent), 0, fileContent.Length);
            }
        }

        public static void SaveFile(string fileName, byte[] fileContent)
        {
            using (var stream = File.Create(fileName))
            {
                stream.Write(fileContent, 0, fileContent.Length);
            }
        }

        public static bool DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                return true;
            }
            return false;
        }

        public static void CopyPasteFile(string fileName, string newFileName)
        {
            if (File.Exists(fileName) && !File.Exists(newFileName))
            {
                File.Copy(fileName, newFileName);
            }
        }

        public static string LoadTextFile(string fileName)
        {
            byte[] streamResult;
            string content;

            try
            {
                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    streamResult = new byte[stream.Length];
                    stream.Read(streamResult, 0, (int)stream.Length);
                    content = Encoding.UTF8.GetString(streamResult);
                }
            }
            catch (Exception)
            {
                content = null;
            }
            return content;
        }

        public static byte[] LoadFile(string fileName)
        {
            byte[] streamResult = null;

            try
            {
                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    streamResult = new byte[stream.Length];
                    stream.Read(streamResult, 0, (int)stream.Length);
                }
            }
            catch (Exception ex)
            {
                streamResult = null;
            }
            return streamResult;
        }
    }
}
