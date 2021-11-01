using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRawGoldStorage : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float miningSpeed = 0f;

    private float goldAmount = 0;
    #endregion

    #region Delegates
    public delegate void MiningMechanism();

    public MiningMechanism miningMechanism = null;
    #endregion

    #region Monoehaviour Functions
    private void Start()
    {
        miningMechanism = null;
    }

    private void Update()
    {
        if (miningMechanism != null)
        {
            miningMechanism();

            print((int)goldAmount);
        }
    }
    #endregion

    #region Private Core Functions
    private void MiningMech()
    {
        goldAmount += (Time.deltaTime * miningSpeed);
    }
    #endregion

    #region Public Core Functions
    public void EnableMiningMech(bool value)
    {
        if (value)
        {
            miningMechanism += MiningMech;
        }
        else
        {
            miningMechanism = null;
        }
    }
    #endregion
}
