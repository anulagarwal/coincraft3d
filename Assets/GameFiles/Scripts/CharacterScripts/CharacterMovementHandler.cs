using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float endRotation = 0f;
    [SerializeField] private float rotSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private Transform targetPoint = null;
    [SerializeField] private CharacterAnimationsHandler characterAnimationsHandler = null;

    private Vector3 movementDirection = Vector3.zero;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        movementDirection = (targetPoint.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, targetPoint.position) > 0.1f)
        {
            characterAnimationsHandler.SwitchCharacterAnimation(CharacterState.Walk);
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }
        else
        {
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, endRotation, 0)) > 1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, endRotation, 0), Time.deltaTime * rotSpeed);
            }
            else
            {
                characterAnimationsHandler.SwitchCharacterAnimation(CharacterState.Curious);
                this.enabled = false;
            }
        }
    }
    #endregion
}
