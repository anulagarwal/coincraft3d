using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BucketThreshold")
        {
            Phase2Manager.Instance.SwitchToCam3();
        }
    }
    #endregion
}
