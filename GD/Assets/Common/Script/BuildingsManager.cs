using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public Transform _buildingsTop = null;
    public Transform _buildingsLeft = null;
    public Transform _buildingsRight = null;
    public Transform _buildingsBottom = null;
    public int _steps = 20;
    public int _buildingsLevel = 0;
    void Start()
    {

    }

    public void resetBuildingsLevel()
    {
        _buildingsTop.position += new Vector3(0, 0, _steps * _buildingsLevel);
        _buildingsLeft.position += new Vector3(_steps * _buildingsLevel, 0, 0);
        _buildingsRight.position += new Vector3(-_steps * _buildingsLevel, 0, 0);
        _buildingsBottom.position += new Vector3(0, 0, -_steps * _buildingsLevel);
        _buildingsLevel = 0;
    }

    public void setBuildingsLevel(int buildingsLevel)
    {
        _buildingsLevel = buildingsLevel;
        _buildingsTop.position += new Vector3(0, 0, -_steps);
        _buildingsLeft.position += new Vector3(-_steps, 0, 0);
        _buildingsRight.position += new Vector3(_steps, 0, 0);
        _buildingsBottom.position += new Vector3(0, 0, _steps);
    }

    void Update()
    {

    }
}
