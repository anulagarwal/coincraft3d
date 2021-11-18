using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinShapeTrayCollisionEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MoltenGold")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    #endregion
}
