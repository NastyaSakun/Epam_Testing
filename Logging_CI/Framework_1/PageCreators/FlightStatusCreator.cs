using Framework_1.PageModels;
namespace Framework_1.PageCreators
{
    public class FlightStatusCreator
    {
        public ModelFlightStatus DataForFlighStatus()
        {
            return new ModelFlightStatus(CheckInUserConfig.GetData("AloneCity"));
        }
    }
}
