using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCraftingHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private Vector3 rotDirection = Vector3.zero;

    [Header("Components Reference")]
    [SerializeField] private Transform bucket = null;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bucket.Rotate(rotDirection * Time.deltaTime * rotSpeed);
        }
    }
    #endregion
}
