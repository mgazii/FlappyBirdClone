using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Connects View to Controller via Generic Extension
public class AbstractView : MonoBehaviour
{

}
public abstract class AbstractView<T> : AbstractView where T : AbstractConroller
{
    private T _controller;

    public T Controller
    {
        get
        {
            if (_controller == null)
            {
                _controller = (T)Activator.CreateInstance(typeof(T));
                _controller.SetView(this);
            }
            
            return _controller;
        }
    }
}
