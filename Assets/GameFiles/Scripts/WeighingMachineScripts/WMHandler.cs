using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WMHandler : MonoBehaviour
{
    #region Properties
    public static WMHandler Instance = null;

    [Header("Components Reference")]
    [SerializeField] private TextMeshPro wmScreenTxt = null;

    private int wmValue = 0;
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
    public void UpdateWMScreen(int amount)
    {
        wmValue += amount;
        if (wmValue < 0)
        {
            wmValue = 0;
        }

        wmScreenTxt.SetText(wmValue.ToString());
    }
    #endregion
}
