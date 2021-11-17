using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TemperatureRiseBtnHandler : MonoBehaviour, IPointerClickHandler
{
    
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float temperatureRiseSpeed = 0f;
    [SerializeField] private float temperatureFallSpeed = 0f;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        LevelUIManager.Instance.TemperatureDecrementPB(Time.deltaTime * temperatureFallSpeed);
    }
    #endregion

    #region Interface Functions
    public void OnPointerClick(PointerEventData eventData)
    {
        Phase2Manager.Instance.GetContainerHandler.UpdateLava();
        LevelUIManager.Instance.TemperatureIncrementPB(Time.deltaTime * temperatureRiseSpeed);
    }
    #endregion
}
