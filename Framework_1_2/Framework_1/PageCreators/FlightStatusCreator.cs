using Framework_1.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1.PageCreators
{
    class FlightStatusCreator
    {
        public ModelFlightStatus DataForFlighStatus()
        {
            return new ModelFlightStatus(CheckInUserConfig.GetData("AloneCity"));
        }
    }
}
