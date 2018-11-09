using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ParallalProgramming
{
   public class DirectoryFile
    {
        public void DirectoryCrawl()
        {
            DirectoryFile objParallal = new DirectoryFile();
            objParallal.ReadDirectory("D:/");
        }
        public void ReadDirectory(string path)
        {
            long totalSize = 0;
            List<string> dirList = new List<string>();
            GetAllDirectoryList(path, dirList);
            List<string> fileList = new List<string>();
            foreach (var file in dirList)
            {
                try
                {
                    string[] lstFile = Directory.GetFiles(file);
                    fileList.AddRange(lstFile);
                }
                catch (Exception ex)
                {

                }
            }

            Console.WriteLine(DateTime.Now.ToString());
            foreach(var s in fileList)
            {
                FileInfo fi = new FileInfo(s);
                long size = fi.Length;
                totalSize += size;
            }
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("Directory Size : " + totalSize);

            totalSize = 0;
            Console.WriteLine(DateTime.Now.ToString());
            Parallel.For(0, fileList.Count, index =>
            {
                FileInfo fi = new FileInfo(fileList[index]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            });
            Console.WriteLine(DateTime.Now.ToString());

            Console.WriteLine("Size of Total Directories : " + totalSize);

            
        }

        private void GetAllDirectoryList(string path, List<string> directoryList)
        {
            try
            {
                List<string> lstDir = Directory.GetDirectories(path).ToList();
                if (lstDir.Count > 0)
                {
                    directoryList.AddRange(lstDir);
                    foreach (var dirPath in lstDir)
                    {
                        GetAllDirectoryList(dirPath, directoryList);
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}
