using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.GetComponent<CoinHandler>().PrintCoinMark(CoinsManager.Instance.ActiveCoinMark);
            StampSingleton.Instance.TouchedCoin = true;
            //Print Mark
        }
    }
    #endregion
}
