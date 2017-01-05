using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.CountingCoins
{
   public class CoinCounter
   {
      private List<int> mCoinValues;

      private int mSumValue;

      private long[,] mCache;

      public CoinCounter( int sumValue, List<int> coinValues )
      {
         if( sumValue <= 0 )
            throw new ArgumentOutOfRangeException( "sumValue" );
         if( coinValues == null )
            throw new ArgumentNullException( "coinValues" );
         if( coinValues.Count == 0 )
            throw new ArgumentException( "List of values cannot be empty", "coinValues" );

         mCoinValues = coinValues
            .OrderByDescending(c => c)
            .ToList();

         mSumValue = sumValue;
         mCache = new long[ sumValue + 1, coinValues.Count ];
      }

      private long Count(int sumValue, int index)
      {
         if( index >= mCoinValues.Count)
            return 0;

         if( sumValue < 0 )
            return 0;

         if( sumValue == 0 )
            return 1;

         if( mCache[ sumValue, index ] > 0 )
            return mCache[ sumValue, index ];

         long c = 0;
         for( int i = index; i < mCoinValues.Count; i++ )
            c += Count( sumValue - mCoinValues[ i ], i );

         mCache[ sumValue, index ] = c;

         return c;
      }

      public long CountCoins()
      {
         return Count( mSumValue, 0 );
      }
   }
}
