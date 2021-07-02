using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// class for obstacle creating
public class ObstacleManager : MonoBehaviour
{
    public float delay = 1;
    public float repeat = 2.3f;

    public float height_l = -1.21f;
    public float height_h = 1.67f;

    // Starts repating process and registers ENGAME state for canceling it
    void Start()
    {
        GameManager.Instance.AddGameStateListener(this);
        InvokeRepeating("CreateObstacle", delay, repeat);
    }

    private void CreateObstacle()
    {
        var height = Random.Range(height_l, height_h);
        ObstaclePoolManager.Instance.RequestObstacle().GetComponent<ObstacleView>().Controller.Init(new Vector3(transform.position.x, height, transform.position.z));
    }

    public void ENDGAME()
    {
        CancelInvoke("CreateObstacle");
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveGameStateListener(this);
    }
}
