using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIPanelHandler : MonoBehaviour
{
    public GameObject playMenuUI;
    public GameObject playerDetailsUI;

    [SerializeField] private TMP_InputField player1InputName;
    [SerializeField] private TMP_InputField player2InputName;
    [SerializeField] TextMeshProUGUI exceptionText;

    string player1Name, player2Name;

    private string inputExeptions = null;

    int mainMenuSceneIndex = 0,
        coopSceneIndex = 1,
        singlePlayerSceneIndex = 2;

    private void Start()
    {
        exceptionText.enabled = false;
        playerDetailsUI.SetActive(false);
    }

    #region ButtonClicks




    public void OnPlayButtonClick()
    {
        GameManager.Instance.SetGameState(GameMode.SinglePlayer);
        playMenuUI.SetActive(false);
        LoadSinglePlayerScene();
    }

    public void OnPlayCoOpButtonClick()
    {

        playMenuUI.SetActive(false);
        playerDetailsUI.SetActive(true);
    }



    public void OnBackButtonClick()
    {
        playerDetailsUI.SetActive(false);
        playMenuUI.SetActive(true);
    }
    public void OnNextButtonClick()
    {

        inputExeptions = PlayerDetailsExceptions();
        Debug.Log(inputExeptions);

        if (!string.IsNullOrEmpty(inputExeptions))
        {
            exceptionText.enabled = true;
            exceptionText.text = inputExeptions;
        }
        else
        {
            GameManager.Instance.SetGameState(GameMode.Coop);
            playerDetailsUI.SetActive(false);
            GameManager.Instance.uiManager.coOpUIPanelHandler.gameObject.SetActive(true);
            player1Name = player1InputName.text;
            player2Name = player2InputName.text;

            inputExeptions = null;
            exceptionText.enabled = false;
        }

    }

    private string PlayerDetailsExceptions()
    {
        if (string.IsNullOrWhiteSpace(player1InputName.text) ||
            string.IsNullOrWhiteSpace(player2InputName.text))
        {
            return "Please enter both player names";
        }

        if (player1InputName.text.Length > 10 || player2InputName.text.Length > 10)
        {
            return "Player names cannot exceed 10 characters";
        }

        return null;
    }


    #endregion




    #region SceneLoader
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    public void LoadCoOpScene()
    {
        SceneManager.LoadScene(coopSceneIndex);
    }

    public void LoadSinglePlayerScene()
    {
        SceneManager.LoadScene(singlePlayerSceneIndex);
    }


    #endregion



}
