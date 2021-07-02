using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxScoreModel
{
    // max score between game sessions
    private int _maxScore;

    public int MaxScore
    {
        get => _maxScore;
        set => _maxScore = value;
    }
}
