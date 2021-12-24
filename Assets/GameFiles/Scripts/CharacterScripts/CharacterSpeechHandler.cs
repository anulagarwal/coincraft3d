using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSpeechHandler : MonoBehaviour
{
    #region Properties
    [Header("Properties")]
    [SerializeField] private string txt = null;

    [Header("Components Reference")]
    [SerializeField] private GameObject speechCloud = null;
    [SerializeField] private TextMeshProUGUI speehCloudTxt = null;
    [SerializeField] private GameObject goButton = null;

    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        EnableSpeechCloud(false);
        speehCloudTxt.SetText(txt);
        
    }
    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            EnableSpeechCloud(true);
            GetComponent<CharacterAnimationsHandler>().SwitchCharacterAnimation(CharacterState.Clap);
        }
    }
    #region Public Core Functions
    public void EnableSpeechCloud(bool value)
    {
        speechCloud.SetActive(value);
        goButton.SetActive(value);
    }
    #endregion
}
