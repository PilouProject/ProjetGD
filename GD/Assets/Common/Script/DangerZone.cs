using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DangerZone : MonoBehaviour
{
    float _startPosX;
    float _startPosZ;
    float _distance;
    float _duration;
    float _duration2;
    int _chanceToDie;
    public int _pourcentageToDie;
    float _tmpSaturation;
    ColorGrading _color;
    PostProcessVolume _postProcess;

    public GameObject _gameObjPost;
    //public PostProcessVolume _postProcess;
    public int _rayon;
    public dayNight _dayNight;


    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.localPosition.x;
        _startPosZ = transform.localPosition.z;
        _duration = 2.0f;
        _duration2 = 0.5f;
        _chanceToDie = 0;
        _tmpSaturation = 10f;
        _color = ScriptableObject.CreateInstance<ColorGrading>();
        _color.enabled.Override(true);
        _color.saturation.Override(_tmpSaturation);
        _postProcess = PostProcessManager.instance.QuickVolume(_gameObjPost.layer, 100f, _color);

        //if we are on the map number X, the value change 
        _pourcentageToDie = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Mathf.Sqrt((Mathf.Abs(transform.localPosition.x) - Mathf.Abs(_startPosX)) * (Mathf.Abs(transform.localPosition.x) - Mathf.Abs(_startPosX)) + (Mathf.Abs(transform.localPosition.z) - Mathf.Abs(_startPosZ)) * (Mathf.Abs(transform.localPosition.z) - Mathf.Abs(_startPosZ)));
        if (_distance > _rayon)
        {
            _duration -= Time.deltaTime;
            _duration2 -= Time.deltaTime;

            if (_duration <= 0.0f)
            {
                if (Random.Range(0, 100) < _chanceToDie) //and if we are on the map 3 or 4
                {
                    _dayNight.GameOver();
                }
                _duration = 2.0f;
                _chanceToDie += _pourcentageToDie;
            }

            if (_duration2 <= 0.0f)
            {
                _duration2 = 0.5f;
                if (_tmpSaturation > -50)
                {
                    _tmpSaturation -= 1;
                    _color.saturation.value = _tmpSaturation;
                }
            }

        }
        else
        {
            _duration2 -= Time.deltaTime;

            if (_duration2 <= 0.0f)
            {
                _duration2 = 0.5f;
                if (_tmpSaturation < 10)
                {
                    _tmpSaturation += 1;
                    _color.saturation.value = _tmpSaturation;
                }
            }
            _chanceToDie = 0;
        }
    }
}
