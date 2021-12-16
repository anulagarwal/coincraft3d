using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHolderHandler : MonoBehaviour
{
    #region Properties
    public static CoinHolderHandler Instance = null;

    [Header("Attributes")]
    [SerializeField] private float relocationSpeed = 0f;
    [SerializeField] private MetalLiquidType lastColor;
    [SerializeField] private int bronzeNeeded=2;
    [SerializeField] private int goldNeeded=2;
    [SerializeField] private int silverNeeded=0;

    [SerializeField] private int bronzeCollected=0;
    [SerializeField] private int silverCollected=0;
    [SerializeField] private int goldCollected=0;

    [SerializeField] private int coinsDone = 0;






    [Header("Components Reference")]
    [SerializeField] private Animator coinHolderAnimator = null;
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private Transform bucketTransform = null;
    [SerializeField] private List<Transform> coins = new List<Transform>();
    [SerializeField] private CoinLocTriggerEventsHandler coinLocTriggerEventsHandler = null;

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
        lastColor = MetalLiquidType.Gold;
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
            coinsDone++;
            switch (lastColor)
            {
                case MetalLiquidType.Gold:
                    goldCollected++;
                    if (goldCollected >= goldNeeded)
                    {
                        LevelUIManager.Instance.EnableGoldCheck();
                        LevelUIManager.Instance.UpdateGoldText("");

                    }
                    else
                    {
                        if (coinsDone >= coins.Count)
                        {
                            LevelUIManager.Instance.EnableGoldCross();

                        }
                        else
                        {
                            LevelUIManager.Instance.UpdateGoldText("x" + Mathf.Max(0, goldNeeded - goldCollected));

                        }
                    }
                    break;

                case MetalLiquidType.Copper:
                    bronzeCollected++;
                    if (bronzeCollected >= bronzeNeeded)
                    {
                        LevelUIManager.Instance.UpdateBronzeText("");
                        LevelUIManager.Instance.EnableBronzeCheck();
                    }
                    else
                    { 
                        if (coinsDone >= coins.Count)
                        {
                            LevelUIManager.Instance.EnableBronzeCross();

                        }
                        else
                        {
                            LevelUIManager.Instance.UpdateBronzeText("x" + Mathf.Max(0, bronzeNeeded - bronzeCollected));

                        }

                    }
                    break;

                case MetalLiquidType.Silver:
                    silverCollected++;
                    if (silverCollected >= silverNeeded)
                    {
                        LevelUIManager.Instance.EnableBronzeCheck();
                        LevelUIManager.Instance.UpdateBronzeText("");

                    }
                    else
                    {
                    
                        if (coinsDone >= coins.Count)
                        {

                            LevelUIManager.Instance.EnableBronzeCross();
                        }
                        {
                            LevelUIManager.Instance.UpdateBronzeText("x" + Mathf.Max(0, bronzeNeeded - bronzeCollected));
                        }
                    }
                    break;

            }
            if(silverCollected==silverNeeded && goldCollected == goldNeeded && bronzeCollected== bronzeNeeded)
            {
                LevelUIManager
                    .Instance.DisableDIYBox();
            }
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
                    coins[activeCoinIndex].gameObject.AddComponent<Rigidbody>();
                    coins[activeCoinIndex].transform.parent = null;
                    activeCoinIndex++;
                    if (activeCoinIndex < coins.Count)
                    {
                        coins[activeCoinIndex].gameObject.SetActive(true);
                        coinLocTriggerEventsHandler.meshRenderer = coins[activeCoinIndex].GetComponent<MeshRenderer>();
                    }
                    relocate -= RelocationToBucket;
                }

                break;               
        }
        if (activePointIndex == 0)
        {
            lastColor = MetalLiquidType.Gold;
        }
        if (activePointIndex == 1)
        {
            lastColor = MetalLiquidType.Copper;
        }
        if (activePointIndex == 2)
        {
            lastColor = MetalLiquidType.Silver;
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
