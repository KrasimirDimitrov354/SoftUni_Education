namespace Homies.Common;

public static class EntityColumnInformation
{
    public static class Event
    {
        public const string IdComment = "ID of the event";
        public const string NameComment = "Name of the event";
        public const string DescriptionComment = "Description of the event";
        public const string OrganiserIdComment = "ID of the organiser of the event";
        public const string CreatedOnComment = "Date when the event was created";
        public const string StartComment = "Event start date";
        public const string EndComment = "Event end date";
        public const string TypeIdComment = "ID of the type of the event";
    }

    public static class Type
    {
        public const string IdComment = "ID of the type";
        public const string NameComment = "Name of the type";
    }

    public static class EventParticipant
    {
        public const string HelperIdComment = "ID of the helper for the event";
        public const string EventIdComment = "ID of the event the helper is participating in";
    }
}