using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketAnimationsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private Animator bucketAnimator = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        Pouring = false;
    }
    #endregion

    #region Getter And Setter
    public bool Pouring { get; set; }
    #endregion

    #region Public Core Functions
    public void PlayPourAnimation(bool value)
    {
        Pouring = value;
        bucketAnimator.SetBool("b_Pour", value);
    }
    #endregion
}
