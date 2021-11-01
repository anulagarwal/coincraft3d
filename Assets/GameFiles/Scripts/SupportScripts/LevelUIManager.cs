using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUIManager : MonoBehaviour
{
    #region Properties
    public static LevelUIManager Instance = null;

    [Header("Gameplay UI Components Reference")]
    [SerializeField] private VariableJoystick movementJS = null;
    [SerializeField] private TextMeshProUGUI goldCountTxt = null;
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
    public VariableJoystick GetMovementJS { get => movementJS; }
    #endregion

    #region Public Core Functions
    public void UpdateGoldCount(int count)
    {
        goldCountTxt.SetText(count.ToString());
    }
    #endregion
}
