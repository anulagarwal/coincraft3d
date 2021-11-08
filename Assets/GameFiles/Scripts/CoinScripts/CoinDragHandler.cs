using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDragHandler : MonoBehaviour
{
    #region Properties
    #endregion

    #region MonoBehaviour Functions
    private void OnMouseDown()
    {
        WMHandler.Instance.UpdateWMScreen(-10);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WMBorder")
        {
            WMHandler.Instance.UpdateWMScreen(-10);
            Destroy(this.gameObject);
        }
    }
    #endregion
}
