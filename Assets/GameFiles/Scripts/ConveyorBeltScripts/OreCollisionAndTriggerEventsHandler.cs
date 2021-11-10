using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreCollisionAndTriggerEventsHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private OreType oreType = OreType.Gold;

    [Header("Components Reference")]
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private OreMovementHandler oreMovementHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void OnMouseDown()
    {
        if (oreType == OreType.Rock)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CBExitPoint")
        {
            rb.isKinematic = false;
            oreMovementHandler.enabled = false;

            if(oreType == OreType.Gold)
            {
                Phase2Manager.Instance.GoldCollected++;
            }
            else
            {
                Phase2Manager.Instance.RockCollected++;
            }

            Phase2Manager.Instance.CalculatePurity();


        }
        else if (other.gameObject.tag == "CBCollector")
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
