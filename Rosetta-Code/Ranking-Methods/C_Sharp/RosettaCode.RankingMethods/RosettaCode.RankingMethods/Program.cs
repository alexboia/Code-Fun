using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public class Program
   {
      public static void Main( string[] args )
      {
         //best-first order is assumed
         List<IHasScore> someDifferentSingleSet = new List<IHasScore>();
         someDifferentSingleSet.Add( new ItemWithScore( new Item( "Item 1" ), 150 ) );
         someDifferentSingleSet.Add( new ItemWithScore( new Item( "Item B" ), 140 ) );
         someDifferentSingleSet.Add( new ItemWithScore( new Item( "Item A" ), 140 ) );
         someDifferentSingleSet.Add( new ItemWithScore( new Item( "Item 4" ), 110 ) );
         someDifferentSingleSet.Add( new ItemWithScore( new Item( "Item 5" ), 105 ) );

         //best-first order is assumed
         List<IHasScore> someDifferentMultiSets = new List<IHasScore>();
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item 1" ), 200 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item C" ), 150 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item B" ), 150 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item 4" ), 110 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item E" ), 105 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item F" ), 105 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item D" ), 105 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item 8" ), 100 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item H" ), 95 ) );
         someDifferentMultiSets.Add( new ItemWithScore( new Item( "Item G" ), 95 ) );

         List<IHasScore> allDifferent = new List<IHasScore>();
         allDifferent.Add( new ItemWithScore( new Item( "Item 1" ), 150 ) );
         allDifferent.Add( new ItemWithScore( new Item( "Item 2" ), 140 ) );
         allDifferent.Add( new ItemWithScore( new Item( "Item 3" ), 130 ) );
         allDifferent.Add( new ItemWithScore( new Item( "Item 4" ), 120 ) );
         allDifferent.Add( new ItemWithScore( new Item( "Item 5" ), 110 ) );

         //run the Standard transformer on all the data sets
         RunTransformer( new StandardScoreToRankTransformer(),
             someDifferentSingleSet,
             someDifferentMultiSets,
             allDifferent );

         //run the Modified transformer on all the data sets
         RunTransformer( new ModifiedScoreToRankTransformer(),
             someDifferentSingleSet,
             someDifferentMultiSets,
             allDifferent );

         //run the Dense transformer on all the data sets
         RunTransformer( new DenseScoreToRankTransformer(),
             someDifferentSingleSet,
             someDifferentMultiSets,
             allDifferent );

         //run the Ordinal transformer on all the data sets
         RunTransformer( new OrdinalScoreToRankTransformer(),
             someDifferentSingleSet,
             someDifferentMultiSets,
             allDifferent );

         //run the Fractional transformer on all the data sets
         RunTransformer( new FractionalScoreToRankTransformer(),
             someDifferentSingleSet,
             someDifferentMultiSets,
             allDifferent );

         Console.ReadKey();
      }

      private static void TransformAndOutputItems( IScoreToRankTransformer transformer, List<IHasScore> scoring )
      {
         List<IHasRank> rankingOutput = transformer.ComputeRank( scoring );

         Console.WriteLine( "--- Algorithm: {0} (item count = {1}) ---", transformer.Name, scoring.Count );

         for ( int i = 0; i < rankingOutput.Count; i++ )
            Console.WriteLine( "{0}. Item: {1} ({2})", rankingOutput[ i ].Rank, rankingOutput[ i ].Item.Name, rankingOutput[ i ].InitialScore );

         Console.WriteLine( "--- =================== ---" );
         Console.WriteLine();
      }

      private static void RunTransformer( IScoreToRankTransformer transformer, params List<IHasScore>[] dataSets )
      {
         foreach ( List<IHasScore> dataSet in dataSets )
            TransformAndOutputItems( transformer, dataSet );
      }
   }
}
