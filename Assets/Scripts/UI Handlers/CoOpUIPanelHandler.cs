using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class CoOpPlayerUI
{
    public Image chargeBar;
    public Image powerUps;
    public TextMeshProUGUI playerScore;
}


public class CoOpUIPanelHandler : MonoBehaviour
{
    public CoOpPlayerUI player1UI;
    public CoOpPlayerUI player2UI;

    /* private void Start()
     {
         player1Name.text = SceneManager.Player1Name;
         player2Name.text = SceneManager.Player2Name;
     }*/


}
