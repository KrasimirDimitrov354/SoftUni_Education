namespace Forum.Common;

public static class EntityValidations
{
    public static class Post
    {
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;
        public const string InvalidTitleMessage = "Post title must be between 10 and 50 characters long.";

        public const int ContentMinLength = 30;
        public const int ContentMaxLength = 1500;
        public const string InvalidContentMessage = "Post content must be between 30 and 1500 character long.";
    }
}