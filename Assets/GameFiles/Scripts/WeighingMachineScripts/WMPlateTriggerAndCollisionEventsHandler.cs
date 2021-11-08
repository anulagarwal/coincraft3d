using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMPlateTriggerAndCollisionEventsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private WMHandler wmHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //wmHandler.UpdateWMScreen(-10);
        }
    }
    #endregion
}
