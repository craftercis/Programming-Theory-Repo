using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> topPlayersTextList = new List<TMP_Text>();
    [SerializeField] private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        DataController.instance.LoadScore();
        SetHighscoresText();
    }

    // ABSTRACTION
    private void SetHighscoresText()
    {
        int rank = 0;

        List<PlayerData> topPlayers = DataController.instance.GetTopPlayers(topPlayersTextList.Count);
        for (int i = 0; i < topPlayers.Count && i < topPlayersTextList.Count; i++)
        {
            rank++;
            topPlayersTextList[i].text = "#" + rank + " " + topPlayers[i].playerName + ": " + topPlayers[i].playerScore + " points";
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerType(GameObject playerType)
    {
        GameManager.instance.playerType = playerType;
        playButton.interactable = true;
    }
}
