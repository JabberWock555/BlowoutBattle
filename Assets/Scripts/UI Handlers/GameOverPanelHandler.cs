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
        CoOpManager.Instance.ResetScores();
        GameManager.Instance.uiManager.ResetPanelsForMainMenu();
        GameManager.Instance.uiManager.mainMenuUIPanelHandler.ResetPlayerData();
        GameManager.Instance.SetGameState(GameMode.MAINMENU);
        this.gameObject.SetActive(false);

    }


    public void OnReplayButtonClick()
    {
        GameManager.Instance.UnpauseGame();
        GameManager.Instance.uiManager.ResetPanelsForGamePlay();
        CoOpManager.Instance.ResetScores();
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.uiManager.coOpUIPanelHandler.Setup();

    }
}
