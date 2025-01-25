using System.Collections;
using TMPro;
using UnityEngine;

public class SinglePlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject CountDownPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject GameWinPanel;
    [SerializeField] private TextMeshProUGUI countDownText;



    public IEnumerator StartCountDown()
    {
        CountDownPanel.SetActive(true);
        countDownText.text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        CountDownPanel.SetActive(false);
    }
}
