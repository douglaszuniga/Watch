using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Watch
{
    public class SettingsBrain
    {
        private const string FileName = "WatchConfig.dz";

        public void Save(bool value)
        {
            try
            {
                using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isf.FileExists(FileName))
                    {
                        isf.DeleteFile(FileName);
                    }
                    using (Stream stream = isf.CreateFile(FileName))
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write(value);
                            writer.Close();
                        }
                        stream.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public bool Read()
        {
            var value = true;
            try
            {
                using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isf.FileExists(FileName))
                    {
                        using (Stream stream = isf.OpenFile(FileName, FileMode.Open))
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var readLine = reader.ReadLine();
                                if (readLine != null) value = Convert.ToBoolean(readLine);
                                reader.Close();
                            }
                            stream.Close();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                value = false;
            }
            return value;
        }
    }
}
