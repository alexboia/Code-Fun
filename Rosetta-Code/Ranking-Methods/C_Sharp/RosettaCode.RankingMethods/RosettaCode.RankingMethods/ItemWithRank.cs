using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public class ItemWithRank : IHasRank
   {
      public ItemWithRank( Item item, int initialScore, decimal rank )
      {
         Item = item;
         Rank = rank;
         InitialScore = initialScore;
      }

      public Item Item
      {
         get;
         private set;
      }

      public decimal Rank
      {
         get;
         private set;
      }

      public int InitialScore
      {
         get;
         private set;
      }
   }
}
