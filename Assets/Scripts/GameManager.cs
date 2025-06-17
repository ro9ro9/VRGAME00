using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GrabMode { Easy, Hard }
    public GrabMode currentMode = GrabMode.Hard;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ToggleGrabMode()
    {
        if (currentMode == GrabMode.Easy)
            currentMode = GrabMode.Hard;
        else
            currentMode = GrabMode.Easy;

        Debug.Log($"모드 변경: {currentMode}");
    }
}
