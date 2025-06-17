using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeElapsed = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        timeElapsed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StopTimer() => isRunning = false;
    public void StartTimer() => isRunning = true;
}
