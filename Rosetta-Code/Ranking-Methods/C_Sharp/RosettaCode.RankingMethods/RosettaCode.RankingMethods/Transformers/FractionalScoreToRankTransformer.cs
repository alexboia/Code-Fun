using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public class FractionalScoreToRankTransformer : IScoreToRankTransformer
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

         //keeping track of the current set of tie / equally scored items are are traversing (acts sort-of like a buffer)
         //initially this contains the first item
         List<IHasScore> currentTieItemSet = new List<IHasScore>() { referenceItem };

         for ( int i = 1; i < itemsWithScore.Count; i++ )
         {
            //fetch item that needs to be compared
            IHasScore toCompare = itemsWithScore[ i ];

            //found a different score - empty buffer into the output ranked items list and:
            //- update the reference item
            //- increase the next assignable rank
            //- add the current item to the tie-item buffer
            if ( toCompare.Score != referenceItem.Score )
            {
               AddOutputItems( currentTieItemSet, output, ref nextRank );

               currentTieItemSet = new List<IHasScore>() { toCompare };
               referenceItem = toCompare;
            }
            else
               //equal score; just add it to buffer an move on
               currentTieItemSet.Add( toCompare );
         }

         //if the list ends with at least two equally scored items, we need to empty the buffer
         if ( currentTieItemSet.Any() )
            AddOutputItems( currentTieItemSet, output, ref nextRank );

         return output;
      }

      private void AddOutputItems( List<IHasScore> currentTieItemSet, List<IHasRank> output, ref decimal nextRank )
      {
         decimal nItems = currentTieItemSet.Count;
         decimal summedRanks = nextRank * nItems + nItems * (nItems - 1m) / 2m;
         decimal averageRank = Math.Round( summedRanks / nItems, 1 );

         foreach ( IHasScore it in currentTieItemSet )
            output.Add( new ItemWithRank( it.Item, it.Score, averageRank ) );

         nextRank += nItems;
      }

      public string Name
      {
         get
         {
            return "Fractional [1 2.5 2.5 4]";
         }
      }
   }
}
