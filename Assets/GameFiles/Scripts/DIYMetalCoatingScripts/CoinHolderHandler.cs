using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHolderHandler : MonoBehaviour
{
    #region Properties
    public static CoinHolderHandler Instance = null;

    [Header("Attributes")]
    [SerializeField] private float relocationSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private Animator coinHolderAnimator = null;
    [SerializeField] private List<Transform> points = new List<Transform>();

    private int activePointIndex = 0;
    #endregion

    #region Delegates
    public delegate void Relocate();

    public Relocate relocate = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Update()
    {
        if (relocate != null)
        {
            relocate();
        }
    }
    #endregion

    #region Private Core Functions
    private void RelocationCore()
    {
        if (Vector3.Distance(transform.position,points[activePointIndex].position) >= 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[activePointIndex].position, Time.deltaTime * relocationSpeed);
        }
        else
        {
            EnableRelocation(Relocation.None, false);
        }
    }
    #endregion

    #region Public Core Functions
    public void EnableRelocation(Relocation r, bool value)
    {
        switch (r)
        {
            case Relocation.Left:
                if (activePointIndex > 0)
                {
                    activePointIndex--;
                }
                break;
            case Relocation.Right:
                if (activePointIndex < points.Count - 1)
                {
                    activePointIndex++;
                }
                break;
        }

        if (value)
        {
            relocate += RelocationCore;
        }
        else
        {
            relocate -= RelocationCore;
        }
    }

    public void Dip()
    {
        coinHolderAnimator.SetBool("b_Dip", true);
    }
    #endregion

    #region Anim Events Functions
    private void AnimEvent_EndDip()
    {
        coinHolderAnimator.SetBool("b_Dip", false);
    }
    #endregion
}
