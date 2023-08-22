namespace FinalProjectGYM.Models.PersonModel
{
	public abstract class Person
	{
        public string Id		{ private set; get; }
		public string Name		{ private set; get; }
		public string LastName	{ private set; get; }
		public char	  Gender	{ private set; get; }
		public string Date		{ private set; get; }
		public string City		{ private set; get; }
		public string Address	{ private set; get; }
		public string Phone		{ private set; get; }
		public string Email		{ private set; get; }


        protected Person(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Gender = gender;
            Date = date;
            City = city;
            Address = address;
            Phone = phone;
            Email = email;
        }




    }
}

