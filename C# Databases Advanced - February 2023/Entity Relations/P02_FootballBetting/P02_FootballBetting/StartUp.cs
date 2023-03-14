namespace FootballBetting;

public class StartUp
{
    static void Main()
    {
        //Entity models:
        //  •	FootballBettingContext – DbContext
        //  •	Team – TeamId, Name, LogoUrl, Initials, Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
        //  •	Color – ColorId, Name
        //  •	Town – TownId, Name, CountryId
        //  •	Country – CountryId, Name
        //  •	Player – PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
        //  •	Position – PositionId, Name
        //  •	PlayerStatistic – GameId, PlayerId, ScoredGoals, Assists, MinutesPlayed
        //  •	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result
        //  •	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId
        //  •	User – UserId, Username, Password, Email, Name, Balance
        //
        //Table relationships:
        //  •	A Team has one PrimaryKitColor and one SecondaryKitColor
        //  •	A Color has many PrimaryKitTeams and many SecondaryKitTeams
        //  •	A Team residents in one Town
        //  •	A Town can host several Teams
        //  •	A Game has one HomeTeam and one AwayTeam and a Team can have many HomeGames and many AwayGames
        //  •	A Town can be placed in one Country and a Country can have many Towns
        //  •	A Player can play for one Team and one Team can have many Players
        //  •	A Player can play at one Position and one Position can be played by many Players
        //  •	One Player can play in many Games and in each Game, many Players take part
        //  •	Many Bets can be placed on one Game, but a Bet can be only on one Game
        //  •	Each bet for given game must have Prediction result
        //  •	A Bet can be placed by only one User and one User can place many Bets
    }
}