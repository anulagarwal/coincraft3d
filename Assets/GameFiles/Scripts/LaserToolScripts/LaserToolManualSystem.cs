using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserToolManualSystem : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private CharacterController characterController = null;
    [SerializeField] private VariableJoystick movementJS = null;

    private Vector3 movementDirection = Vector3.zero;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        movementDirection = new Vector3(-movementJS.Horizontal, 0, -movementJS.Vertical);
        characterController.Move(movementDirection * Time.deltaTime * moveSpeed);
    }
    #endregion
}
