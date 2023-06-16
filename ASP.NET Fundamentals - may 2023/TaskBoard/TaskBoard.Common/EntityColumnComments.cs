namespace TaskBoard.Common;

public static class EntityColumnComments
{
    public static class Task
    {
        public const string IdComment = "ID of the task";
        public const string TitleComment = "Title of the task";
        public const string DescriptionComment = "Description of the task";
        public const string CreatedOnComment = "Date and time when the task was created";
        public const string EditedOnComment = "Date and time when the task was edited";
        public const string BoardIdComment = "ID of the board of the task";
        public const string OwnerIdComment = "ID of the owner of the task";
    }

    public static class Board
    {
        public const string IdComment = "ID of the board";
        public const string NameComment = "Name of the board";
    }
}
