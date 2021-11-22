using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCraftingHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private Vector3 rotDirection = Vector3.zero;

    [Header("Components Reference")]
    [SerializeField] private Transform bucket = null;
    [SerializeField] private List<GameObject> icySpikes = null;
    [SerializeField] private List<GameObject> coin = null;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bucket.Rotate(rotDirection * Time.deltaTime * rotSpeed);
        }
    }
    #endregion

    #region Public Core Functions
    public void Freeze()
    {

        foreach (GameObject g in icySpikes) { g.SetActive(true); }

        Invoke("DisplayCoin", 5f);
    }
    #endregion

    #region Invoke Functions
    private void DisplayCoin()
    {
        foreach(GameObject g in coin) { g.SetActive(true); }
        
        for (int i = 0; i < bucket.childCount; i++)
        {
            bucket.GetChild(i).gameObject.SetActive(false);
        }
    }
    #endregion
}
