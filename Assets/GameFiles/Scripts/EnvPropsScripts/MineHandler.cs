using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private int mineCapacity = 0;

    [Header("Components Reference")]
    [SerializeField] private Image healthBarFG = null;
    [SerializeField] private Transform mineHolderTransform = null;

    private int mineHealth = 0;
    private int mineCapacityTemp = 0;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        mineHealth = mineCapacity;
        mineCapacityTemp = mineCapacity;
    }
    #endregion

    #region Getter And Setter
    #endregion

    #region Public Core Functions
    public void UpdateMineHealth()
    {
        if (mineHealth > 0)
        {
            mineHealth = mineCapacityTemp - PlayerSingleton.Instance.GetPlayerRawGoldStorage.GetGoldAmount;
        }
        else
        {
            Destroy(mineHolderTransform.gameObject); 
            PlayerSingleton.Instance.GetPlayerRawGoldStorage.EnableMiningMech(false);
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerState.Idle);
        }

        healthBarFG.fillAmount = ((float)mineHealth / (float)mineCapacity);
    }

    public void DoneMining()
    {
        mineCapacityTemp = mineHealth;
    }
    #endregion
}
