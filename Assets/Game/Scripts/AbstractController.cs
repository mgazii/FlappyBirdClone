using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// used for Generic extensions, for easy accessing from View to Controller to Model
public class AbstractConroller 
{
    protected AbstractView _view;
    public void SetView(AbstractView view)
    {
        this._view = view;
    }
}

// Connects Controller to Model and View, T is Model
public abstract class AbstractController<T,E> : AbstractConroller where E : AbstractView
{

    private T _model;


    protected E View => (E)_view;

    protected T Model
    {
        get
        {
            if (_model == null)
            {
                _model = (T)Activator.CreateInstance(typeof(T));
            }
            return _model;
        }
    }
}
