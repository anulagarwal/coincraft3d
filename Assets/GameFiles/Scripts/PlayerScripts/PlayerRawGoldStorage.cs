using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRawGoldStorage : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float miningSpeed = 0f;
    [SerializeField] private float storageSizeIncSpeed = 0f;
    [SerializeField] private float storageMaxScaleSize = 0f;
    [SerializeField] private int storageCapacity = 0;

    [Header("Components Reference")]
    [SerializeField] private Transform goldStorageTransform = null;

    private float goldAmount = 0;
    private int goldUnpackedAmount = 0;
    private Vector3 defaultGoldStorageTransformScale = Vector3.zero;
    #endregion

    #region Delegates
    public delegate void MiningMechanism();

    public MiningMechanism miningMechanism = null;
    #endregion

    #region Monoehaviour Functions
    private void Start()
    {
        defaultGoldStorageTransformScale = goldStorageTransform.localScale;
        miningMechanism = null;
    }

    private void Update()
    {
        if (miningMechanism != null)
        {
            miningMechanism();

            LevelUIManager.Instance.UpdateGoldCount((int)goldAmount);
        }
    }
    #endregion

    #region Getter And Setter
    public int GetGoldAmount { get => (int)goldAmount; }
    #endregion

    #region Private Core Functions
    private void MiningMech()
    {
        goldAmount += (Time.deltaTime * miningSpeed);

        StorageSizeIncMech();

        if ((int)goldAmount > storageCapacity)
        {
            goldAmount = storageCapacity;
            EnableMiningMech(false);
        }
    }

    private void StorageSizeIncMech()
    {
        if (goldStorageTransform.localScale.x < storageMaxScaleSize)
        {
            goldStorageTransform.localScale += Vector3.one * Time.deltaTime * storageSizeIncSpeed; 
        }
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

    public int UnpackCollectedGold()
    {
        goldStorageTransform.localScale = defaultGoldStorageTransformScale;
        goldUnpackedAmount = (int)goldAmount;
        PlayerSingleton.Instance.SaveCollectedGold((int)goldAmount);
        goldAmount = 0;
        LevelUIManager.Instance.UpdateGoldCount((int)goldAmount);
        return goldUnpackedAmount;
    }
    #endregion
}
