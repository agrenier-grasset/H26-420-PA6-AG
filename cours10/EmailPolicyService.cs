namespace cours10;

public class EmailPolicyService
{
    public void Validate(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("L'email ne peut pas être vide.");
        if (!email.Contains('@'))
            throw new ArgumentException("L'email doit contenir le caractère '@'.");
    }
}
