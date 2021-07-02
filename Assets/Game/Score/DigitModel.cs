using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitModel
{
    
    private int digit;
    private Sprite digitSprite;
    // local position of View
    public float pos;

    public int Digit
    {
        get => digit;
        set => digit = value;
    }

    public Sprite DigitSprite
    {
        get => digitSprite;
        set => digitSprite = value;
    }

    public float Position
    {
        get => pos;
        set => pos = value;
    }
}
