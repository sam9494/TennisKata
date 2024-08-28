using TennisKata;

namespace TennisGameTest

{
    public class TennisGameTest
    {
        private Tennis _tennis;

        public TennisGameTest()
        {
            _tennis = new Tennis("PlayerOne", "PlayerTwo");
        }

        private void GivenTennisGamePlayers(string playerOneName = "PlayerOne", string playerTwoName = "PlayerTwo")
        {
            _tennis = new Tennis(playerOneName, playerTwoName);
        }

        private string ShouldScoreMeaningBe ()
        {
            return _tennis.Score();
        }

        [Fact]
        public void ShouldBeLoveAll_WhenBothPlayers_AreUnscored()
        {
            GivenTennisGamePlayers();
            //ShouldScoreMeaningBe();

            Assert.Equal("Love All", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShouldBeFifteenLove_WhenPlayer1_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(1, 0);
            ShouldScoreMeaningBe();

            Assert.Equal("Fifteen Love", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShouldBeThirtyLove_WhenPlayer1_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 0);
            ShouldScoreMeaningBe();

            Assert.Equal("Thirty Love", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShouldBeThirtyFifteen_WhenPlayer1_GotTwoPoint_AndPlayer2_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 1);
            ShouldScoreMeaningBe();

            Assert.Equal("Thirty Fifteen", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShouldBeThirtyAll_WhenBothPlayers_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 2);
            ShouldScoreMeaningBe();

            Assert.Equal("Thirty All", ShouldScoreMeaningBe());
        }

        [Fact]
       public void ShouldBeFortyThirty_WhenPlayer1_GotThreePoints_AndPlayer2_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3,2);
            ShouldScoreMeaningBe();

            Assert.Equal("Forty Thirty", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShouldBeDeuce_SinceBothPlayers_HittedThreePoints_OrMore()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3, 3);
            ShouldScoreMeaningBe();

            Assert.Equal("Deuce", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShoulBePlayer1Adv_WhenAfterDeuce_AndPlayer1_HavingOnePointLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(4, 3);
            ShouldScoreMeaningBe();

            Assert.Equal("PlayerOne Adv", ShouldScoreMeaningBe());
        }

        [Fact]
        public void ShouldBePlayer2Win_WhenAfterAdv_AndPlayer2_HavingTwoPointsLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(5,7);
            ShouldScoreMeaningBe();

            Assert.Equal("PlayerTwo Win!", ShouldScoreMeaningBe());
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