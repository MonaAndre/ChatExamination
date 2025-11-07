namespace ChatExamination;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    private static List<User> userList = new List<User>
    {
        new User("Mona", "Mona123")
    };

    public static bool LoginUser()
    {
        Console.Write("Enter your username: ");
        string usernameInput = Console.ReadLine();
        Console.Write("Enter your password: ");
        string passwordInput = Console.ReadLine();
        User foundUser = userList.Find(u => u.Username == usernameInput && u.Password == passwordInput);
        if (foundUser == null)
        {
              return false;
        }

        return true;

    }
}