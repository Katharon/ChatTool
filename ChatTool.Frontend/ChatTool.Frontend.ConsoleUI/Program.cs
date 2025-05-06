namespace ChatTool.Frontend.ConsoleUI
{
    using System;

    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var authService = new AuthService();
            bool authenticated = false;

            while (true)
            {
                Console.Write("Willst du dich registrieren (1) oder einloggen (2): ");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                Console.WriteLine();
                Console.WriteLine();

                if (cki.Key is ConsoleKey.D1)
                {
                    var registerDto = new RegisterDto
                    {
                        Email = GetValidUserInput("Gib deine Email-Adresse ein: "),
                        UserName = GetValidUserInput("Gib deinen Benutzernamen ein: "),
                        Password = GetValidUserInput("Gib dein Passwort ein: "),
                    };

                    bool success = await authService.RegisterAsync(registerDto);
                    if (!success)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Registrierung fehlgeschlagen!\n");
                        Console.ResetColor();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registrierung erfolgreich!\n");
                    Console.ResetColor();
                    continue;
                }
                else if (cki.Key is ConsoleKey.D2)
                {
                    var loginDto = new LoginDto
                    {
                        Email = GetValidUserInput("Gib deine Email-Adresse ein: "),
                        Password = GetValidUserInput("Gib dein Passwort ein: "),
                    };

                    bool success = await authService.LoginAsync(loginDto);
                    if (!success)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Login fehlgeschlagen!\n");
                        Console.ResetColor();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login erfolgreich!\n");
                    Console.ResetColor();
                    authenticated = true;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehlerhafte Eingabe!");
                    Console.ResetColor();
                }
            }

            if (authenticated)
            {
                var userService = new UserService();
                string? userName;

                while (true)
                {
                    Console.WriteLine("Mit wem willst du chatten?");

                    userName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        continue;
                    }

                    break;
                }

                Chat(userName);
            }
        }

        private static void Chat(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Du bist nun im Chatfenster angekommen.");
            Console.ResetColor();

            while (true)
            {
                Console.Write("Schreibe eine Nachricht: ");
                string? message = Console.ReadLine();


                var messageService = new MessageService();
                //messageService.GetConversationAsync();
            }
        }

        public static string GetValidUserInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Length < 8 || input.Length > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehlerhafte Eingabe!\n");
                    Console.ResetColor();
                    continue;
                }

                return input;
            }
        }
    }
}
