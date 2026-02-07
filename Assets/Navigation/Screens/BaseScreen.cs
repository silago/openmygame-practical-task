using System;
using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    public event Action Closed = delegate { };

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Close()
    {
        Closed.Invoke();
        Destroy(gameObject);
    }
}
