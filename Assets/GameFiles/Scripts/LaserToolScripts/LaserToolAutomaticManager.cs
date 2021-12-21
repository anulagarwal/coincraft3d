using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserToolAutomaticManager : MonoBehaviour
{
    #region Properties
    public static LaserToolAutomaticManager Instance = null;

    [Header("Attributes")]
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private float moveSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private List<GameObject> coinDents = null;
    [SerializeField] private List<GameObject> coins = null;
    [SerializeField] private GameObject confetti = null;




    [SerializeField] private GameObject coinDent = null;
    [SerializeField] private GameObject cutTrail = null;
    [SerializeField] private Transform laserRod = null;

    [Header("Dent Waypoints")]
    [SerializeField] private List<Transform> triangleDentWaypoints = new List<Transform>();
    [SerializeField] private List<Transform> triangleDentWaypoints_0 = new List<Transform>();
    [SerializeField] private List<Transform> triangleDentWaypoints_1 = new List<Transform>();
    [SerializeField] private List<Transform> triangleDentWaypoints_2 = new List<Transform>();
    [SerializeField] private List<Transform> dent_1_Waypoints = new List<Transform>();
    [SerializeField] private List<Transform> dent_2_Waypoints = new List<Transform>();
    [SerializeField] private List<Transform> crack_1_Waypoints = new List<Transform>();
    [SerializeField] private List<Transform> crack_2_Waypoints = new List<Transform>();

    [Header("Crack Meshes")]
    [SerializeField] private GameObject coinMesh = null;
    [SerializeField] private GameObject dentCoin_1 = null;
    [SerializeField] private GameObject dentCoin_2 = null;
    [SerializeField] private List<Rigidbody> crackCoin_1 = new List<Rigidbody>();
    [SerializeField] private List<Rigidbody> crackCoin_2 = new List<Rigidbody>();

    private int targetLocationIndex = 0;
    private Vector3 targetLocation = Vector3.zero;
    #endregion

    #region Delegates
    public delegate void LaserMechanism();

    public LaserMechanism laserMechanism;
    #endregion

    #region MonoBehviour Functions
    private void Awake()
    {
        if (Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        laserMechanism = null;
    }

    private void Update()
    {
        if (laserMechanism != null)
        {
            laserMechanism();
        }
    }
    #endregion

    #region Private Core Functions
    private void CircleDent()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            cutTrail.SetActive(false);
            coinDent.SetActive(false);
            
        }
    }

    private void TriangleDent()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            targetLocation = new Vector3(triangleDentWaypoints[targetLocationIndex].position.x, laserRod.localPosition.y, triangleDentWaypoints[targetLocationIndex].position.z);
            if (Vector3.Distance(laserRod.localPosition, targetLocation) > 0.005f)
            {
                laserRod.localPosition = Vector3.MoveTowards(laserRod.localPosition, targetLocation, Time.deltaTime * moveSpeed);
            }
            else
            {
                if (targetLocationIndex < triangleDentWaypoints.Count - 1)
                {
                    targetLocationIndex++;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            cutTrail.SetActive(false);
            coinDent.SetActive(false);
            confetti.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region Public Core Functions
    public void EnableLaserMech(int type)
    {
       /* switch (type)
        {
            case (int)CoinDentType.Circle:
                laserMechanism += CircleDent;
                break;
            case (int)CoinDentType.Triangle:
                laserMechanism += TriangleDent;
                break;
        }*/
        foreach(GameObject g in coins)
        {
            g.SetActive(false);
        }
                laserMechanism += TriangleDent;

        coinDent = coinDents[type];       
        coins[type].SetActive(true);
        switch (type)
        {
            case 0:
                triangleDentWaypoints = triangleDentWaypoints_0;
                break;
            case 1:
                triangleDentWaypoints = triangleDentWaypoints_1;
                break;
            case 2:
                triangleDentWaypoints = triangleDentWaypoints_2;
                break;
            case 3:
                triangleDentWaypoints = dent_1_Waypoints;
                break;
            case 4:
                triangleDentWaypoints = dent_2_Waypoints;
                break;
            case 5:
                print("Working");
                triangleDentWaypoints = crack_1_Waypoints;
                break;
            case 6:
                triangleDentWaypoints = crack_2_Waypoints;
                break;
        }

    }
    #endregion
}
