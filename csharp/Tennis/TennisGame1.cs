namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            if (player1Score == player2Score)
            {
                score = AssignTiedScoreValues();
            }
            else if (player1Score >= 4 || player2Score >= 4)
            {
                score = AssignAdvantageOrWin();
            }
            else
            {
                AssignUntiedScore(ref score);
            }
            return score;
        }

        private void AssignUntiedScore(ref string score)
        {
            for (var i = 1; i < 3; i++)
            {
                var tempScore = 0;
                if (i == 1) tempScore = player1Score;
                else { score += "-"; tempScore = player2Score; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }
        }

        private string AssignAdvantageOrWin()
        {
            string score;
            var minusResult = player1Score - player2Score;
            if (minusResult == 1) score = $"Advantage {player1Name}";
            else if (minusResult == -1) score = $"Advantage {player2Name}";
            else if (minusResult >= 2) score = $"Win for {player1Name}";
            else score = $"Win for {player2Name}";
            return score;
        }

        private string AssignTiedScoreValues()
        {
            string score;
            switch (player1Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}

