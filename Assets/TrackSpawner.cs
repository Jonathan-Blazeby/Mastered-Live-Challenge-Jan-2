using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private List<GameObject> trackPieces;
    private List<GameObject> currentTrackPieces;
    [SerializeField] private float trackCentrepointX = 30.0f;
    private Transform playerTransform;
    private float nextTrackXValue;
    #endregion

    #region Public Fields
    public static TrackSpawner Instance;
    #endregion

    #region Monobehavior Callbacks
    private void Start()
    {
        Initialise();
    }

    #endregion

    #region Private Methods
    private void Initialise()
    {
        Instance = this;
        currentTrackPieces = new List<GameObject>();
        playerTransform = GameManager.Instance.GetPlayerTransform();
        StartTrack();
    }

    private void StartTrack()
    {
        nextTrackXValue = 0;
        InstantiateTrackPiece();
        nextTrackXValue += trackCentrepointX;
        InstantiateTrackPiece();
        nextTrackXValue += trackCentrepointX;
        InstantiateTrackPiece();
    }

    private void InstantiateTrackPiece()
    {
        GameObject trackPiece = GameObject.Instantiate(trackPieces[Random.Range(0, trackPieces.Count)], new Vector3(nextTrackXValue, 0.0f, 0.0f), Quaternion.identity);
        currentTrackPieces.Add(trackPiece);
    }
    #endregion

    #region Public Methods
    public void ResetTrack()
    {
        foreach(GameObject trackPiece in currentTrackPieces)
        {
            Destroy(trackPiece);
        }
        currentTrackPieces.Clear();

        StartTrack();
    }

    public void TrackPieceLeft(float centrePoint)
    {
        nextTrackXValue = centrePoint + (trackCentrepointX * 3);
        InstantiateTrackPiece();
    }
    #endregion

}
