using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
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
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";

            if (IsPlayer1ScoreEqualsPlayer2Score()) score = GetEvenScore(m_score1);

            else if (IsEndgame()) score = GetEndGameScore(m_score1, m_score2);

            else score = GetNormalScore();

            return score;
        }


        private bool IsPlayer1ScoreEqualsPlayer2Score() => m_score1 == m_score2;
        private bool IsEndgame() => m_score1 >= 4 || m_score2 >= 4;


        private string GetEvenScore(int score1)
        {
            return score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }

        private string GetEndGameScore(int score1, int score2)
        {
            string score;

            var minusResult = Math.Abs(score1 - score2);

            if (minusResult == 1)
                score = score1 > score2 ? "Advantage player1" : "Advantage player2";
            else
                score = score1 > score2 ? "Win for player1" : "Win for player2";


            return score;
        }

        private string GetNormalScore()
        {

            var normalScore1 = GetScorePoints(m_score1);
            var normalScore2 = GetScorePoints(m_score2);
            return normalScore1 + "-" + normalScore2;

        }

        private string GetScorePoints(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };
        }

    }
}

