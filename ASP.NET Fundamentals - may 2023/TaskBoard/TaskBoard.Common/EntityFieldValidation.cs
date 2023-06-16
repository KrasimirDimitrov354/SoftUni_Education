namespace TaskBoard.Common;

public static class EntityFieldValidation
{
    public static class User
    {
        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 50;
        public const string UsernameLengthErrorMessage = "Username should be between 3 and 50 symbols long.";
    }

    public static class Password
    {
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 100;
        public const string PasswordLengthErrorMessage = "Password should be between 6 and 100 symbols long.";
        public const string PasswordNotMatchingErrorMessage = "The password and confirmation password do not match.";
    }

    public static class Task
    {
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 70;
        public const string TitleLengthErrorMessage = "Title should be between 5 and 70 symbols long.";

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 1000;
        public const string DescriptionLengthErrorMessage = "Description should be between 10 and 1000 symbols long.";
    }

    public static class Board
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 30;
        public const string NameLengthErrorMessage = "Title should be between 3 and 30 symbols long.";
    }
}