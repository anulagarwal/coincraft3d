using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCraftingHandler : MonoBehaviour
{//
    #region Properties
    public static CoinCraftingHandler Instance = null;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float fillSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private Transform lavaBucketTransform = null;
    [SerializeField] private List<Transform> pourPoints = new List<Transform>();
    [SerializeField] private List<Transform> moltenGold = new List<Transform>();
    [SerializeField] private List<Transform> coins = new List<Transform>();
    [SerializeField] private List<GameObject> icySpikes = new List<GameObject>();
    [SerializeField] private BucketAnimationsHandler bucketAnimationsHandler = null;

    private int targetIndex = 0;
    #endregion

    #region Delegates
    private delegate void CoreMech();

    private CoreMech coreMech = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        coreMech = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableCoinCraftingCoreMech();
        }

        if (coreMech != null)
        {
            coreMech();
        }
    }
    #endregion

    #region Getter And Setter
    public BucketAnimationsHandler GetBucketAnimationsHandler { get => bucketAnimationsHandler; }
    #endregion

    #region Private Core Functions
    private void CraftingCoreMech()
    {
        if (Vector3.Distance(lavaBucketTransform.position, pourPoints[targetIndex].position) > 0.1f)
        {
            lavaBucketTransform.position = Vector3.MoveTowards(lavaBucketTransform.position, pourPoints[targetIndex].position, Time.deltaTime * moveSpeed);
        }
        else
        {
            if (!bucketAnimationsHandler.Pouring)
            {
                bucketAnimationsHandler.PlayPourAnimation(true);
            }
            else
            {
                moltenGold[targetIndex].Translate(Vector3.up * Time.deltaTime * fillSpeed);
            }
        }
    }
    #endregion

    #region Public Core Functions
    public void EnableCoinCraftingCoreMech()
    {
        coreMech += CraftingCoreMech;
    }

    public void ChangePourTarget()
    {
        if (targetIndex < pourPoints.Count - 1)
        {
            targetIndex++;
        }
        else
        {
            GetBucketAnimationsHandler.PlayPourAnimation(false);
            this.enabled = false;
        }
    }

    public void FreezeCoins()
    {
        for(int i = 0; i < coins.Count; i++)
        {
            icySpikes[i].SetActive(true);
            coins[i].gameObject.SetActive(true);
            moltenGold[i].gameObject.SetActive(false);
        }
    }
    #endregion


    //#region Properties
    //[Header("Attributes")]
    //[SerializeField] private float rotSpeed = 0f;
    //[SerializeField] private Vector3 rotDirection = Vector3.zero;

    //[Header("Components Reference")]
    //[SerializeField] private Transform bucket = null;
    //[SerializeField] private List<GameObject> icySpikes = null;
    //[SerializeField] private List<GameObject> coin = null;
    //#endregion

    //#region MonoBehaviour Functions
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        bucket.Rotate(rotDirection * Time.deltaTime * rotSpeed);
    //    }
    //}
    //#endregion

    //#region Public Core Functions
    //public void Freeze()
    //{

    //    foreach (GameObject g in icySpikes) { g.SetActive(true); }

    //    Invoke("DisplayCoin", 5f);
    //}
    //#endregion

    //#region Invoke Functions
    //private void DisplayCoin()
    //{
    //    foreach(GameObject g in coin) { g.SetActive(true); }

    //    for (int i = 0; i < bucket.childCount; i++)
    //    {
    //        bucket.GetChild(i).gameObject.SetActive(false);
    //    }
    //}
    //#endregion
}
