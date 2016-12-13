using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public class ItemWithScore : IHasScore
   {
      public ItemWithScore( Item item, int score )
      {
         Item = item;
         Score = score;
      }

      public Item Item
      {
         get;
         private set;
      }

      public int Score
      {
         get;
         private set;
      }
   }
}
