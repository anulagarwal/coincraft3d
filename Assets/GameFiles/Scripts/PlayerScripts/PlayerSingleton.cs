using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    #region Properties
    public static PlayerSingleton Instance = null;

    [Header("Components Reference")]
    [SerializeField] private PlayerMovementHandler playerMovementHandler = null;
    [SerializeField] private PlayerAnimationsHandler playerAnimationsHandler = null;
    [SerializeField] private PlayerRawGoldStorage playerRawGoldStorage = null;
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

    #region Getter And Setter
    public PlayerState PlayerActiveState { get; set; }

    public PlayerMovementHandler GetPlayerMovementHandler { get => playerMovementHandler; }

    public PlayerAnimationsHandler GetPlayerAnimationsHandler { get => playerAnimationsHandler; }
    
    public PlayerRawGoldStorage GetPlayerRawGoldStorage { get => playerRawGoldStorage; }
    #endregion

    #region PlayePrefs Core Functions
    public void SaveCollectedGold(int amount)
    {
        PlayerPrefs.SetInt("CollectedGold", PlayerPrefs.GetInt("CollectedGold") + amount);
    }
    #endregion
}
