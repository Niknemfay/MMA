using System;
using UnityEngine;
using TMPro;

public class DailyCountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
            return;
        }

        InvokeRepeating(nameof(UpdateTimer), 0f, 1f);
    }

    private void UpdateTimer()
    {
        DateTime now = DateTime.UtcNow;
        DateTime midnight = DateTime.Today.AddDays(1); 

        TimeSpan remainingTime = midnight - now;

        if (remainingTime.TotalSeconds <= 0)
        {
            timerText.text = "00:00:00";
        }
        else
        {
            timerText.text = FormatTime(remainingTime);
        }
    }

    private string FormatTime(TimeSpan time)
    {
        return time.ToString(@"hh\:mm\:ss");
    }
}
