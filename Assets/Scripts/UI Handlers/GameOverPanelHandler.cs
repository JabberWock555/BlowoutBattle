using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;


    public void SetPlayerNameByID(string name)
    {

        playerName.text = name + " wins!";
    }

    public void OnMainMenuButtonClick()
    {
        GameManager.Instance.UnpauseGame();
        GameManager.Instance.SetGameState(GameMode.MAINMENU);
        CoOpManager.Instance.ResetScores();
        GameManager.Instance.uiManager.mainMenuUIPanelHandler.ResetPlayerData();
        this.gameObject.SetActive(false);

    }


    public void OnReplayButtonClick()
    {
        GameManager.Instance.UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CoOpManager.Instance.ResetScores();
        this.gameObject.SetActive(false);
    }
}
