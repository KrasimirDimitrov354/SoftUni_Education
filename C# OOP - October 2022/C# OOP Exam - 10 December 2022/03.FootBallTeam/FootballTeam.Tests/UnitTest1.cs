using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private const string VALID_TEAM_NAME = "default";
        private const int VALID_TEAM_CAPACITY = 15;

        private const string VALID_PLAYER_NAME = "Pesho";
        private const int VALID_PLAYER_NUMBER = 7;
        private const string VALID_PLAYER_POSITION = "Forward";

        private FootballTeam defaultTeam;
        private FootballPlayer defaultPlayer;

        [SetUp]
        public void Setup()
        {
            defaultTeam = new FootballTeam(VALID_TEAM_NAME, VALID_TEAM_CAPACITY);
            defaultPlayer = new FootballPlayer(VALID_PLAYER_NAME, VALID_PLAYER_NUMBER, VALID_PLAYER_POSITION);
        }

        [Test]
        public void TeamConstructorShouldCreateTeamWhenInputIsValid()
        {
            FootballTeam team = new FootballTeam(VALID_TEAM_NAME, VALID_TEAM_CAPACITY);

            Assert.That(team.Name, Is.EqualTo(VALID_TEAM_NAME));
            Assert.That(team.Capacity, Is.EqualTo(VALID_TEAM_CAPACITY));
        }

        [Test]
        public void TeamConstructorShouldThrowWhenInputIsInvalid()
        {
            string invalidName = string.Empty;
            int invalidCapacity = 0;

            Assert.Catch(() => new FootballTeam(invalidName, VALID_TEAM_CAPACITY),
                "Name cannot be null or empty!");
            Assert.Catch(() => new FootballTeam(VALID_TEAM_NAME, invalidCapacity),
                "Capacity min value = 15");
        }

        [Test]
        public void AddNewPlayerShouldThrowIfPlayerInputIsInvalid()
        {
            string invalidName = string.Empty;
            int playerNumberTooLow = 0;
            int playerNumberTooHigh = 22;
            string invalidPosition = "invalid";

            Assert.Catch(() => defaultTeam.AddNewPlayer(new FootballPlayer(invalidName, VALID_PLAYER_NUMBER, VALID_PLAYER_POSITION)),
                "Name cannot be null or empty!");
            Assert.Catch(() => defaultTeam.AddNewPlayer(new FootballPlayer(VALID_PLAYER_NAME, playerNumberTooLow, VALID_PLAYER_POSITION)),
                "Player number must be in range [1,21]");
            Assert.Catch(() => defaultTeam.AddNewPlayer(new FootballPlayer(VALID_PLAYER_NAME, playerNumberTooHigh, VALID_PLAYER_POSITION)),
                "Player number must be in range [1,21]");
            Assert.Catch(() => defaultTeam.AddNewPlayer(new FootballPlayer(VALID_PLAYER_NAME, VALID_PLAYER_NUMBER, invalidPosition)),
                "Invalid Position");
        }

        [Test]
        public void AddNewPlayerShouldNotAddPlayerIfTeamCapacityIsReached()
        {
            for (int i = 0; i < defaultTeam.Capacity; i++)
            {
                defaultTeam.AddNewPlayer(defaultPlayer);
            }

            defaultTeam.AddNewPlayer(defaultPlayer);
            Assert.That(defaultTeam.Players.Count, Is.EqualTo(defaultTeam.Capacity));
        }

        [Test]
        public void AddNewPlayerShouldAddPlayerIfTeamCapacityIsNotReached()
        {
            defaultTeam.AddNewPlayer(defaultPlayer);
            Assert.That(defaultTeam.Players.Count, Is.EqualTo(1));
            Assert.That(defaultTeam.Players[0], Is.EqualTo(defaultPlayer));
        }

        [Test]
        public void PickPlayerShouldReturnNullIfPlayerNameDoesNotExist()
        {
            Assert.That(defaultTeam.PickPlayer("Gosho"), Is.EqualTo(null));
        }

        [Test]
        public void PickPlayerShouldReturnPlayerIfPlayerNameExists()
        {
            defaultTeam.AddNewPlayer(defaultPlayer);
            Assert.That(defaultTeam.PickPlayer(VALID_PLAYER_NAME), Is.EqualTo(defaultPlayer));
        }

        [Test]
        public void PlayerScoreShouldThrowIfPlayerNumberDoesNotExist()
        {
            Assert.Catch(() => defaultTeam.PlayerScore(1),
                "Player number does not exist.");
        }

        [Test]
        public void PlayerScoreShouldIncreaseScoreOfPlayerIfPlayerNumberExists()
        {
            defaultTeam.AddNewPlayer(defaultPlayer);
            defaultTeam.PlayerScore(VALID_PLAYER_NUMBER);
            Assert.That(defaultPlayer.ScoredGoals, Is.EqualTo(1));
        }
    }
}