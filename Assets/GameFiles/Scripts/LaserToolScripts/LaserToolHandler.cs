using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserToolHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float rotSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private GameObject coinDent = null;
    [SerializeField] private GameObject cutTrail = null;
    #endregion

    #region MonoBehviour Functions
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            cutTrail.SetActive(false);
            coinDent.SetActive(false);
        }
    }
    #endregion
}
