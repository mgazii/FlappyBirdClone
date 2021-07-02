using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitView : AbstractView<DigitController>
{
    public void SetSprite(Sprite digitSprite)
    {
        GetComponent<SpriteRenderer>().sprite = digitSprite;
    }

    public void SetPositionX(float position)
    {
        transform.position = new Vector3(position, transform.position.y, transform.position.z);
    }
}
