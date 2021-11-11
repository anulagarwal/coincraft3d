using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    #region Properties
    public static LevelUIManager Instance = null;

    [Header("Attributes")]
    [SerializeField] private UIGameplayPhase activePhase = UIGameplayPhase.Phase_1;

    [Header("Gameplay UI Components Reference")]
    [SerializeField] private VariableJoystick movementJS = null;
    [SerializeField] private TextMeshProUGUI goldCountTxt = null;
    [SerializeField] private GameObject phase_1 = null;
    [SerializeField] private GameObject phase_2 = null;
    [SerializeField] private GameObject phase_3 = null;
    [SerializeField] private GameObject phase_4 = null;
    [SerializeField] private GameObject phase_5 = null;

    [Header("Phase 2 Components Reference")]
    [SerializeField] private Image purityCheckBar = null;
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
        SwitchGameplayUIPhase(activePhase);
    }
    #endregion

    #region Getter And Setter
    public VariableJoystick GetMovementJS { get => movementJS; }
    #endregion

    #region Btn Events Functions
    public void OnClick_CoinMarBtn(Texture tex)
    {
        CoinsManager.Instance.ActiveCoinMark = tex;
    }
    #endregion

    #region Private Core Functions
    private void SwitchGameplayUIPhase(UIGameplayPhase phase)
    {
        switch (phase)
        {
            case UIGameplayPhase.Phase_1:
                phase_1.SetActive(true);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                break;
            case UIGameplayPhase.Phase_2:
                phase_1.SetActive(false);
                phase_2.SetActive(true);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                break;
            case UIGameplayPhase.Phase_3:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(true);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                break;
            case UIGameplayPhase.Phase_4:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(true);
                phase_5.SetActive(false);
                break;
            case UIGameplayPhase.Phase_5:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(true);
                break;
        }
    }
    #endregion

    #region Public Core Functions
    public void UpdateGoldCount(int count)
    {
        goldCountTxt.SetText(count.ToString());
    }

    public void UpdatePurityCheckBar(float amount)
    {
        purityCheckBar.fillAmount = amount;
    }
    #endregion
}
