using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public delegate void GameWin();
    public static event GameWin OnGameWin;

    public delegate void PointsChange();
    public static event PointsChange OnPointsChange;

    public Rigidbody Ball;
    public GameObject playerType;
    public List<Brick> bricks = new List<Brick>();

    private bool m_Started = false;
    private bool hasWon = false;

    // ENCAPSULATION
    private bool _isGameScene = false;
    public bool isGameScene => _isGameScene;

    // ENCAPSULATION
    private int _dammageValue = 1;
    public int dammageValue => _dammageValue;

    // ENCAPSULATION
    private int _Points;
    public int points => _Points;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // here you can use scene.buildIndex or scene.name to check which scene was loaded
        if (scene.name == "Game")
        {
            _Points = 0;
            bricks = new List<Brick>();
            _isGameScene = true;
            GameObject player = Instantiate(playerType);
            Ball = player.GetComponentInChildren<Rigidbody>();
        }
        else
        {
            _isGameScene = false;
        }

        foreach (Brick brick in GameObject.FindObjectsOfType<Brick>())
        {
            bricks.Add(brick);
        }
    }

    private void Update()
    {
        if (_isGameScene)
        {
            FireBall();
            OnWin();
        }
    }

    // ABSTRACTION
    private void FireBall()
    {
        if (m_Started) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        m_Started = true;
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();

        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * 4, ForceMode.VelocityChange);
    }

    public void AddPoint(int points)
    {
        _Points += points;
        OnPointsChange();
    }

    public void StopGame()
    {
        m_Started = false;
        OnGameOver();
    }

    // ABSTRACTION
    public void OnWin()
    {
        if (bricks.Count == 0 && !hasWon)
        {
            hasWon = true;
            Destroy(Ball.gameObject);
            OnGameWin();
        }
    }
}
