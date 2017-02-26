using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosettaCode.Inheritance_Single.SampleClasses;

namespace RosettaCode.Inheritance_Single
{
   public class Program
   {
      public static void Main ( string[] args )
      {
         ClassScanner scanner = new ClassScanner( typeof( Animal ), typeof( Animal ).Assembly );
         ClassNode typeTree = scanner.Scan();

         Console.OutputEncoding = Encoding.ASCII;
         PrintTree( typeTree );
         Console.ReadKey();
      }

      private static void PrintTree ( ClassNode node )
      {
         int amount = node.Level + 1;

         string prefix = "|";
         string indent = new string( ' ', amount );
         string link = new string( '-', amount );

         Console.WriteLine( indent + prefix );
         Console.WriteLine( indent + link + node.ClassType.Name );

         foreach ( ClassNode subTree in node.Children )
            PrintTree( subTree );
      }
   }
}
