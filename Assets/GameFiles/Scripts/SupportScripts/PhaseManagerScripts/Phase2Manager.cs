using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Manager : MonoBehaviour
{
    #region Properties
    public static Phase2Manager Instance = null;

    [Header("Components Reference")]
    [SerializeField] private GameObject cam1 = null;
    [SerializeField] private GameObject cam2 = null;
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
        GoldCollected = 0;
        RockCollected = 0;
    }
    #endregion

    #region Getter And Setter
    public int GoldCollected { get; set; }

    public int RockCollected { get; set; }
    #endregion

    #region Public Core Functions
    public void CalculatePurity()
    {
        LevelUIManager.Instance.UpdatePurityCheckBar(((float)GoldCollected - (float)RockCollected) / (float)GoldCollected);
        print(((float)GoldCollected - (float)RockCollected) / (float)GoldCollected);

        if(GoldCollected >= PlayerPrefs.GetInt("CollectedGold"))
        {
            SwitchToCam2();
        }
    }

    public void SwitchToCam2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
    #endregion
}
