using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic9.FilesAndFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWorkMethod();
        }


        public static void TestWorkMethod()
        {
            var copier = new BitwiseCopier();
            copier.StartCopy += () => Console.WriteLine("Копирование началось");
            copier.ProgressCopy += ((a, s) => Console.WriteLine(s));
            var source =
                @"C:\Projects\CSharpCourse\Tyganov Ilya\Norbit.CRM.Tyganov\Practic9\Norbit.CRM.Tyganov.Practic9.FilesAndFolders\source.txt";
            var destination =
                @"C:\Projects\CSharpCourse\Tyganov Ilya\Norbit.CRM.Tyganov\Practic9\Norbit.CRM.Tyganov.Practic9.FilesAndFolders\destination.txt";
            copier.Copy(source, destination, 24);
            copier.EndCopy += () => Console.WriteLine("Копирование завешено");
        }
    }
}
