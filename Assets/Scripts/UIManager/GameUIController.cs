using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController instance;

    // ENCAPSULATION
    [SerializeField] private TMP_InputField nameInputField;
    public string playerName => nameInputField.text;

    [SerializeField] private TMP_Text title;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text winScoreText;
    [SerializeField] private TMP_Text currentHighscore;
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject bestScore;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button menuButton;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += EnableGameOverScreen;
        GameManager.OnGameWin += EnableWinScreen;
        GameManager.OnPointsChange += UpdatePoints;

        PlayerDataList playerData = DataController.instance.LoadScore();

        if (playerData.playerDataList.Count != 0)
        {
            bestScore.SetActive(true);
            PlayerData topPlayer = DataController.instance.GetPlayerWithHighestScore();
            currentHighscore.text = "Best Score: " + topPlayer.playerName + ": " + topPlayer.playerScore;
        }
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= EnableGameOverScreen;
        GameManager.OnGameWin -= EnableWinScreen;
        GameManager.OnPointsChange -= UpdatePoints;
    }

    public void EnableGameOverScreen()
    {
        gameoverScreen.SetActive(true);
    }

    public void EnableWinScreen()
    {
        title.text = "WINNER";
        backgroundImage.color = new Color32(17, 106, 0, 242);
        gameoverScreen.SetActive(true);
    }

    public void UpdatePoints()
    {
        scoreText.text = $"Score : {GameManager.instance.points}";
        gameOverScoreText.text = $"Score : {GameManager.instance.points}";
        winScoreText.text = $"Score : {GameManager.instance.points}";
    }

    public void EnableGameOverButtons()
    {

        if (nameInputField.text != "")
        {
            retryButton.interactable = true;
            menuButton.interactable = true;
        }
    }

    public void EnableWinButtons()
    {
        if (nameInputField.text != "")
        {
            retryButton.interactable = true;
            menuButton.interactable = true;
        }
    }

    public void RestartGame()
    {
        DataController.instance.SaveScore();
        SceneController.instance.LoadScene(SceneController.SceneName.Game);
    }

    public void BackToMenu()
    {
        DataController.instance.SaveScore();
        SceneController.instance.LoadScene(SceneController.SceneName.MainMenu);
    }
}
