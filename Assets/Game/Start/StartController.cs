using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : AbstractController<StartModel,StartView>
{
    public void Init()
    {
        InputManager.Instance.RegisterTap(OnTap);
    }

    public void OnTap(Tap tap)
    {
        if(tap.TappedObject != null && tap.TappedObject.name.Equals(GameConstants.START_BUTTON))
        {
            LevelManager.Instance.StartGame();
        }
    }

    public void Destroy()
    {
        InputManager.Instance.UnRegisterTap(OnTap);
    }
}
