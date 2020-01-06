using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1.PageModels
{
    public class ModelFlightStatus
    {
        public string CitytFrom { get; set; }
        public ModelFlightStatus(string cityFrom)
        {
            CitytFrom = cityFrom;
        }

    }
}
