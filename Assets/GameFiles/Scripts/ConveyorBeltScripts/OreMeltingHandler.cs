using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMeltingHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float shrinkSpeed = 0f;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        }
        else
        {
            this.enabled = false;
        }
    }
    #endregion
}
