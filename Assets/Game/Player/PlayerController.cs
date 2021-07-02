using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : AbstractController<PlayerModel,PlayerView>
{
    // Action for notify ScoreController for increasing score
    public Action OnScore;

    public void Init()
    {
        GameManager.Instance.AddGameStateListener(this);
        InputManager.Instance.RegisterTap(OnTap);
    }
    // RUNS ON MIDGAME rotates bird according to y value, clamps it down
    public void MIDGAME()
    {
        float v = View.transform.GetComponent<Rigidbody2D>().velocity.y;
        float rotate = Mathf.Min(Mathf.Max(-90, v * Model._rotateRate + 60), 30);
        View.Rotate(Quaternion.Euler(0f, 0f, rotate));
    }

    // clear states on ENDGAME, cancels jump
    public void ENDGAME()
    {
        GameManager.Instance.RemoveGameStateListener(this);
        InputManager.Instance.UnRegisterTap(OnTap);
    }
    
    public void OnTap(Tap tap)
    {
        View.Jump(new Vector2(0, Model._upSpeed));
    }
    // runs on collision, only score collider has isTrigger enabled
    internal void OnTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(GameConstants.OBSTACLE))
        {
            OnScore.Invoke();
        }
    }
    // runs on death
    public void OnCollision(Collision2D collision)
    {
        if(collision.collider)
        {
            if(collision.collider.gameObject.tag.Equals(GameConstants.OBSTACLE))
            {
                LevelManager.Instance.GameOver();
            }
        }
    }
    // cancels subscription
    public void Destroy()
    {
        GameManager.Instance.RemoveGameStateListener(this);
        InputManager.Instance.UnRegisterTap(OnTap);
    }
}
