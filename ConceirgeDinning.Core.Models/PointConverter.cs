using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class PointConverter
    {
        public static Dictionary<string,int> PointsConversionStandard = new Dictionary<string,int>()
        {
            {"visa",100 },
            {"capital",200 },
            {"default",100 }

        };

    }

}
