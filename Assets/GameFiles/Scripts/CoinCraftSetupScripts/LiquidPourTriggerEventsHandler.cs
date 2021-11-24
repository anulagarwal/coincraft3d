using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidPourTriggerEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinCraftingHandler.Instance.ChangePourTarget();
        }
    }
    #endregion
}
