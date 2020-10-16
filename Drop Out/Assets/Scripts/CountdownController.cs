using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    private int Timer = 3;
    public Text TimerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; // game is paused at the start of the game
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while(Timer > 0)
        {
            TimerDisplay.text = Timer.ToString();

            yield return new WaitForSecondsRealtime(1f); // ignores time scaling

            Timer--;
        }

        TimerDisplay.text = "START";

        Time.timeScale = 1; // game starts after countdown timer

        yield return new WaitForSeconds(1f);

        TimerDisplay.gameObject.SetActive(false);
    }
}
