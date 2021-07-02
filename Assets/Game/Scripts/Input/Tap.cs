using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap
{
    public enum TapType
    {
        TAP, DOUBLE_TAP
    }

    private TapType type;
    private GameObject tappedObject;

    public TapType Type
    {
        get => type;
        set => type = value;
    }

    public GameObject TappedObject => tappedObject;

    private Tap() { }
    public Tap(TapType type)
    {
        this.type = type;
    }

    public Tap(TapType type,GameObject tappedObject)
    {
        this.type = type;
        this.tappedObject = tappedObject;
    }

}
