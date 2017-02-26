using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RosettaCode.Inheritance_Single
{
   public class ClassScanner
   {
      private Type _rootType;

      private List<Type> _allAssemblyTypes;

      public ClassScanner ( Type rootType, Assembly assembly )
      {
         _rootType = rootType;
         _allAssemblyTypes = assembly.GetTypes()
            .Where( t => t.IsClass && !t.Equals( rootType ) && _rootType.IsAssignableFrom( t ) )
            .ToList() ?? new List<Type>();
      }

      public ClassNode Scan ()
      {
         ClassNode root = new ClassNode()
         {
            ClassType = _rootType,
            Level = 0,
            Parent = null,
            Children = new List<ClassNode>()
         };

         ScanNode( root );
         return root;
      }

      private void ScanNode ( ClassNode node )
      {
         Type[] derivedTypes = _allAssemblyTypes.Where( t => t.BaseType.Equals( node.ClassType ) )
            .ToArray();

         foreach ( Type derived in derivedTypes )
         {
            ClassNode derivedNode = new ClassNode()
            {
               Level = node.Level + 1,
               Children = new List<ClassNode>(),
               ClassType = derived,
               Parent = node
            };

            node.Children.Add( derivedNode );
         }

         foreach ( ClassNode childNode in node.Children )
            ScanNode( childNode );
      }
   }
}
