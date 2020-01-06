
namespace Framework_1.PageModels
{
    public class ModelSignUp
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string RPassword { get; set; }
        public string Mail { get; set; }

        public string Number { get; set; }

        public ModelSignUp(string name, string surname, string password, string rPassword, string mail, string number)
        {
            Name = name;
            Surname = surname;
            Password = password;
            RPassword = rPassword;
            Mail = mail;
            Number = number;
        }
    }
}
