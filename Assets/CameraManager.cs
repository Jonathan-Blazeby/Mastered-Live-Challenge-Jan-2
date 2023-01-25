using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private Transform cameraTransform;
    private Transform playerTransform;
    [SerializeField] private float rotateOffset = 15.0f;
    #endregion

    #region Public Fields
    public static CameraManager Instance;
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
        Instance = this;
        playerTransform = GameManager.Instance.GetPlayerTransform();
        cameraTransform.LookAt(playerTransform);
        Quaternion rot = cameraTransform.rotation;
        rot.z = rotateOffset;
        cameraTransform.rotation = rot;
    }

    private void CameraFollow()
    {
        Vector3 pos = cameraTransform.position;
        pos.x = playerTransform.position.x;
        cameraTransform.position = pos;
    }
    #endregion

    #region Public Methods

    #endregion
}
