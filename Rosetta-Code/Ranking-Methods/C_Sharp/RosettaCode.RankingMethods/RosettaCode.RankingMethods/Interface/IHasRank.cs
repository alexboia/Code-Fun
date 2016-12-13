using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public interface IHasRank
   {
      decimal Rank
      {
         get;
      }

      int InitialScore
      {
         get;
      }

      Item Item
      {
         get;
      }
   }
}
