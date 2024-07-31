using System.Diagnostics;
using System.Security.Principal;

namespace FileHelper
{
    internal class Program
    {
        /// <summary>
        /// 想实现删除指定文件夹下的所有后缀为.crdownload的扩展名
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //需要删除的文件夹路径
            string folderPath = @"F:\学习\C#学习视频\ASP.NET Core\";
            //需要删除的扩展名
            string extensionToRemove = ".crdownload";
           // string extensionToRemove = ".txt";

            try
            {
                if (folderPath != null)
                {
                    //获取文件夹下的所有文件
                    string[] files = Directory.GetFiles(folderPath);
                    //遍历文件删除指定后缀
                    foreach (string file in files)
                    {
                        //获取源文件名
                        string fileName = Path.GetFileName(file);
                        Console.WriteLine("打印文件夹下的文件名");
                        Console.WriteLine(fileName);
                        //获取文件的扩展名
                        string extension = Path.GetExtension(file);
                        Console.WriteLine("打印文件夹下的文件扩展名");
                        Console.WriteLine(extension);

                        //方法1：
                        if (extension == extensionToRemove)
                        {
                            //删除文件
                            //File.Delete(file);
                            //Console.WriteLine("删除文件：");
                            //Console.WriteLine(file);
                            Console.WriteLine("-------------------------------------------------");
                            //获取文件名
                            string fileName1 = Path.GetFileNameWithoutExtension(file);
                            Console.WriteLine("文件名：");
                            Console.WriteLine(fileName1);
                            if (IsAdministrator())
                            {
                                Console.WriteLine("Program is running with administrator privileges.");
                                //打开指定目录
                                //Process.Start(folderPath);
                                //重命名文件
                                File.Move(folderPath + fileName, folderPath + fileName1);

                            }
                            else
                            {
                                Console.WriteLine("Program is NOT running with administrator privileges.");
                            }

                            //Console.WriteLine("-------------------------------------------------");
                            #region 验证操作是否成功
                            ////遍历新文件
                            //string[] files1 = Directory.GetFiles(folderPath);
                            //foreach (string file1 in files1)
                            //{
                            //    //获取源文件名
                            //    string fileName2 = Path.GetFileName(file1);
                            //    Console.WriteLine("打印文件夹下的文件名");
                            //    Console.WriteLine(fileName2);
                            //    //获取文件的扩展名
                            //    string extension1 = Path.GetExtension(file1);
                            //    Console.WriteLine("打印文件夹下的文件扩展名");
                            //    Console.WriteLine(extension1);
                            //}
                            #endregion
                        }
                        static bool IsAdministrator()
                        {
                            WindowsIdentity identity = WindowsIdentity.GetCurrent();
                            WindowsPrincipal principal = new WindowsPrincipal(identity);
                            return principal.IsInRole(WindowsBuiltInRole.Administrator);
                        }

                    }
                }
                

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
