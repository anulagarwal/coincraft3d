using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator animator = null;
    #endregion

    #region Animation Events Functions
    private void AnimEvent_PlaceStampEnd()
    {
        animator.SetBool("b_PlaceStamp", false);

        if (StampSingleton.Instance.TouchedCoin)
        {
            CoinsManager.Instance.MoveToNext(true);
            StampSingleton.Instance.TouchedCoin = false;
        }
    }
    #endregion

    #region Public Core Functions
    public void PlaceStampOnCoin()
    {
        animator.SetBool("b_PlaceStamp", true);
        StampSingleton.Instance.IsUseAble = false;
    }
    #endregion
}
