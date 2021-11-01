using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region Properties
    #endregion

    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mine")
        {
            PlayerSingleton.Instance.GetPlayerRawGoldStorage.EnableMiningMech(true);
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerState.Mine);
        }
        else if (other.gameObject.tag == "CollectionPoint")
        {
            other.gameObject.GetComponent<CollectionPointHandler>().CollectedGold += PlayerSingleton.Instance.GetPlayerRawGoldStorage.UnpackCollectedGold();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Mine" && PlayerSingleton.Instance.PlayerActiveState != PlayerState.Mine)
        {
            other.gameObject.GetComponent<MineHandler>().UpdateMineHealth();
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerState.Mine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mine")
        {
            other.gameObject.GetComponent<MineHandler>().DoneMining();
            PlayerSingleton.Instance.GetPlayerRawGoldStorage.EnableMiningMech(false);
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerState.Run);
        }
    }
    #endregion
}
