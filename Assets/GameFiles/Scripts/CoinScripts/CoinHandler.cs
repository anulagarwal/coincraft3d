using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private MeshRenderer coinMarkMR = null;

    private Material coinMarkMat = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        coinMarkMat = coinMarkMR.material;
    }
    #endregion

    #region Public Core Functions
    public void PrintCoinMark(Texture coinMarkTexture)
    {
        coinMarkMR.enabled = true;
        coinMarkMat.mainTexture = coinMarkTexture;
    }
    #endregion
}
