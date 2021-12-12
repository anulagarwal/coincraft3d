using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalLiquidHandler : MonoBehaviour
{//
    #region Properties
    [Header("Attributes")]
    [SerializeField] private MetalLiquidType metalLiquidType = MetalLiquidType.Gold;

    [Header("Components Reference")]
    [SerializeField] private MeshRenderer meshRenderer = null;
    #endregion

    #region Getter And Setter
    public MetalLiquidType GetMetalLiquidType { get => metalLiquidType; }

    public MeshRenderer GetMeshRenderer { get => meshRenderer; }
    #endregion
}
