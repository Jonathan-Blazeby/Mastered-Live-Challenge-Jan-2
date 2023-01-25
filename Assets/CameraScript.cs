using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private Transform playerTransform;
    #endregion

    #region Monobehavior Callbacks
    private void Start()
    {
        Initialise();
    }
    private void Update()
    {
        CameraFollow();
    }
    #endregion

    #region Private Methods
    private void Initialise()
    {
        transform.LookAt(playerTransform);
    }

    private void CameraFollow()
    {
        Vector3 pos = transform.position;
        pos.x = playerTransform.position.x;
        transform.position = pos;
    }
    #endregion

    #region Public Methods

    #endregion
}
