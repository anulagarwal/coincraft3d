using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator hammerAnimator = null;
    #endregion

    #region Getter And Setter
    public GameObject Rock { get; set; }
    #endregion

    #region Animation Events Functions
    private void AnimEvent_BreakRock()
    {
        Destroy(Rock);
        ConveyorBeltMachine.Instance.PauseConveyorBelt(false);
    }
    #endregion

    #region Public Core Functions
    public void PlayHammerSmash()
    {
        hammerAnimator.SetTrigger("t_Smash");
    }
    #endregion
}
