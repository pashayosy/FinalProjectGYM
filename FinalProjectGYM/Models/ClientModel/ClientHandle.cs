using FinalProjectGYM.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProjectGYM.Models.ClientModel
{
    internal static class ClientHandle
    {
        public static void ClientCreate()
        {
            string id;
            while (FileHandle.IsClientExist(id = CorrectInput("1.ID NUMBER:\nPlease enter ID number (9 digits).", PersonValidation.IsCorrectId))) ;
            string name = CorrectInput("2.FIRST NAME:\nPlease enter First name.", PersonValidation.IsCorrectName);
            string lastName = CorrectInput("3.LAST NAME:\nPlease enter Last name.", PersonValidation.IsCorrectLastName);
            char gender = CorrectInput("4.GENDER:\nPlease enter gender(F / M / O).", PersonValidation.IsCorrectGender)[0];
            string date = CorrectInput("5.DATE OF BIRTH:\nPlease enter date of birth(day / month / full year)", PersonValidation.IsCorrectDateOfBirth);
            string city = CorrectInput("6.City\nPlease enter City:", PersonValidation.IsCorrectCity);
            string address = CorrectInput("7.ADDRESS:\nPlease enter Address.", PersonValidation.IsCorrectAddress);
            string phone = CorrectInput("8.PHONE:\nPlease enter mobile phone number", PersonValidation.IsCorrectPhone);
            string email = CorrectInput("9.EMAIL:\nPlease enter email address.", PersonValidation.IsCorrectEmail);
            double height = double.Parse(CorrectInput("10. HEIGHT:\nPlease enter height.", ClientValidation.IsCorrectHeight));
            double weight = double.Parse(CorrectInput("11. WEIGHT:\nPlease enter weight.", ClientValidation.IsCorrectWeight));

            Client client = new Client(id , name, lastName, gender, date, city, address, phone, email, height, weight);
            FileHandle.ClientAdd(client);
        }

        public static string CorrectInput(string message, Func<string,bool> validation)//need message and validation function to return correcr data
        {
            string correctInput;
            Console.WriteLine(message);
            correctInput = Console.ReadLine();
            while (!validation(correctInput))
            {
                correctInput = Console.ReadLine();
            }

            return correctInput;
        }

        public static void ListPrint(Client[]clients)
        {
            foreach (Client client in clients) 
            {
                Console.WriteLine(client);
            }
        }
    }
}
