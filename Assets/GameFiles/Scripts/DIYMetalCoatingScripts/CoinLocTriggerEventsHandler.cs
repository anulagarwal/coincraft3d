using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLocTriggerEventsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private ParticleSystem silverCoatDrops = null;
    [SerializeField] private ParticleSystem goldCoatDrops = null;
    [SerializeField] private ParticleSystem copperCoatDrops = null;
    #endregion

    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MetalLiquid")
        {
            if(other.gameObject.TryGetComponent<MetalLiquidHandler>(out MetalLiquidHandler metalLiquidHandler))
            {
                meshRenderer.material = metalLiquidHandler.GetMeshRenderer.material;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MetalLiquid")
        {
            if (other.gameObject.TryGetComponent<MetalLiquidHandler>(out MetalLiquidHandler metalLiquidHandler))
            {
                if (metalLiquidHandler.GetMetalLiquidType == MetalLiquidType.Gold)
                {
                    goldCoatDrops.Play();
                }
                else if (metalLiquidHandler.GetMetalLiquidType == MetalLiquidType.Silver)
                {
                    silverCoatDrops.Play();
                }
                else if (metalLiquidHandler.GetMetalLiquidType == MetalLiquidType.Copper)
                {
                    copperCoatDrops.Play();
                }
            }
        }
    }
    #endregion
}
