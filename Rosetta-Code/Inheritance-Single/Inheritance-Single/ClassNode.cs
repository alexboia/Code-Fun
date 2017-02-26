using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.Inheritance_Single
{
   public class ClassNode
   {
      public Type ClassType
      {
         get;
         set;
      }

      public ClassNode Parent
      {
         get;
         set;
      }

      public List<ClassNode> Children
      {
         get;
         set;
      }

      public int Level
      {
         get;
         set;
      }
   }
}
