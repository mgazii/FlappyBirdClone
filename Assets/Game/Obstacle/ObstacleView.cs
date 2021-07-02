using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleView : AbstractView<ObstacleController>
{

    public void MoveTo(Vector3 move)
    {
        transform.position += move;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    // calls for removing gamestates after destroy or deactivate
    public void OnDisable()
    {
        Controller.OnDisable();
    }
    // calls for removing gamestates after destroy or deactivate
    private void OnDestroy()
    {
        Controller.OnDisable();
    }

}
