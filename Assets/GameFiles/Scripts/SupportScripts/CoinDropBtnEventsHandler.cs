using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinDropBtnEventsHandler : MonoBehaviour, IPointerDownHandler
{
    #region Properties
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Interface Functions
    public void OnPointerDown(PointerEventData eventData)
    {
        CoinsDropManager.Instance.DropCoin();
    }
    #endregion
}
