using Framework_1.PageModels;

namespace Framework_1.PageCreators
{
    public class SignUpCreator
    {
        public ModelSignUp DataForRegistration()
        {
            return new ModelSignUp(CheckInUserConfig.GetData("Name"), CheckInUserConfig.GetData("Surname"),
                CheckInUserConfig.GetData("Password"), CheckInUserConfig.GetData("Password"), CheckInUserConfig.GetData("Mail"), CheckInUserConfig.GetData("Number"));
        }
    }
}
