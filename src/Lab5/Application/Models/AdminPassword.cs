using Application.Tools;

namespace Application.Models;

public class AdminPassword
{
    // can add any parameterization you want
    public AdminPassword(string password, int exactCharacters, int maxCharacters = 0)
    {
        MaxCharacters = maxCharacters;
        ExactCharacters = exactCharacters;
        if (password is null)
        {
            throw new CustomException("Null value of admin password");
        }

        if (ExactCharacters != 0 && password.Length != ExactCharacters)
        {
            throw new CustomException("Admin password don't matches it's parameters");
        }

        if (MaxCharacters != 0 && password.Length > MaxCharacters)
        {
            throw new CustomException("Admin password don't matches it's parameters");
        }

        Password = password;
    }

    public string Password { get; private set; }

    public int MaxCharacters { get; }

    public int ExactCharacters { get; }

    public bool ChangePassword(string newPassword)
    {
        if (newPassword is null)
        {
            throw new CustomException("Null value of new admin password");
        }

        if (ExactCharacters != 0 && newPassword.Length != ExactCharacters)
        {
            return false;
        }

        if (MaxCharacters != 0 && newPassword.Length > MaxCharacters)
        {
            return false;
        }

        Password = newPassword;
        return true;
    }
}