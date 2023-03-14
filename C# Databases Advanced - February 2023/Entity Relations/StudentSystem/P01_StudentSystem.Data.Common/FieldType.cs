namespace P01_StudentSystem.Data.Common;

public static class FieldType
{
    public const string StudentNameType = "nvarchar(100)";
    public const string StudentPhoneNumberType = "char(10)";
    public const string StudentBirthdayType = "date";

    public const string CourseNameType = "nvarchar(80)";
    public const string CourseDescriptionType = "nvarchar(256)";

    public const string ResourceNameType = "nvarchar(50)";
    public const string ResourceUrlType = "varchar(2048)";

    public const string HomeworkContentType = "varchar(2048)";
}
