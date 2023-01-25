using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TMPro.TMP_Text scoreText;
    private Vector3 playerStartPos;
    private int score = 0;
    #endregion

    #region Public Fields
    public static GameManager Instance;
    #endregion

    #region Monobehavior Callbacks
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Initialise();
    }
    #endregion

    #region Private Methods
    private void Initialise()
    {
        playerStartPos = playerTransform.position;
    }
    private void ResetGame()
    {
        Debug.Log("Game Reset");
        ResetScore();
        ResetTrack();
        ResetPlayer();
    }

    private void ResetScore()
    {
        score = 0;
        SetScore();
    }

    private void ResetTrack()
    {
        TrackSpawner.Instance.ResetTrack();
    }

    private void ResetPlayer()
    {
        playerTransform.position = playerStartPos;
        playerTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void SetScore()
    {
        scoreText.text = "Score: " + score;
    }
    #endregion

    #region Public Methods
    public void ScoreUp()
    {
        score++;
        SetScore();
    }

    public void DeathSignal()
    {
        ResetGame();
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
    #endregion


}
