using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : AbstractView<ScoreController>
{
    private void Start()
    {
        Controller.Init();
        RefreshScore();
    }

    // clears all previous sprites, and creates new ones for new score, Object Pooling required for performance
    public void RefreshScore()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        DigitFactory.createDigits(Controller.Score, transform);
    }

    private void OnDestroy()
    {
        Controller.Destroy();
    }
}
