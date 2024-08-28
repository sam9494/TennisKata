using TennisKata;

namespace TennisGameTest

{
    public class TennisGameTest
    {
        private Tennis _tennis;

        private void GivenTennisGamePlayers(string playerOneName = "PlayerOne", string playerTwoName = "PlayerTwo")
        {
            _tennis = new Tennis(playerOneName, playerTwoName);
        }

        [Fact]
        public void ShouldBeLoveAll_WhenBothPlayers_AreUnscored()
        {
            GivenTennisGamePlayers();
            var score = _tennis.Score();

            Assert.Equal("Love All", score);
        }

        [Fact]
        public void ShouldBeFifteenLove_WhenPlayer1_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(1, 0);

            var score = _tennis.Score();
            Assert.Equal("Fifteen Love", score);
        }

        [Fact]
        public void ShouldBeThirtyLove_WhenPlayer1_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 0);

            var score = _tennis.Score();
            Assert.Equal("Thirty Love", score);
        }

        [Fact]
        public void ShouldBeThirtyFifteen_WhenPlayer1_GotTwoPoint_AndPlayer2_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 1);

            var score = _tennis.Score();
            Assert.Equal("Thirty Fifteen", score);
        }

        [Fact]
        public void ShouldBeThirtyAll_WhenBothPlayers_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 2);

            var score = _tennis.Score();
            Assert.Equal("Thirty All", score);
        }

        [Fact]
       public void ShouldBeFortyThirty_WhenPlayer1_GotThreePoints_AndPlayer2_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3,2);

            var score = _tennis.Score();
            Assert.Equal("Forty Thirty", score);
        }

        [Fact]
        public void ShouldBeDeuce_SinceBothPlayers_HittedThreePoints_OrMore()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3, 3);

            var score = _tennis.Score();
            Assert.Equal("Deuce", score);
        }

        [Fact]
        public void ShoulBePlayer1Adv_WhenAfterDeuce_AndPlayer1_HavingOnePointLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(4, 3);

            var score = _tennis.Score();
            Assert.Equal("PlayerOne Adv", score);
        }

        [Fact]
        public void ShouldBePlayer2Win_WhenAfterAdv_AndPlayer2_HavingTwoPointsLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(5,7);

            var score = _tennis.Score();
            Assert.Equal("PlayerTwo Win!", score);
        }


        private void SetPlayerScore(int playerOneScore, int playerTwoScore)
        {
            for (int i = 0; i < playerOneScore; i++ )
            {
                _tennis.PlayerOneScore();
            }

            for (int j = 0; j < playerTwoScore; j++)
            {
                _tennis.PlayerTwoScore();
            }
        }
    }






}