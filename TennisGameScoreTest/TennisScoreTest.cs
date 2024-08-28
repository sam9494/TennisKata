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

        private string ShouldScoreMeanigBe ()
        {
            return _tennis.Score();
        }

        [Fact]
        public void ShouldBeLoveAll_WhenBothPlayers_AreUnscored()
        {
            GivenTennisGamePlayers();
            ShouldScoreMeanigBe();

            Assert.Equal("Love All", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShouldBeFifteenLove_WhenPlayer1_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(1, 0);
            ShouldScoreMeanigBe();

            Assert.Equal("Fifteen Love", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShouldBeThirtyLove_WhenPlayer1_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 0);
            ShouldScoreMeanigBe();

            Assert.Equal("Thirty Love", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShouldBeThirtyFifteen_WhenPlayer1_GotTwoPoint_AndPlayer2_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 1);
            ShouldScoreMeanigBe();

            Assert.Equal("Thirty Fifteen", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShouldBeThirtyAll_WhenBothPlayers_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 2);
            ShouldScoreMeanigBe();

            Assert.Equal("Thirty All", ShouldScoreMeanigBe());
        }

        [Fact]
       public void ShouldBeFortyThirty_WhenPlayer1_GotThreePoints_AndPlayer2_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3,2);
            ShouldScoreMeanigBe();

            Assert.Equal("Forty Thirty", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShouldBeDeuce_SinceBothPlayers_HittedThreePoints_OrMore()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3, 3);
            ShouldScoreMeanigBe();

            Assert.Equal("Deuce", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShoulBePlayer1Adv_WhenAfterDeuce_AndPlayer1_HavingOnePointLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(4, 3);
            ShouldScoreMeanigBe();

            Assert.Equal("PlayerOne Adv", ShouldScoreMeanigBe());
        }

        [Fact]
        public void ShouldBePlayer2Win_WhenAfterAdv_AndPlayer2_HavingTwoPointsLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(5,7);
            ShouldScoreMeanigBe();

            Assert.Equal("PlayerTwo Win!", ShouldScoreMeanigBe());
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