using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WindowState { Opened, Closed }

public class UIBaseWindow : MonoBehaviour
{
    [SerializeField]
    protected string id;
    public virtual string Id
    {
        get { return id; }
    }

    [SerializeField]
    protected WindowState state;
    public Action<WindowState, WindowState> OnStateChanged;

    public WindowState State
    {
        get { return state; }
        set
        {
            if (state != value)
            {
                var prevState = state;
                state = value;
                OnStateChanged?.Invoke(prevState, state);
            }
        }
    }

    private void Awake()
    {
        gameObject.SetActive(State == WindowState.Opened);
        Init();
    }

    public virtual void Init()
    {

    }

    public virtual void OpenWindow()
    {
        gameObject.SetActive(true);
        State = WindowState.Opened;
    }

    public virtual void CloseWindow()
    {
        gameObject.SetActive(false);
        State = WindowState.Closed;
    }
}
