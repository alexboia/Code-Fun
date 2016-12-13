using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public class DenseScoreToRankTransformer : IScoreToRankTransformer
   {
      public List<IHasRank> ComputeRank( List<IHasScore> itemsWithScore )
      {
         if ( itemsWithScore == null || !itemsWithScore.Any() )
            return new List<IHasRank>();

         //keeping track of what is the next rank that needs to be assigned
         decimal nextRank = 1m;

         //slight optimization to prevent re-allocation of the underlying array
         List<IHasRank> output = new List<IHasRank>( itemsWithScore.Count );

         //this is the item we are comparing against
         //it changes along the loop as differently scored items are found
         //initially, this is the first item
         IHasScore referenceItem = itemsWithScore[ 0 ];

         output.Add( new ItemWithRank( referenceItem.Item, referenceItem.Score, nextRank ) );
         for ( int i = 1; i < itemsWithScore.Count; i++ )
         {
            //fetch item that needs to be compared
            IHasScore toCompare = itemsWithScore[ i ];

            //found a different score - increment the rank, update the reference item
            if ( toCompare.Score != referenceItem.Score )
            {
               nextRank += 1m;
               referenceItem = toCompare;
            }

            output.Add( new ItemWithRank( toCompare.Item, toCompare.Score, nextRank ) );
         }

         return output;
      }

      public string Name
      {
         get
         {
            return "Dense [1223]";
         }
      }
   }
}
