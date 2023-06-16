namespace TaskBoard.Common;

public static class EntityExceptionMessages
{
    public static class Board
    {
        public const string InvalidBoardIdMessage = "Selected board does not exist!";
    }

    public static class Task
    {
        public const string DeletingTaskExceptionMessage = "Unexpected error occured while deleting your task!";
    }
}
