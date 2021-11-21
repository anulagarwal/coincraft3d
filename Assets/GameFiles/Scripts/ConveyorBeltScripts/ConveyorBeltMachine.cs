using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMachine : MonoBehaviour
{
    #region Properties
    public static ConveyorBeltMachine Instance = null;

    [Header("Attributes")]
    [SerializeField] private float beltSpeed = 0f;

    [Header("Components Reference")]
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private HammerAnimationsHandler hammerAnimationsHandler = null;

    private Material conveyorBeltMat = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        conveyorBeltMat = meshRenderer.material;
        PauseMachine = false;
    }
    #endregion

    #region Getter And Setter
    public bool PauseMachine { get; set; }
    #endregion

    #region Public Core Functions
    public void PauseConveyorBelt(bool value, GameObject rock = null)
    {
        PauseMachine = value;

        if (value)
        {
            conveyorBeltMat.SetVector("_ScrollSpeed", new Vector2(0, 0));
            hammerAnimationsHandler.Rock = rock;
            hammerAnimationsHandler.transform.position = new Vector3(0, 0, rock.transform.position.z);
            hammerAnimationsHandler.PlayHammerSmash();
        }
        else
        {
            conveyorBeltMat.SetVector("_ScrollSpeed", new Vector2(0, beltSpeed));
        }
    }
    #endregion
}
