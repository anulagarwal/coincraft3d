using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator animator = null;
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Public Core Functions
    public void SwitchAnimation(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Idle:
                animator.SetBool("b_Run", false);
                animator.SetBool("b_Mining", false);
                break;
            case PlayerState.Run:
                animator.SetBool("b_Run", true);
                animator.SetBool("b_Mining", false);
                break;
            case PlayerState.Mine:
                animator.SetBool("b_Run", false);
                animator.SetBool("b_Mining", true);
                break;
        }
    }
    #endregion
}
