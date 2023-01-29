using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject failStateScreen;
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

    private void ResetUI()
    {
        failStateScreen.SetActive(false);
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
        CameraManager.Instance.StartCamera();
    }

    private void SetScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void FailState()
    {
        CameraManager.Instance.StopCamera();
        failStateScreen.SetActive(true);
    }
    #endregion

    #region Public Methods
    public void ScoreUp()
    {
        score++;
        SetScore();
    }

    public void ResetGame()
    {
        Debug.Log("Game Reset");
        ResetUI();
        ResetTrack();
        ResetPlayer();
    }

    public void DeathSignal()
    {
        FailState();
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
    #endregion

}
