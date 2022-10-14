using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _spawnRateInputField;
    [SerializeField] private TMP_InputField _xCoordInputField;
    [SerializeField] private TMP_InputField _yCoordInputField;

    [SerializeField] private Transform _targetPoint;

    private UnitSpawner _unitSpawner;

    private void Awake()
    {
        _unitSpawner = FindObjectOfType<UnitSpawner>();
    }


    private void Start()
    {
        _yCoordInputField.text = _targetPoint.position.z.ToString();
        _xCoordInputField.text = _targetPoint.position.x.ToString();
        _speedInputField.text = _unitSpawner.UnitSpeed.ToString();
        _spawnRateInputField.text = _unitSpawner.SpawnCoolDown.ToString();
    }

    public void XCoordChange()
    {
        float res = ParseTextToValue(_xCoordInputField.text);
        _xCoordInputField.text = res.ToString();
        _targetPoint.position = new Vector3(res, _targetPoint.position.y, _targetPoint.position.z);

    }

    public void YCoordChange()
    {
        float res = ParseTextToValue(_yCoordInputField.text);
        _yCoordInputField.text = res.ToString();
        _targetPoint.position = new Vector3(_targetPoint.position.x, _targetPoint.position.y, res);
    }
    public void SpeedChange()
    {
        float res = ParseTextToValue(_speedInputField.text);
        if (res <= 0)
        {
            res = 1;
        }
        _speedInputField.text = res.ToString();
        _unitSpawner.ChangeSpeed(res);
    }
    public void CoolDownChange()
    {
        float res = ParseTextToValue(_spawnRateInputField.text);
        if (res <= 0)
        {
            res = 1;
        }
        _spawnRateInputField.text = res.ToString();
        _unitSpawner.ChangeSpawnCoolDown(res);
    }

    private float ParseTextToValue(string text)
    {
        float res;
        float.TryParse(text, out res);
        if (res > 10)
        {
            res = 10;
        }
        if (res < -10)
        {
            res = -10;
        }
        return res;
    }
}
