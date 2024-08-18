using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Click : MonoBehaviour
{
    private List<ClickObserver> observers = new List<ClickObserver>();
    BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.offset = new Vector2(0, 0);
        collider.size = new Vector2(Screen.width, Screen.height);
        collider.isTrigger = true;
    }

    public void register(ClickObserver observer)
    {
        observers.Add(observer);
    }

    public void OnMouseDown()
    {
        foreach (ClickObserver observer in observers)
        {
            observer.onClick();
        }
    }

}