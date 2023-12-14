using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time : MonoBehaviour
{
    static int HourInt = 0;
    static int DayInt = 1;
    static int MinInt = 0;
    public TextMeshProUGUI Hour;
    public TextMeshProUGUI Min;
    public TextMeshProUGUI Day;

    void Start()
    {
        InvokeRepeating("TimeUp", 1.0f, 1.0f);
    }

    void TimeUp()
    {
        if (MinInt < 60)
        {
            MinInt += 1;
        }
        else if (MinInt >= 60)
        {
            MinInt = 0;
            HourInt += 1;
        }

        if (HourInt >= 24)
        {
            DayInt += 1;
            HourInt = 0;
        }

        Hour.text = HourInt.ToString("D2");
        Day.text = DayInt.ToString("D4");
        Min.text = MinInt.ToString("D2");
    }
    
}
