namespace CustomClothing.Dtos
{
    // DTO для регистрации пользователя
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty; // Имя пользователя
        public string Email { get; set; } = string.Empty;    // Email пользователя
        public string Password { get; set; } = string.Empty; // Пароль
    }

    // DTO для авторизации пользователя
    public class UserLoginDto
    {
        public string Username { get; set; } = string.Empty; // Имя пользователя
        public string Password { get; set; } = string.Empty; // Пароль
    }

    // DTO для передачи данных о пользователе клиенту
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Userrole { get; set; } = string.Empty;
        public DateTime Createddate { get; set; }
    }
}