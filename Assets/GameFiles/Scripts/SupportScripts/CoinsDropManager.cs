using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsDropManager : MonoBehaviour
{
    #region Properties
    public static CoinsDropManager Instance = null;

    [Header("Components Reference")]
    [SerializeField] private GameObject coinPrefab = null;
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

    #region Public Core Functions
    public void DropCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        WMHandler.Instance.UpdateWMScreen(10);
    }
    #endregion
}
