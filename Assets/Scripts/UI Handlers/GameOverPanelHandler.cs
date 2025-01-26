using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;


    public void SetPlayerName(int playerID)
    {

        playerName.text = "Player " + playerID + "wins";
    }

    public void OnMainMenuButtonClick()
    {
        GameManager.Instance.SetGameState(GameMode.MAINMENU);
    }


    public void OnReplayButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
