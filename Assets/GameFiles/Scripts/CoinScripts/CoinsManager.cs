using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    #region Properties
    public static CoinsManager Instance = null;

    [Header("Attributes")]
    [SerializeField] private int coinSpawnAmount = 0;
    [SerializeField] private float coinWidth = 0f;
    [SerializeField] private Vector3 coinPosition = Vector3.zero;
    [SerializeField] private float coinSweepspeed = 0;

    [Header("Components Reference")]
    [SerializeField] private GameObject coinPrefab = null;
    [SerializeField] private Transform coinsHolder = null;

    private float coinXPosOffset = 0f;
    private int activeCoinIndex = 0;
    private Vector3 targetPosition = Vector3.zero;
    #endregion

    #region Delegates
    public delegate void MoveCoinHolderMech();

    public MoveCoinHolderMech moveCoinHolderMech = null;
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
        activeCoinIndex = 0;
        SpawnCoins();
    }


    private void Update()
    {
        if (moveCoinHolderMech != null)
        {
            moveCoinHolderMech();
        }
    }
    #endregion

    #region Getter And Setter
    public Texture ActiveCoinMark { get; set; }
    #endregion

    #region Private Core Functions
    private void SpawnCoins()
    {
        for (int i = 0; i < coinSpawnAmount; i++)
        {
            Instantiate(coinPrefab, coinPosition, Quaternion.identity, this.coinsHolder);
            coinPosition.x -= coinWidth;
        }
    }

    private void MoveCoinHolderToTargetPosition()
    {
        if (Vector3.Distance(coinsHolder.position, targetPosition) > 0f)
        {
            coinsHolder.position = Vector3.MoveTowards(coinsHolder.position, targetPosition, Time.deltaTime * coinSweepspeed);
        }
        else
        {
            coinsHolder.position = targetPosition;
            StampSingleton.Instance.IsUseAble = true;
            MoveToNext(false);
        }
    }
    #endregion

    #region Public Core Functions
    public void MoveToNext(bool value)
    {
        if (value)
        {
            if (activeCoinIndex < coinSpawnAmount)
            {
                targetPosition = new Vector3(coinsHolder.position.x + coinWidth, coinsHolder.position.y, coinsHolder.position.z);
                activeCoinIndex++;
                moveCoinHolderMech += MoveCoinHolderToTargetPosition;
            }
        }
        else
        {
            moveCoinHolderMech = null;
        }
    }
    #endregion
}
