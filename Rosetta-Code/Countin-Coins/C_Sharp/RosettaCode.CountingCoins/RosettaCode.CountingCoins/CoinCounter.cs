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

      public CoinCounter( int sumValue, List<int> coinValues )
      {
         if( sumValue <= 0 )
            throw new ArgumentOutOfRangeException( "sumValue" );
         if( coinValues == null )
            throw new ArgumentNullException( "coinValues" );
         if( coinValues.Count == 0 )
            throw new ArgumentException( "List of values cannot be empty", "coinValues" );

         mCoinValues = coinValues;
         mSumValue = sumValue;
      }

      public int CountCoins()
      {
         int totalCount = 0;
         return totalCount;
      }
   }
}
