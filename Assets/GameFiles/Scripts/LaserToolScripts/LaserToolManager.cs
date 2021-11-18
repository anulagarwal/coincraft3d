using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserToolManager : MonoBehaviour
{
    #region Properties
    public static LaserToolManager Instance = null;

    [Header("Attributes")]
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private float moveSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private GameObject coinDent = null;
    [SerializeField] private GameObject cutTrail = null;
    [SerializeField] private Transform laserRod = null;

    [Header("Dent Waypoints")]
    [SerializeField] private List<Transform> triangleDentWaypoints = new List<Transform>();

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
            if (Vector3.Distance(laserRod.localPosition, targetLocation) > 0.2f)
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
    }
    #endregion

    #region Public Core Functions
    public void EnableLaserMech(int type)
    {
        switch (type)
        {
            case (int)CoinDentType.Circle:
                laserMechanism += CircleDent;
                break;
            case (int)CoinDentType.Triangle:
                laserMechanism += TriangleDent;
                break;
        }
    }
    #endregion
}
