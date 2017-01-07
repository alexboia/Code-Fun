using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RosettaCode.NotesOnCommandLine
{
   class Program
   {
      public static void Main( string[] args )
      {
         new Program().Run(args);
      }

      private void Run(string[] args)
      {
         Console.InputEncoding = Encoding.UTF8;
         Console.OutputEncoding = Encoding.UTF8;

         if( args == null || args.Length == 0 )
            PrintNotesContents();
         else
            SaveNotes( args );

         WaitToExit();
      }

      private void PrintNotesContents()
      {
         string contents = null;

         if( NotesFileExists )
            contents = File.ReadAllText( NotesFile );

         Console.WriteLine( "Note contents follows:" );         
         OutputSpacer();
         Console.WriteLine();

         contents = !string.IsNullOrEmpty( contents ) ? contents : "[No notes have been taken yet]";

         Console.WriteLine( contents );
         OutputSpacer();
      }

      private void SaveNotes(string[] args)
      {
         using( FileStream fs = new FileStream( NotesFile, FileMode.Append, FileAccess.Write ) )
         {
            string contents = DateTime.Now.ToString() + Environment.NewLine;

            contents += '\t';
            contents += string.Join<string>( " ", args );
            contents += Environment.NewLine;

            using( StreamWriter sw = new StreamWriter( fs ) )
            {
               sw.Write( contents );
               sw.Close();
            }

            fs.Close();
         }

         Console.WriteLine( "Contents written" );
      }

      private void WaitToExit()
      {
         Console.WriteLine( "Press any key to exit" );
         Console.ReadKey();
      }

      private void OutputSpacer()
      {
         Console.WriteLine( new string('-', 25) );
      }

      private bool NotesFileExists
      {
         get
         {
            return File.Exists( NotesFile );
         }
      }

      private string NotesFile
      {
         get
         {
            return Path.Combine( Environment.CurrentDirectory, "NOTES.txt" );
         }
      }
   }
}
