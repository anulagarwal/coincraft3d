using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float lavaRiseSpeed = 0f;
    [SerializeField] private float lavaMaxHeight = 0f;

    [Header("Components Reference")]
    [SerializeField] private Transform lavaTransform = null;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (lavaTransform.position.y < lavaMaxHeight)
        {
            lavaTransform.Translate(Vector3.up * Time.deltaTime * lavaRiseSpeed);
        }
    }
    #endregion
}
