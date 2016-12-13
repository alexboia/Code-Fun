using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
   public interface IScoreToRankTransformer
   {
      List<IHasRank> ComputeRank( List<IHasScore> itemsWithScore );

      string Name
      {
         get;
      }
   }
}
