using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public Transform _buildingsTop = null;
    public Transform _buildingsLeft = null;
    public Transform _buildingsRight = null;
    public Transform _buildingsBottom = null;
    public GameObject _surroundings = null;
    public int _steps = 20;
    public int _buildingsLevel = 0;
    void Start()
    {
        deleteNature();
    }

    public void resetBuildingsLevel()
    {
        _buildingsTop.position += new Vector3(0, 0, _steps * _buildingsLevel);
        _buildingsLeft.position += new Vector3(-_steps * _buildingsLevel, 0, 0);
        _buildingsRight.position += new Vector3(_steps * _buildingsLevel, 0, 0);
        _buildingsBottom.position += new Vector3(0, 0, -_steps * _buildingsLevel);
        _buildingsLevel = 0;
    }

    void deleteNature()
    {
        GameObject[] flowers;
        flowers = GameObject.FindGameObjectsWithTag("Fleur");
        foreach (GameObject flower in flowers)
        {
            float dist = Vector3.Distance(flower.transform.position, new Vector3(0, 0, 0));
            if (dist > 70 - (_buildingsLevel * _steps)) flower.SetActive(false);
        }
    }

    public void setBuildingsLevel(int buildingsLevel)
    {
        var diff = buildingsLevel - _buildingsLevel;
        _surroundings.transform.Find("Level " + _buildingsLevel).gameObject.SetActive(false);
        _surroundings.transform.Find("Level " + buildingsLevel).gameObject.SetActive(true);
        _buildingsLevel = buildingsLevel;
        _buildingsTop.position += new Vector3(0, 0, -(_steps * diff));
        _buildingsLeft.position += new Vector3((_steps * diff), 0, 0);
        _buildingsRight.position += new Vector3(-(_steps * diff), 0, 0);
        _buildingsBottom.position += new Vector3(0, 0, (_steps * diff));
        deleteNature();
    }
}
