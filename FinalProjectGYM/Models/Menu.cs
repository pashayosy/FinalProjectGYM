using System.Text;

namespace FinalProjectGYM.Models
{
	public static class Menu
	{
        enum PERSONFUNCTION { ADD = 1, EDIT, DELETE, LIST, RETURN }
        public static int createMenu(string[]optionNames)//create menu of my choose
		{
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Gym Application!");
            Console.ResetColor();
            Console.WriteLine("\nUse \u2191 and \u2193 to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < optionNames.Length; i++)
                {
                    Console.WriteLine($"{(option == i + 1 ? decorator : "   ")}{optionNames[i]}\u001b[0m ");
                }

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? optionNames.Length : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        option = option == optionNames.Length ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            return option;
        }

        public static void MenuInteraction()//interact with the menu i create
        {
            int position;
            position = Menu.createMenu(new string[] { "Client", "Coach" });
            if (position == 1)
            {
                position = Menu.createMenu(new string[] { "Add Client", "Edit Client", "Delete Client", "List all Client", "Return" });
                ClientFunctionDo(position);
            }
            else
            {
                position = Menu.createMenu(new string[] { "Add Coach", "Edit Coach", "Delete Coach", "List all Coach", "Return" });
            }
        }

        public static void ClientFunctionDo(int position)//start methods that the user choose
        {
            switch (position)
            {
                case (int)PERSONFUNCTION.ADD:
                    break;
                case (int)PERSONFUNCTION.EDIT:
                    break;
                case (int)PERSONFUNCTION.DELETE:
                    break;
                case (int)PERSONFUNCTION.LIST:
                    break;
                case (int)PERSONFUNCTION.RETURN:
                    break;
            }
        }
	}
}

