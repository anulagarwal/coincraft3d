using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSingleton : MonoBehaviour
{
    #region Properties
    public static CharacterSingleton Instance = null;

    [Header("Components Reference")]
    [SerializeField] private CharacterAnimationsHandler characterAnimationsHandler = null;
    [SerializeField] private CharacterSpeechHandler characterSpeechHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    #endregion

    #region Getter And Setter
    public CharacterAnimationsHandler GetCharacterAnimationsHandler { get => characterAnimationsHandler; }
    
    public CharacterSpeechHandler GetCharacterSpeechHandler { get => characterSpeechHandler; }
    #endregion

    #region Public Core Functions
    #endregion
}
