namespace ChatExamination;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool isLoggedIn { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    private static List<User> userList = new List<User>
    {
        new User("mona", "Mona123")
    };

    public static User LoginUser()
    {
        Console.WriteLine();
        Console.WriteLine("LOGIN");
        string usernameInput = string.Empty;
        string passwordInput = string.Empty;
        while (string.IsNullOrWhiteSpace(usernameInput))
        {
            Console.Write("Enter your username: ");
            usernameInput = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(usernameInput))
            {
                Console.WriteLine("Username cannot be empty. Please try again.\n");
            }
        }

        while (string.IsNullOrWhiteSpace(passwordInput))
        {
            Console.Write("Enter your password: ");
            passwordInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(passwordInput))
            {
                Console.WriteLine("Password cannot be empty. Please try again.\n");
            }
        }

        User foundUser = userList.Find(user =>
            user.Username == usernameInput &&
            user.Password == passwordInput);

        if (foundUser == null)
        {
            Console.WriteLine("Invalid username or password");
            return null;
        }

        User currentUser = new User(foundUser.Username, foundUser.Password)
        {
            isLoggedIn = true
        };
        Console.WriteLine($"Welcome {currentUser.Username}, You have been logged in!");
        return currentUser;
    }

    public static void RegisterUser()
    {
        string newUsername = string.Empty;
        string newPassword = string.Empty;
        Console.WriteLine("Registration");
        while (true)
        {
            Console.Write("Enter a new username: ");
            newUsername = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                Console.WriteLine("Username cannot be empty.\n");
                continue;
            }

            if (userList.Exists(user => user.Username == newUsername))
            {
                Console.WriteLine("That username already exists. Please choose another.\n");
                continue;
            }

            break;
        }

        while (string.IsNullOrWhiteSpace(newPassword))
        {
            Console.Write("Enter a new password: ");
            newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.\n");
            }
        }

        userList.Add(new User(newUsername, newPassword));
        Console.WriteLine($"{newUsername}, your user has been created!");
    }
}