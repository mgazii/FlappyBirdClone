using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitController : AbstractController<DigitModel, DigitView>
{
    // Initializes Digit, sets sprite, local position and digit for later calculations
    public void Init(int digit, Sprite digitSprite,float position)
    {
        Model.DigitSprite = digitSprite;
        Model.Position = position;
        Model.Digit = digit;
        View.SetSprite(Model.DigitSprite);
        View.SetPositionX(Model.Position);
    }

}
