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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Mine" && PlayerSingleton.Instance.PlayerActiveState != PlayerState.Mine)
        {
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerState.Mine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mine")
        {
            PlayerSingleton.Instance.GetPlayerRawGoldStorage.EnableMiningMech(false);
            PlayerSingleton.Instance.GetPlayerAnimationsHandler.SwitchAnimation(PlayerState.Run);
        }
    }
    #endregion
}
