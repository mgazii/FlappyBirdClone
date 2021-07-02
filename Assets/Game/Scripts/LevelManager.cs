using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelManager() { }

    private static LevelManager manager;

    public static LevelManager Instance => manager;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    // Registers Tap Needs to be moved to GameOver Panel
    private void Start()
    {
        InputManager.Instance.RegisterTap(onTap);
    }

    
    private void onTap(Tap tap)
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.ENDGAME)
        {
            GameManager.Instance.CurrentGameState = GameManager.GameState.PREP;
            SceneManager.LoadScene(GameConstants.SCENE.STARTSCENE.ToString());
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameConstants.SCENE.GAMEPLAYSCENE.ToString());
        GameManager.Instance.CurrentGameState = GameManager.GameState.MIDGAME;
    }

    public void GameOver()
    {   
        GameObject.FindGameObjectWithTag("Finish").GetComponent<SpriteRenderer>().enabled = true;
        GameManager.Instance.CurrentGameState = GameManager.GameState.ENDGAME;
    }


}
