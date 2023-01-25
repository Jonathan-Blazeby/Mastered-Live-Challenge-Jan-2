using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRolling : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private float constantSpeed = 0.75f;
    [SerializeField] private float activeSpeed = 3.0f;
    #endregion

    #region Monobehavior Callbacks
    void Start()
    {

    }

    void FixedUpdate()
    {
        CaptureInput();
    }
    #endregion

    #region Private Methods
    private void CaptureInput()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);
        movement.x += constantSpeed;
        ballRigidbody.AddForce(movement * activeSpeed);
    }
    #endregion

}
