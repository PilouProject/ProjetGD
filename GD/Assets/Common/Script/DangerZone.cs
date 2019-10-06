using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    float _startPosX;
    float _startPosZ;
    float _distance;
    float _duration;
    int _chanceToDie;
    int _pourcentageToDie;
    public int _rayon;
    public dayNight _dayNight;
   
    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.localPosition.x;
        _startPosZ = transform.localPosition.z;
        _duration = 2.0f;
        _chanceToDie = 0;
        //if we are on the map number X, the value change 
        _pourcentageToDie = 5;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Mathf.Sqrt((Mathf.Abs(transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(transform.localPosition.z) - Mathf.Abs(_startPosZ)));
        if (_distance > _rayon)
        {
            _duration -= Time.deltaTime;

            if (_duration <= 0.0f)
            {
                if (Random.Range(0, 100) < _chanceToDie) //and if we are on the map 3 or 4
                {
                    _dayNight.GameOver();
                }
                _duration = 2.0f;
                _chanceToDie += _pourcentageToDie;
            }
        }
        else
        {
            _chanceToDie = 0;
        }
    }
}
