namespace Boardgames.Data.Common;

public static class FieldValidation
{
    public const int BoardgameNameMinLength = 10;
    public const int BoardgameNameMaxLength = 20;
    public const double BoardgameRatingMinValue = 1.00d;
    public const double BoardgameRatingMaxValue = 10.00d;
    public const int BoardgameYearPublishedMinValue = 2018;
    public const int BoardgameYearPublishedMaxValue = 2023;

    public const int CreatorNameMinLength = 2;
    public const int CreatorNameMaxLength = 7;

    public const int SellerNameMinLength = 5;
    public const int SellerNameMaxLength = 20;
    public const int SellerAddressMinLength = 2;
    public const int SellerAddressMaxLength = 30;
}
