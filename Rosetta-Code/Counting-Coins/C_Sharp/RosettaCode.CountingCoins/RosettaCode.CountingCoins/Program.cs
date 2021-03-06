﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.CountingCoins
{
   public class Program
   {
      public static void Main( string[] args )
      {
         CoinCounter counter = new CoinCounter( 100000, new List<int>() {100, 50, 25, 10, 5, 1 } );

         long totalCombinations = counter.CountCoins();

         Console.WriteLine( "Total combinations: {0}", totalCombinations );
         Console.ReadKey();
      }
   }
}
