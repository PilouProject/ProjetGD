using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public Transform _buildingsTop = null;
    public Transform _buildingsLeft = null;
    public Transform _buildingsRight = null;
    public Transform _buildingsBottom = null;
    public GameObject _trashObj = null;
    public int _steps = 20;
    public int _buildingsLevel = 0;
    void Start()
    {
        putTrashs();
    }

    public void resetBuildingsLevel()
    {
        _buildingsTop.position += new Vector3(0, 0, _steps * _buildingsLevel);
        _buildingsLeft.position += new Vector3(-_steps * _buildingsLevel, 0, 0);
        _buildingsRight.position += new Vector3(_steps * _buildingsLevel, 0, 0);
        _buildingsBottom.position += new Vector3(0, 0, -_steps * _buildingsLevel);
        _buildingsLevel = 0;
    }

    public void setBuildingsLevel(int buildingsLevel)
    {
        var diff = buildingsLevel - _buildingsLevel;
        _buildingsLevel = buildingsLevel;
        _buildingsTop.position += new Vector3(0, 0, -(_steps * diff));
        _buildingsLeft.position += new Vector3((_steps * diff), 0, 0);
        _buildingsRight.position += new Vector3(-(_steps * diff), 0, 0);
        _buildingsBottom.position += new Vector3(0, 0, (_steps * diff));
        putTrashs();
    }

    private void putTrashs()
    {
        GameObject trash = null;
        List<Transform> buildingsList = new List<Transform>();
        buildingsList.Add(_buildingsTop);
        buildingsList.Add(_buildingsLeft);
        buildingsList.Add(_buildingsRight);
        buildingsList.Add(_buildingsBottom);
        for (int i = 0; i < buildingsList.Count; i++)
        {
            for (int c = 0; c < 4; c++)
            {
                trash = Instantiate(_trashObj, buildingsList[i], true);
                trash.transform.localPosition = new Vector3(Random.Range(0 + ((_buildingsLevel * _steps) / 2), 165 - ((_buildingsLevel * _steps) / 2)), 47.64799f, Random.Range(-60, -70));
                trash.transform.localEulerAngles = new Vector3(0, -90, 0);
            }
        }
    }
}
