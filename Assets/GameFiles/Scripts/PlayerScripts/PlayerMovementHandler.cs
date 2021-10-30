using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float rotSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private CharacterController characterController = null;

    private VariableJoystick movementJS = null;
    private PlayerAnimationsHandler playerAnimationsHandler = null;
    private Vector3 movementDirection = Vector3.zero;
    private Quaternion newRotation = Quaternion.identity;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        movementJS = LevelUIManager.Instance.GetMovementJS;
        playerAnimationsHandler = PlayerSingleton.Instance.GetPlayerAnimationsHandler;
    }

    private void Update()
    {
        movementDirection = new Vector3(movementJS.Horizontal, 0, movementJS.Vertical).normalized;
        characterController.Move(movementDirection * Time.deltaTime * moveSpeed);

        if (movementDirection != Vector3.zero)
        {
            newRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * rotSpeed);

            if (PlayerSingleton.Instance.PlayerActiveState != PlayerState.Run)
            {
                PlayerSingleton.Instance.PlayerActiveState = PlayerState.Run;
                playerAnimationsHandler.SwitchAnimation(PlayerState.Run);
            }
        }
        else
        {
            if (PlayerSingleton.Instance.PlayerActiveState != PlayerState.Idle)
            {
                PlayerSingleton.Instance.PlayerActiveState = PlayerState.Idle;
                playerAnimationsHandler.SwitchAnimation(PlayerState.Idle);
            }
        }
    }
    #endregion

    #region Public Core Functions
    #endregion
}
