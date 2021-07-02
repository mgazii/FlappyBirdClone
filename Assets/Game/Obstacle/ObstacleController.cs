using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Obstacle prefab controller class for moving obstacle
public class ObstacleController : AbstractController<ObstacleModel,ObstacleView>
{

    // registers MIDGAME state and changes views height with random height
    public void Init(Vector3 position)
    {
        GameManager.Instance.AddGameStateListener(this);
        View.SetPosition(position);
    }

    // moves obstacles position in MIDGAME, clears state listening after destroyed
    public void MIDGAME()
    {
        if(View != null)
        {
            Model.Movement = Vector3.left * Time.deltaTime * 0.7f;
            View.MoveTo(Model.Movement);
            if (View.transform.localPosition.x <= -4)
            {
                OnDisable();
            }
        }
        else
        {
            GameManager.Instance.RemoveGameStateListener(this);
        }
        
    }

    // for clearing listening after disable
    public void OnDisable()
    {
        if (View.isActiveAndEnabled)
        {
            GameManager.Instance.RemoveGameStateListener(this);
            View.Disable();
        }
    }

    
}
