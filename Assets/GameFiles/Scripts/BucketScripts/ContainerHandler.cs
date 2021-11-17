using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float lavaRiseSpeed = 0f;
    [SerializeField] private float lavaMaxHeight = 0f;
    [SerializeField] private float flameRiseSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private Transform lavaTransform = null;
    [SerializeField] private Transform flameTransform = null;
    [SerializeField] private ParticleSystem airBlow = null;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        //if (lavaTransform.position.y < lavaMaxHeight)
        //{
        //    lavaTransform.Translate(Vector3.up * Time.deltaTime * lavaRiseSpeed);
        //}
    }
    #endregion

    #region Getter And Setter
    public ParticleSystem GetAirBlow { get => airBlow; }
    #endregion

    #region Public Core Functions
    public void UpdateLava()
    {
        if (lavaTransform.position.y < lavaMaxHeight)
        {
            Invoke("TurnOffAirBlow", 1f);
            lavaTransform.Translate(Vector3.up * Time.deltaTime * lavaRiseSpeed);
            flameTransform.localScale += Vector3.one * Time.deltaTime * flameRiseSpeed; 
        }
    }
    #endregion

    #region Invoke Functions
    private void TurnOffAirBlow()
    {
        airBlow.Stop();
    }
    #endregion
}
