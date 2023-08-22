using FinalProjectGYM.Models.PersonModel;

namespace FinalProjectGYM.Models.ClientModel
{
	public class Client : Person
	{
        private double _height;
        public string Height
        {
            set
            {
                if (ClientValidation.IsCorrectHeight(value))
                {
                    _height = double.Parse(value);
                    Bmi = _weight / Math.Pow(_height, 2);
                }
            }
            get
            {
                return _height.ToString();
            }
        }

        private double _weight;
        public string Weight
        {
            set
            {
                if (ClientValidation.IsCorrectHeight(value))
                {
                    _weight = double.Parse(value);
                    Bmi = _weight / Math.Pow(_height, 2);
                }
            }
            get
            {
                return _weight.ToString();
            }
        }

        public double Bmi { private set; get; }

        public Client(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email, double height, double weight) : base(id, name, lastName, gender, date, city, address, phone, email)
        {
            _height = height;
            _weight = weight;
            Bmi = weight / Math.Pow(height, 2);
        }
    }
}

