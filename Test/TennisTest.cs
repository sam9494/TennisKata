using TennisKata;

namespace TestProject
{
    public class TennisTest
    {
        private readonly Tennis _tennis;
        public TennisTest()
        {
            _tennis = new Tennis("Sam1", "Sam2");
        }

        [Fact]
        public void Score_InputNothing_ReturnLoveAll()
        {
            Assert.Equal("Love All", _tennis.Score());
        }

        [Fact]
        public void Score_Input_1_0_ReturnFifteenLove()
        {
            _tennis.GiveScoreToPlayers(1, 0);
            Assert.Equal("Fifteen Love", _tennis.Score());
        }

        [Fact]
        public void Score_Input_2_0_ReturnThirtyLove()
        {
            _tennis.GiveScoreToPlayers(2, 0);
            Assert.Equal("Thirty Love", _tennis.Score());
        }

        [Fact]
        public void Score_Input_3_0_ReturnFortyLove()
        {
            _tennis.GiveScoreToPlayers(3, 0);
            Assert.Equal("Forty Love", _tennis.Score());
        }

        [Fact]
        public void Score_Input_0_1_ReturnLoveFifteen()
        {
            _tennis.GiveScoreToPlayers(0, 1);
            Assert.Equal("Love Fifteen", _tennis.Score());
        }

        [Fact]
        public void Score_Input_0_2_ReturnLoveThirty()
        {
            _tennis.GiveScoreToPlayers(0, 2);
            Assert.Equal("Love Thirty", _tennis.Score());
        }

        [Fact]
        public void Score_Input_0_3_ReturnLoveForty()
        {
            _tennis.GiveScoreToPlayers(0, 3);
            Assert.Equal("Love Forty", _tennis.Score());
        }

        [Fact]
        public void Score_Input_1_1_ReturnFifteenAll()
        {
            _tennis.GiveScoreToPlayers(1, 1);
            Assert.Equal("Fifteen All", _tennis.Score());
        }

        [Fact]
        public void Score_Input_2_2_ReturnThirtyAll()
        {
            _tennis.GiveScoreToPlayers(2, 2);
            Assert.Equal("Thirty All", _tennis.Score());
        }

        [Fact]
        public void Score_Input_3_3_ReturnDeuce()
        {
            _tennis.GiveScoreToPlayers(3, 3);
            Assert.Equal("Deuce", _tennis.Score());
        }

        [Fact]
        public void Score_Input_4_3_ReturnSam1Adv()
        {
            _tennis.GiveScoreToPlayers(4, 3);
            Assert.Equal("Sam1 Adv", _tennis.Score());
        }

        [Fact]
        public void Score_Input_5_3_ReturnSam1Win()
        {
            _tennis.GiveScoreToPlayers(5, 3);
            Assert.Equal("Sam1 Win", _tennis.Score());
        }

        [Fact]
        public void Score_Input_3_4_ReturnSam2Adv()
        {
            _tennis.GiveScoreToPlayers(3, 4);
            Assert.Equal("Sam2 Adv", _tennis.Score());
        }

        [Fact]
        public void Score_Input_3_5_ReturnSam2Win()
        {
            _tennis.GiveScoreToPlayers(3, 5);
            Assert.Equal("Sam2 Win", _tennis.Score());
        }

        //保險加測

        #region additionalTest

        [Fact]
        public void Score_Input_4_4_ReturnDeuce()
        {
            _tennis.GiveScoreToPlayers(4, 4);
            Assert.Equal("Deuce", _tennis.Score());
        }

        [Fact]
        public void Score_Input_5_4_ReturnSam1Adv()
        {
            _tennis.GiveScoreToPlayers(5, 4);
            Assert.Equal("Sam1 Adv", _tennis.Score());
        }

        [Fact]
        public void Score_Input_4_5_ReturnSam2Adv()
        {
            _tennis.GiveScoreToPlayers(4, 5);
            Assert.Equal("Sam2 Adv", _tennis.Score());
        }

        [Fact]
        public void Score_Input_6_4_ReturnSam1Win()
        {
            _tennis.GiveScoreToPlayers(6, 4);
            Assert.Equal("Sam1 Win", _tennis.Score());
        }

        [Fact]
        public void Score_Input_4_6_ReturnSam2Win()
        {
            _tennis.GiveScoreToPlayers(4, 6);
            Assert.Equal("Sam2 Win", _tennis.Score());
        }


        #endregion


    }
}