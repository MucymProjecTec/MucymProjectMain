using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu;
    public event Action OnItemsMenu;
    public event Action OnArPosition;
    public event Action OnScreenCapture;

    public void CaptureScreen() 
    {
        if (instance != null)
        {
            OnScreenCapture?.Invoke();
            Debug.Log("Screen Capture Activated");
        }
        else
        {
            Debug.LogWarning("GameManager instance is null. Make sure GameManager is properly initialized.");
        }
    }

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        MainMenu();
    }

    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        Debug.Log("Main Menu Activated");
    }

    public void ItemsMenu()
    {
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }

    public void ArPosition()
    {
        OnArPosition?.Invoke();
        Debug.Log("AR Position Activated");
    }

    public void ScreenCapture() 
    {
        OnScreenCapture?.Invoke();
        Debug.Log("Screen Capture Activated");
    }

    public void CloseAPP()
    {
        Application.Quit();
    }

}
