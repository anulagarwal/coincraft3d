using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float spawnSpeed = 0f;
    [SerializeField] private int spawnAmount = 0;

    [Header("Components Reference")]
    [SerializeField] private GameObject goldObj = null;
    [SerializeField] private GameObject rockObj = null;

    private float nextTimeToSpawn = 0f;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        nextTimeToSpawn = spawnSpeed;

        //Testing
        spawnAmount = PlayerPrefs.GetInt("CollectedGold");
    }

    private void Update()
    {
        if (nextTimeToSpawn <= 0 && spawnAmount > 0)
        {
            SpawnOres();
            nextTimeToSpawn = spawnSpeed;
        }
        else
        {
            nextTimeToSpawn -= Time.deltaTime;

            if (spawnAmount <= 0)
            {
                this.enabled = false;
            }
        }
    }
    #endregion

    #region Private Core Functions
    private void SpawnOres()
    {
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(rockObj, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(goldObj, transform.position, Quaternion.identity);
        }

        spawnAmount--;
    }
    #endregion
}
