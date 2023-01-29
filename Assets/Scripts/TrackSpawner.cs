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

    //Initial 3 sections of track instantiated
    private void StartTrack()
    {
        nextTrackXValue = 0;
        InstantiateTrackPiece();
        nextTrackXValue += trackCentrepointX;
        InstantiateTrackPiece();
        nextTrackXValue += trackCentrepointX;
        InstantiateTrackPiece();
    }

    //Instantiates a track piece chosen randomly from the ones available in the list, at the next x value position
    private void InstantiateTrackPiece()
    {
        GameObject trackPiece = GameObject.Instantiate(trackPieces[Random.Range(0, trackPieces.Count)], new Vector3(nextTrackXValue, 0.0f, 0.0f), Quaternion.identity);
        currentTrackPieces.Add(trackPiece);
        
        TrimTrackBehind();
    }

    //Earliest still-existing track piece (now out of sight) is destroyed
    //Called when new track piece instantiated 
    private void TrimTrackBehind()
    {
        if(currentTrackPieces.Count >= 5)
        {
            Destroy(currentTrackPieces[0]);
            currentTrackPieces.RemoveAt(0);
        }
    }
    #endregion

    #region Public Methods
    //Destroys all instances of track pieces upon game restart UI button pressed
    public void ResetTrack()
    {
        foreach(GameObject trackPiece in currentTrackPieces)
        {
            Destroy(trackPiece);
        }
        currentTrackPieces.Clear();

        StartTrack();
    }

    //Called by a track piece's TrackDetectionScript when the player has left the collider
    //Bumps up the spawn x value and instantiates the newest track piece - 3 ahead of the one just left
    public void TrackPieceLeft(float centrePoint)
    {
        nextTrackXValue = centrePoint + (trackCentrepointX * 3);
        InstantiateTrackPiece();
    }
    #endregion

}
