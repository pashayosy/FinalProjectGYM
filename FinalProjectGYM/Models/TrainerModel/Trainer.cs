using System;
using FinalProjectGYM.Models.PersonModel;

namespace FinalProjectGYM.Models.TrainerModel
{
	public class Trainer : Person
	{
        public BankDetails BankAccount { private set; get; }
        public string Profession { private set; get; }

        public Trainer(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email, BankDetails bankAccount, string profession) : base(id, name, lastName, gender, date, city, address, phone, email)
        {
            bankAccount = new BankDetails(bankAccount);
            Profession = profession;
        }
    }
}

