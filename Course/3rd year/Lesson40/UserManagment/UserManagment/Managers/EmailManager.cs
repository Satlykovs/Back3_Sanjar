using UserManagment.Interfaces;


public class EmailManager : IEmailManager
{
    public void SendWelcomeEmail(string email)
    {
        Console.WriteLine($"Sending welcome email to {email}");
    }
}