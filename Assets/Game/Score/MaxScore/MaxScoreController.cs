using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxScoreController : AbstractController<MaxScoreModel,MaxScoreView>
{
    // Shows Max Score Between Game Sessions
    public void Init()
    {
        DigitFactory.createDigits(MaxScore, View.transform);
    }

    // retrives max score from all sessions
    public int MaxScore
    {
        get
        {
            Model.MaxScore = PlayerPrefs.GetInt(GameConstants.MAX_SCORE);
            return Model.MaxScore;
        }
        set
        {
            Model.MaxScore = value;
            PlayerPrefs.SetInt(GameConstants.MAX_SCORE,Model.MaxScore);
        }
    }
}
