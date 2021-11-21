using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private Vector3 movementDirection = Vector3.zero;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (!ConveyorBeltMachine.Instance.PauseMachine)
        {
            transform.Translate(movementDirection * Time.deltaTime * moveSpeed);
        }
    }
    #endregion
}
