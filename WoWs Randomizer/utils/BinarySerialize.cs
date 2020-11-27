using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WoWs_Randomizer.utils
{
    class BinarySerialize
    {
        public static void WriteToBinaryFile<T>(string FilePath, T ObjectToWrite, bool Append = false)
        {
            using (Stream StreamFile = File.Open(FilePath, Append ? FileMode.Append : FileMode.Create))
            {
                var BinaryFormatter = new BinaryFormatter();
                BinaryFormatter.Serialize(StreamFile, ObjectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string FilePath)
        {
            using (Stream StreamFile = File.Open(FilePath, FileMode.Open))
            {
                var BinaryFormatter = new BinaryFormatter();
                StreamFile.Seek(0, System.IO.SeekOrigin.Begin);
                StreamFile.Position = 0;
                return (T)BinaryFormatter.Deserialize(StreamFile);
            }
        }
        public static T Read2<T>(string FilePath)
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);
                var BinaryFormatter = new BinaryFormatter();
                return (T)BinaryFormatter.Deserialize(fs);
            }
        }
    }
}
