using BCrypt.Net;

public class AuthService
{
    // Método para hash de la contraseña
    public string HashPassword(string password)
    {
        // Genera un hash seguro de la contraseña
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Método para verificar la contraseña contra el hash almacenado
    public bool VerifyPassword(string password, string hashedPassword)
    {
        // Compara la contraseña proporcionada con el hash almacenado
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
