namespace Tennis
{
    public class TennisGame2() : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        public string GetScore()
        {
            // Tied score
            if (_p1Point == _p2Point)
            {
                if (_p1Point < 3)
                    return ScoreToString(_p1Point) + "-All";
                return "Deuce";
            }

            // If either player has at least 4 points, check for advantage/win
            if (_p1Point < 4 && _p2Point < 4) return ScoreToString(_p1Point) + "-" + ScoreToString(_p2Point);
            
            var diff = _p1Point - _p2Point;

            return diff switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                <= -2 => "Win for player2",
                _ => ScoreToString(_p1Point) + "-" + ScoreToString(_p2Point)
            };

            // Normal score (both less than 4 and not tied)
        }

        private static string ScoreToString(int score) => score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => string.Empty
        };

        public void SetP1Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            _p1Point++;
        }

        private void P2Score()
        {
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            switch (player)
            {
                case "player1":
                    P1Score();
                    break;
                default:
                    P2Score();
                    break;
            }
        }

    }
}
