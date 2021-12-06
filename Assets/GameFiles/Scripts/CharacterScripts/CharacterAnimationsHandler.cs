using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator animator = null;
    #endregion

    #region Public Core Functions
    public void SwitchCharacterAnimation(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Curious:
                break;
            case CharacterState.Clap:
                animator.SetTrigger("t_Clap");
                break;
        }
    }
    #endregion
}
