using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class timer : MonoBehaviour
{

    public TextMeshPro textholder;
    public float startingTime = 120;
    private float currentTime;
    public bool isRunning = false;

    //public UnityEvent OnTimerFinished;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();  // Initialize timer
        //textholder = GetComponent<TextMeshProUGUI>();
        //  StartCoroutine(TimerTick());
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                // Optional: Trigger event when timer ends
                startingTime -= Time.deltaTime;

                float roundedNumber = Mathf.FloorToInt(startingTime);

                //text.text = startingTime.ToString();


                if (roundedNumber >= 0)
                    textholder.text = roundedNumber.ToString();
                }
            }
        }
    public void StartTimer()
    {
        isRunning = true;
    }

    // Call this to pause the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Call this to reset the timer to startingTime
    public void ResetTimer()
    {
        currentTime = startingTime;
    }

}
    //public void handleTimer(bool value)
    //{
      //  isRunning = value;
    //}

//}
