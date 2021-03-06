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
    [SerializeField] private GameObject phase_6 = null;

    [Header("UI Panels")]
    [SerializeField] private GameObject victoryUI = null;
    [SerializeField] private GameObject failUI = null;

    [Header("Phase 2 Components Reference")]
    [SerializeField] private Image purityCheckBar = null;
    [SerializeField] private Image temperaturePB = null;
    [SerializeField] private GameObject purityPBObj = null;
    [SerializeField] private GameObject meltingMechUI = null;
    [SerializeField] private GameObject freezeBtn = null;
    [SerializeField] private GameObject freezeText = null;

    [Header("Phase 6 Com")]
    [SerializeField] private Text bronzeText;
    [SerializeField] private Text goldText;
    [SerializeField] private GameObject goldCheck;
    [SerializeField] private GameObject bronzeCheck;
    [SerializeField] private GameObject goldCross;
    [SerializeField] private GameObject bronzeCross;
    [SerializeField] private GameObject DIYBox;
    [SerializeField] private GameObject WellDone;







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
    private void Update()
    {
        if (activePhase == UIGameplayPhase.Phase_6)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnClick_MoveCoinHolderRightBtn();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnClick_MoveCoinHolderLeftBtn();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                OnClick_Dip();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClick_RelocateCoinToBucket();
            }
        }
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

    public void OnClick_CoinDentTypeBtn(int type)
    {
        LaserToolAutomaticManager.Instance.EnableLaserMech(type);
    }

    public void OnClick_Dip()
    {
        CoinHolderHandler.Instance.Dip();
    }

    public void OnClick_FreezeCoin()
    {
        CoinCraftingHandler.Instance.FreezeCoins();
    }

    public void OnClick_MoveCoinHolderLeftBtn()
    {
        CoinHolderHandler.Instance.EnableRelocation(Relocation.Left, true);
    }

    public void OnClick_MoveCoinHolderRightBtn()
    {
        CoinHolderHandler.Instance.EnableRelocation(Relocation.Right, true);
    }

    public void OnClick_RelocateCoinToBucket()
    {
        CoinHolderHandler.Instance.EnableRelocation(Relocation.Bucket, true);
    }

    public void OnClick_HackBtn(int i)
    {
        if (i == 0)
        {
            DisplayFailUI();
        }
        else
        {
            DisplayVictoryUI();
        }
    }

    public void UpdateBronzeText(string s)
    {
        bronzeText.text = s;
    }

    public void UpdateGoldText(string s)
    {
        goldText.text = s;
    }

    public void EnableGoldCheck()
    {
        goldCheck.SetActive(true);
    }
    public void DisableDIYBox()
    {
        DIYBox.SetActive(false);
        WellDone.SetActive(true);
    }
    public void EnableBronzeCheck()
    {
        bronzeCheck.SetActive(true);
    }
    public void EnableGoldCross()
    {
        goldCross.SetActive(true);
    }

    public void EnableBronzeCross()
    {
        bronzeCross.SetActive(true);
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
                phase_6.SetActive(false);
                break;
            case UIGameplayPhase.Phase_2:
                phase_1.SetActive(false);
                phase_2.SetActive(true);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                phase_6.SetActive(false);
                break;
            case UIGameplayPhase.Phase_3:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(true);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                phase_6.SetActive(false);
                break;
            case UIGameplayPhase.Phase_4:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(true);
                phase_5.SetActive(false);
                phase_6.SetActive(false);
                break;
            case UIGameplayPhase.Phase_5:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(true);
                phase_6.SetActive(false);
                break;
            case UIGameplayPhase.Phase_6:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                phase_6.SetActive(true);
                break;
            case UIGameplayPhase.None:
                phase_1.SetActive(false);
                phase_2.SetActive(false);
                phase_3.SetActive(false);
                phase_4.SetActive(false);
                phase_5.SetActive(false);
                phase_6.SetActive(false);
                break;
        }
    }
    #endregion

    #region Public Core Functions
    public void UpdateGoldCount(int count)
    {
        goldCountTxt.SetText(count.ToString());
    }

    public void DisplayFailUI()
    {
        failUI.SetActive(true);
    }

    public void DisplayVictoryUI()
    {
        victoryUI.SetActive(true);
    }

    public void UpdatePurityCheckBar(float amount)
    {
        purityCheckBar.fillAmount = amount;
    }

    public void TemperatureIncrementPB(float amount)
    {
        if (temperaturePB.fillAmount + amount >= 1)
        {
            temperaturePB.fillAmount = 1;
        }
        else
        {
            temperaturePB.fillAmount = temperaturePB.fillAmount + amount;
        }
    }

    public void TemperatureDecrementPB(float amount)
    {
        if (temperaturePB.fillAmount - amount <= 0)
        {
            temperaturePB.fillAmount = 0;
        }
        else
        {
            temperaturePB.fillAmount = temperaturePB.fillAmount - amount;
        }
    }

    public void EnableMeltingMechUI(bool value)
    {
        meltingMechUI.SetActive(value);
        purityPBObj.SetActive(!value);
    }

    public void DisableMeltingMechPB()
    {
        meltingMechUI.SetActive(false);
        purityPBObj.SetActive(false);
        freezeBtn.SetActive(true);
        freezeText.SetActive(true);
    }
    #endregion
}
