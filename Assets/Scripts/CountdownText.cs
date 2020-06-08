using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // For text

// Required Text
[RequireComponent(typeof(Text))]
public class CountdownText : MonoBehaviour
{
    // Create events for other scripts to be used
    public delegate void CountdownFinished();
    public static event CountdownFinished OnCountdownFinished;

    Text countdown;

    void OnEnable()
    {
        countdown = GetComponent<Text>();
        countdown.text = "3";
        
        // When working with IEnumerator
        StartCoroutine("Countdown");
    }

    // Count Down
    IEnumerator Countdown()
    {
        int count = 3;
        for(int i = 0; i < count; i++){
            countdown.text = (count - i).ToString();

            // Delay by 1 second
            yield return new WaitForSeconds(1);
        }

        OnCountdownFinished();
    }
}
