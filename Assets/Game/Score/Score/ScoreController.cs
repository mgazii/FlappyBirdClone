using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : AbstractController<ScoreModel,ScoreView>
{
    public int Score => Model.Score;

    // subscribes OnScore Action in Player
    public void Init()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerView>().Controller.OnScore += OnScore;
    }

    // increases score and checks if max score passed then increases it
    public void OnScore()
    {
        Model.Score++;
        View.RefreshScore();
        if(PlayerPrefs.GetInt(GameConstants.MAX_SCORE) < Model.Score)
        {
            PlayerPrefs.SetInt(GameConstants.MAX_SCORE, Model.Score);
        }
    }

    // unsubscribes OnScore event
    public void Destroy()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            obj.GetComponent<PlayerView>().Controller.OnScore -= OnScore;
        }
        
        
    }
}
