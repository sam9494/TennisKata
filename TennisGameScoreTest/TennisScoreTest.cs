using TennisKata;

namespace TennisGameTest

{
    public class TennisGameTest
    {

        private void GivenTennisGamePlayers(string playerOneName = "PlayerOne", string playerTwoName = "PlayerTwo")
        {
            _tennis = new Tennis(playerOneName, playerTwoName);
        }

        private string IsScoreMeaning()
        {
            return _tennis.Score();
        }

        private Tennis _tennis;

        private void SetPlayerScore(int playerOneScore, int playerTwoScore)
        {
            for (int i = 0; i < playerOneScore; i++)
            {
                _tennis.PlayerOneScore();
            }

            for (int j = 0; j < playerTwoScore; j++)
            {
                _tennis.PlayerTwoScore();
            }
        }


        [Fact]
        public void ShouldBeLoveAll_WhenGame_Initialized()
        {
            GivenTennisGamePlayers();

            Assert.Equal("Love All", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBeFifteenLove_WhenPlayer1_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(1, 0);

            Assert.Equal("Fifteen Love", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBeThirtyLove_WhenPlayer1_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 0);

            Assert.Equal("Thirty Love", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBeThirtyFifteen_WhenPlayer1_GotTwoPoint_AndPlayer2_GotOnePoint()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 1);

            Assert.Equal("Thirty Fifteen", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBeThirtyAll_WhenBothPlayers_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(2, 2);

            Assert.Equal("Thirty All", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBeFortyThirty_WhenPlayer1_GotThreePoints_AndPlayer2_GotTwoPoints()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3, 2);

            Assert.Equal("Forty Thirty", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBeDeuce_SinceBothPlayers_HittedThreePoints_OrMore()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(3, 3);

            Assert.Equal("Deuce", IsScoreMeaning());
        }

        [Fact]
        public void ShoulBePlayer1Adv_WhenAfterDeuce_AndPlayer1_HavingOnePointLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(4, 3);

            Assert.Equal("PlayerOne Adv", IsScoreMeaning());
        }

        [Fact]
        public void ShouldBePlayer2Win_WhenAfterAdv_AndPlayer2_HavingTwoPointsLead()
        {
            GivenTennisGamePlayers();
            SetPlayerScore(5, 7);

            Assert.Equal("PlayerTwo Win!", IsScoreMeaning());
        }

    }






}