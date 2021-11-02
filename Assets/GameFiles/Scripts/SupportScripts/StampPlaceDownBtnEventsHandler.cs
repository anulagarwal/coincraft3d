using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StampPlaceDownBtnEventsHandler : MonoBehaviour, IPointerClickHandler
{
    #region Interface Functions
    public void OnPointerClick(PointerEventData eventData)
    {
        if (StampSingleton.Instance.IsUseAble)
        {
            StampSingleton.Instance.GetStampAnimationsHandler.PlaceStampOnCoin();
        }
    }
    #endregion
}
