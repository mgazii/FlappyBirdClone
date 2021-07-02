using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : AbstractView<StartController>
{
    private void Start()
    {
        Controller.Init();
    }

    private void OnDestroy()
    {
        Controller.Destroy();
    }

}
