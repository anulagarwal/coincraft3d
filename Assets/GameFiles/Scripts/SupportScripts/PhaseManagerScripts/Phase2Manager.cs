using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Manager : MonoBehaviour
{
    #region Properties
    public static Phase2Manager Instance = null;
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

    private void Start()
    {
        GoldCollected = 0;
        RockCollected = 0;
    }
    #endregion

    #region Getter And Setter
    public int GoldCollected { get; set; }

    public int RockCollected { get; set; }
    #endregion

    #region Public Core Functions
    public void CalculatePurity()
    {
        //Formula
        print(((float)GoldCollected - (float)RockCollected) / (float)GoldCollected);
    }
    #endregion
}
