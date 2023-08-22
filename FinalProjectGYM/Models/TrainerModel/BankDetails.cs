using System;
namespace FinalProjectGYM.Models.TrainerModel
{
	public class BankDetails
	{
        public string BankName			{ private set; get; }
		public string BankBranch		{ private set; get; }
		public string BankAccountNuber  { private set; get; }

        public BankDetails(string bankName, string bankBranch, string bankAccountNuber)
        {
            BankName = bankName;
            BankBranch = bankBranch;
            BankAccountNuber = bankAccountNuber;
        }

        public BankDetails(BankDetails b)
        {
            BankName = b.BankName;
            BankBranch = b.BankBranch;
            BankAccountNuber = b.BankAccountNuber;
        }
    }
}

