using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase6Manager : MonoBehaviour
{
    #region Properties
    public static Phase6Manager Instance = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    #endregion
}
