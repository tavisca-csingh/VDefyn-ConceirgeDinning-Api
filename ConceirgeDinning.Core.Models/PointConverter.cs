using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    class PointConverter
    {
        public static Dictionary<string, double> PointsConversionStandard = new Dictionary<string, double>()
        {
            {"visa",100 },
            {"capital",200 },
            {"default",100 }

        };

    }

}
