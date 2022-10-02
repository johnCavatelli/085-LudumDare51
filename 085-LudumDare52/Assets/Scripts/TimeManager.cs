using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManager : MonoBehaviour
{
    float timeOfOneSecond = 1;
    public TextMeshProUGUI timerText;
    void Start()
    {
        StartCoroutine("SecondTimer");
    }

    void BullyTakeMoneyEvent()
    {
        if (FlagManager.current.TakeMoney(1))
        {
            LooseCondition();
        }        
        StartCoroutine("SecondTimer");
    }

    IEnumerator SecondTimer()
    {
        timerText.text = "10";
        for (int i = 0; i < 10; i++)
        {           
            yield return new WaitForSeconds(timeOfOneSecond);
            int ti = 9 - i;
            timerText.text = ti.ToString();
        }
        BullyTakeMoneyEvent();
    }

    void LooseCondition()
    {
        SceneManager.LoadScene(4);
    }
}
