using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public interface IHasScore
   {
      int Score
      {
         get;
      }

      Item Item
      {
         get;
      }
   }
}
