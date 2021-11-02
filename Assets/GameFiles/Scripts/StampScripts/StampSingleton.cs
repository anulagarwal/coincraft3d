using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampSingleton : MonoBehaviour
{
    #region Properties
    public static StampSingleton Instance = null;

    [Header("Components Reference")]
    [SerializeField] private StampAnimationsHandler stampAnimationsHandler = null;
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
        IsUseAble = true;
        TouchedCoin = false;
    }
    #endregion

    #region Getter And Setter
    public bool IsUseAble { get; set; }

    public StampAnimationsHandler GetStampAnimationsHandler { get => stampAnimationsHandler; }

    public bool TouchedCoin { get; set; }
    #endregion
}
