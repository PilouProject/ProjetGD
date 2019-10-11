using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private GameObject[] _trees;
    private GameObject[] _trunks;
    private GameObject[] _city;
    private float _distance;
    private int _startPosX;
    private int _startPosZ;

    public int _rayonMap2;
    public int _rayonMap3;
    public GameObject _treeTrunk;


    void Start()
    {
        _trees = GameObject.FindGameObjectsWithTag("Tree");
        _city = GameObject.FindGameObjectsWithTag("City");
        _startPosX = -1;
        _startPosZ = -3;        
    }

    void NoTrunks()
    {
        _trunks = GameObject.FindGameObjectsWithTag("Trunk");
    }

    public void ChangeMap(int map)
    {
        if (map == 2)
        {
            foreach (GameObject tmp in _trees)
            {
                _distance = Mathf.Sqrt((Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)));
                if (_distance > _rayonMap2)
                {
                    Instantiate(_treeTrunk);
                    //_treeTrunk.tag = "Trunk";
                    _treeTrunk.transform.localPosition = new Vector3(tmp.transform.localPosition.x, 0.1f, tmp.transform.localPosition.z + 8f);

                    tmp.SetActive(false);

                }
            }
            NoTrunks();
            _treeTrunk.SetActive(false);
        }

        if (map == 3)
        {
            foreach (GameObject tmp in _trees)
            {
                _distance = Mathf.Sqrt((Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)));
                if (_distance > _rayonMap3)
                    tmp.SetActive(false);
            }

            foreach (GameObject tmp2 in _city)
                tmp2.SetActive(true);

            foreach (GameObject tmp3 in _trunks)
                tmp3.SetActive(false);
        }
    }
}
