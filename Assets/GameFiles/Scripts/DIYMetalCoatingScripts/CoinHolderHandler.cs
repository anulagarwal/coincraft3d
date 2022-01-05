using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinHolderHandler : MonoBehaviour
{
    #region Properties
    public static CoinHolderHandler Instance = null;

    [Header("Attributes")]
    [SerializeField] private float relocationSpeed = 0f;
    [SerializeField] private int bronzeRequirement = 0;
    [SerializeField] private int goldRequirement;
    [SerializeField] private int silverRequirement;

    private int bronzeCollected;
    private int goldCollected;
    private int silverCollected;



    [Header("Components Reference")]
    [SerializeField] private Animator coinHolderAnimator = null;
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private Transform bucketTransform = null;
    [SerializeField] private List<Transform> coins = new List<Transform>();
    [SerializeField] private CoinLocTriggerEventsHandler coinLocTriggerEventsHandler = null;
    [SerializeField] private TextMeshPro count;

    private int activeCoinIndex = 0;
    private int activePointIndex = 0;
    #endregion

    #region Delegates
    public delegate void Relocate();

    public Relocate relocate = null;
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

    private void Update()
    {
        if (relocate != null)
        {
            relocate();
        }
    }
    #endregion

    #region Getter And Setter
    #endregion

    #region Private Core Functions
    private void RelocationCore()
    {
        if (Vector3.Distance(transform.position,points[activePointIndex].position) >= 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[activePointIndex].position, Time.deltaTime * relocationSpeed);
        }
        else
        {
            EnableRelocation(Relocation.None, false);
        }
    }

    private void RelocationToBucket()
    {
        if (Vector3.Distance(transform.position, bucketTransform.position) >= 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, bucketTransform.position, Time.deltaTime * relocationSpeed);
        }
        else
        {
            EnableRelocation(Relocation.Bucket, false);
        }
    }
    #endregion

    #region Public Core Functions
    public void EnableRelocation(Relocation r, bool value)
    {
        switch (r)
        {
            case Relocation.Left:
                if (activePointIndex > 0)
                {
                    activePointIndex--;
                }
                if (value)
                {
                    relocate += RelocationCore;
                }
                else
                {
                    relocate -= RelocationCore;
                }
                break;
            case Relocation.Right:
                if (activePointIndex < points.Count - 1)
                {
                    activePointIndex++;
                }
                if (value)
                {
                    relocate += RelocationCore;
                }
                else
                {
                    relocate -= RelocationCore;
                }
                break;
            case Relocation.Bucket:
                relocate = null;
                if (value)
                {
                    relocate += RelocationToBucket;
                }
                else
                {
                    switch (activePointIndex)
                    {
                        case 0:
                            goldCollected++;
                            LevelUIManager.Instance.UpdateGoldRemainingText(goldRequirement - goldCollected);
                            if (goldCollected == goldRequirement)
                            {
                                LevelUIManager.Instance.DisableGoldText();
                            }
                            break;

                        case 1:
                            bronzeCollected++;
                            LevelUIManager.Instance.UpdateBronzeRemainingText(bronzeRequirement - bronzeCollected);
                            if (bronzeCollected == bronzeRequirement)
                            {
                                LevelUIManager.Instance.DisableBronzeText();
                            }
                            break;

                        case 2:
                            silverCollected++;
                            break;
                         
                    }
                 
                    coins[activeCoinIndex].gameObject.AddComponent<Rigidbody>();
                    coins[activeCoinIndex].transform.parent = null;
                    activeCoinIndex++;
                    count.text = (coins.Count - activeCoinIndex) + "";

                    if(coins.Count - activeCoinIndex == 0)
                    {
                        print("aa");
                        if(goldCollected == goldRequirement && bronzeCollected == bronzeRequirement) {

                            //Win
                            LevelUIManager.Instance.DisplayVictoryUI();

                        }
                        else
                        {
                            LevelUIManager.Instance.DisplayFailUI();
                        }
                    }
                    if (activeCoinIndex < coins.Count)
                    {
                        coins[activeCoinIndex].gameObject.SetActive(true);
                        coinLocTriggerEventsHandler.meshRenderer = coins[activeCoinIndex].GetComponent<MeshRenderer>();
                    }
                    relocate -= RelocationToBucket;
                }
                break;
        }
    }

    public void Dip()
    {
        coinHolderAnimator.SetBool("b_Dip", true);
    }
    #endregion

    #region Anim Events Functions
    private void AnimEvent_EndDip()
    {
        coinHolderAnimator.SetBool("b_Dip", false);
    }
    #endregion
}
