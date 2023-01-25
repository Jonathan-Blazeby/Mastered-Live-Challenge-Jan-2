using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    #region Private Fields
    private bool scoreable = true;
    #endregion

    #region Public Fields

    #endregion

    #region Monobehavior Callbacks
    private void OnEnable()
    {
        scoreable = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) { return; }

        Debug.Log("Player Scored");
        Score();
    }
    #endregion

    #region Private Methods
    private void Score()
    {
        if(!scoreable) { return; }
        scoreable = false;
        GameManager.Instance.ScoreUp();
        gameObject.SetActive(false);
    }
    #endregion

    #region Public Methods

    #endregion

}
