using System;
using FinalProjectGYM.Models.PersonModel;

namespace FinalProjectGYM.Models.TrainerModel
{
	public class Trainer : Person
	{
        public BankDetails BankAccount 
        {
            set
            {
                if (TrainerValidation.IsCorrectBankName(value.BankName) && TrainerValidation.IsCorrectBankBranch(value.BankBranch) && TrainerValidation.IsCorrectBankAccountNumber(value.BankAccountNumber))
                    _bankAccount = new BankDetails(value);
            }
            get { return _bankAccount; }
        }
        private BankDetails _bankAccount;
        public string Profession
        {
            set
            {
                if(TrainerValidation.IsCorrectProfession(value))
                    _profession = value;
            }
            get { return _profession; }
        }
        private string _profession;

        public Trainer(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email, BankDetails bankAccount, string profession) : base(id, name, lastName, gender, date, city, address, phone, email)
        {
            bankAccount = new BankDetails(bankAccount);
            Profession = profession;
        }
    }
}

