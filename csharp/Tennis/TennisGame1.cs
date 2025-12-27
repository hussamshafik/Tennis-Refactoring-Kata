using System;

namespace Tennis;

public class TennisGame1(string player1Name, string player2Name) : ITennisGame
{
    private int _mScore1 = 0;
    private int _mScore2 = 0;
    private string _player1Name = player1Name;
    private string _player2Name = player2Name;

    public void WonPoint(string playerName)
    {
        if (playerName == "player1") _mScore1 += 1;
        else _mScore2 += 1;
    }

    public string GetScore()
    {
        var score = "";
        if (IsPlayer1ScoreEqualsPlayer2Score()) score = GetEvenScore(_mScore1);
        else if (IsEndgame()) score = GetEndGameScore(_mScore1, _mScore2);
        else score = GetNormalScore();
        return score;
    }


    private bool IsPlayer1ScoreEqualsPlayer2Score()
    {
        return _mScore1 == _mScore2;
    }

    private bool IsEndgame()
    {
        return _mScore1 >= 4 || _mScore2 >= 4;
    }


    private static string GetEvenScore(int score1)
    {
        return score1 switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };
    }

    private static string GetEndGameScore(int score1, int score2)
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
        var normalScore1 = GetScorePoints(_mScore1);
        var normalScore2 = GetScorePoints(_mScore2);
        return normalScore1 + "-" + normalScore2;
    }

    private static string GetScorePoints(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => ""
        };
    }
}