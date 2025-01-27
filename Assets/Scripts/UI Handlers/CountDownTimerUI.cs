using System.Collections;
using TMPro;
using UnityEngine;

public class CountDownTimerUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI countDownText;


    public void StartCountDown()
    {
        StartCoroutine(StartCountDownCoroutine());
    }


    public IEnumerator StartCountDownCoroutine()
    {

        countDownText.text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
