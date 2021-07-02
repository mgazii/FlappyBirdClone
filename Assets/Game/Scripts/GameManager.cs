using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
// Class for managing states
public class GameManager : MonoBehaviour
{
    private GameManager(){}

    private static GameManager manager;

    public static GameManager Instance => manager;

    private static Camera cam;

    public static Camera Camera => cam;

    private void Awake()
    {
        if(manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
            foreach (GameState gameState in Enum.GetValues(typeof(GameState)))
            {
                events.Add(gameState, new UnityEvent());
            }
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
        cam = Camera.main;
    }

    // For adding another state just add here
    public enum GameState
    {
        PREP,MIDGAME,ENDGAME
    }

    // UnityEvents for GameStates, automatically filled
    private Dictionary<GameState,UnityEvent> events = new Dictionary<GameState, UnityEvent>();

    // Register class for state listening, After registration create function with GameSate's name Ex: void PREP()
    public void AddGameStateListener(System.Object obj)
    {
        foreach(MethodInfo inf in obj.GetType().GetMethods())
        {
            foreach (GameState gameState in Enum.GetValues(typeof(GameState)))
            {
                if (inf.Name.Equals(gameState.ToString()))
                {
                    events[gameState].AddListener((UnityAction)Delegate.CreateDelegate(typeof(UnityAction), obj, inf.Name));
                }
            }
        }
    }

    public void RemoveGameStateListener(System.Object obj)
    {
        foreach (MethodInfo inf in obj.GetType().GetMethods())
        {
            foreach (GameState gameState in Enum.GetValues(typeof(GameState)))
            {
                if (inf.Name.Equals(gameState.ToString()))
                {
                    events[gameState].RemoveListener((UnityAction)Delegate.CreateDelegate(typeof(UnityAction), obj, inf.Name));
                }
            }
        }
    }

    private GameState currentGameState = GameState.PREP;

    public GameState CurrentGameState
    {
        get => currentGameState;
        set => currentGameState = value;
    }
    // Moves to next state, if its name contains BT_ runs it only once then moves to next one
    // used for running code only once between states Ex: BT_PREPMID runs after prep finish before MID starts only once if function used
    public void SetNextGameState()
    {
        Array states = Enum.GetValues(typeof(GameState));
        if (states.GetValue(states.Length - 1).Equals(CurrentGameState))
        {
            return;
        }
        bool found = false;
        foreach (GameState gameState in states)
        {
            if (found)
            {
                CurrentGameState = gameState;
                if (gameState.ToString().Contains("BT_"))
                {
                    Debug.Log(CurrentGameState);
                    events[CurrentGameState].Invoke();
                    SetNextGameState();
                }
                break;
            }

            if (gameState == CurrentGameState)
            {
                found = true;
            }

        }
    }

    // invokes registered state events, cam is not important could be removed code refactoring required
    private void Update()
    {
        cam = Camera.main;
        events[currentGameState].Invoke();
    }


}
