using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private GameObject[] _trees;
    private GameObject[] _trunks;
    private GameObject[] _fleurs;
    private float _distance;
    private int _startPosX;
    private int _startPosZ;

    public int _rayonMap2;
    public GameObject _treeTrunk;
    public BuildingsManager _buildingsManager;
    public DangerZone _dangerZone;
    public GameObject _mapToActivate;
    public GameObject _mapToDisabled;


    void Start()
    {
        _trees = GameObject.FindGameObjectsWithTag("Tree");
        _fleurs = GameObject.FindGameObjectsWithTag("Fleur");
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
                    _treeTrunk.transform.localPosition = new Vector3(tmp.transform.localPosition.x, 0.1f, tmp.transform.localPosition.z + 8f);

                    tmp.SetActive(false);

                }
            }

            foreach (GameObject tmp in _fleurs)
            {
                _distance = Mathf.Sqrt((Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)));
                if (_distance > _rayonMap2)
                    tmp.SetActive(false);
            }

            NoTrunks();
            _treeTrunk.SetActive(false);
        }

        if (map == 3)
        {
            _mapToActivate.SetActive(true);
            _mapToDisabled.SetActive(false);
            _dangerZone._pourcentageToDie = 1;
            _dangerZone._rayon = 70;
            //foreach (GameObject tmp in _trees)
            //{
            //    _distance = Mathf.Sqrt((Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)));
            //    if (_distance > _rayonMap3)
            //        tmp.SetActive(false);
            //}

            //foreach (GameObject tmp2 in _city)
            //    tmp2.SetActive(true);

            //foreach (GameObject tmp3 in _trunks)
            //    tmp3.SetActive(false);
        }

        if (map >= 4 && map < 7)
        {
            if (map == 4)
                _dangerZone._rayon = 46;
            if (map == 5)
                _dangerZone._rayon = 30;
            if (map == 6)
                _dangerZone._rayon = 18;

            _dangerZone._pourcentageToDie = 2;
            _buildingsManager.setBuildingsLevel(_buildingsManager._buildingsLevel + 1);

            if (map == 5)
            {
                foreach (GameObject tmp3 in _trunks)
                    tmp3.SetActive(false);
            }
        }

        if (map == 7)
        {

            _dangerZone._pourcentageToDie = 5;
            _dangerZone._rayon = 100;
            _treeTrunk.SetActive(true);

            foreach (GameObject tmp in _trees)
            {
                _distance = Mathf.Sqrt((Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(tmp.transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(tmp.transform.localPosition.z) - Mathf.Abs(_startPosZ)));
                if (_distance > -1)
                {
                    Instantiate(_treeTrunk);
                    _treeTrunk.transform.localPosition = new Vector3(tmp.transform.localPosition.x, 0.1f, tmp.transform.localPosition.z + 8f);

                    tmp.SetActive(false);

                }
            }

            _treeTrunk.SetActive(true);
            _dangerZone._rayon = 0;
        }
    }
}
