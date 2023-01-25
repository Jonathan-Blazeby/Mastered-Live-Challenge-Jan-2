using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDetectionScript : MonoBehaviour
{
    #region Monobehavior Callbacks
    private void OnTriggerExit(Collider other)
    {
        TrackSpawner.Instance.TrackPieceLeft(transform.parent.position.x);
    }
    #endregion
}
