using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image _fadeImage;
    public bool _isInTransition;
    public float _transition;
    public bool _isShowing;
    public float _duration;
    public float _durationEnd;
    private bool _launchTimer;
    public GameObject _player;
    public GameObject _light;
    private bool _trigger;

    // créer fonction setup variables

    private void Start()
    {
        _launchTimer = false;
        _durationEnd = 2.5f;
    }

    public void Fade(bool _showing, float _duration)
    {
        _isShowing = _showing;
        _isInTransition = true;
        this._duration = _duration;
        _transition = (_isShowing) ? 0 : 1;
    }

    private void Update()
    {
        //if pas de fatigue call fade(true, 1.25f) et ecran de mort

        if (_player.GetComponent<Player>()._triggerHouse == true)
        {
            _player.GetComponent<Player>()._triggerHouse = false;
            // add can't move
            _launchTimer = true;
            Fade(true, 1.25f);
        }

        if (_launchTimer == true)  
            _durationEnd -= Time.deltaTime;

        if (_durationEnd <= 0.0f)
        {
            Fade(false, 2.0f);
            //Set variable fuction
            _launchTimer = false;
            _durationEnd = 2.5f;
            _light.GetComponent<dayNight>().resetLvl();
        }

        if (!_isInTransition)
            return;

        if (_isShowing == true)
            _transition += Time.deltaTime * (1 / _duration);
        else
           _transition += -Time.deltaTime * (1 / _duration);
        //_transition += (_isShowing) ? Time.deltaTime * (1 / _duration) : -Time.deltaTime * (1 / _duration);
        _fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, _transition);

        if (_transition > 1 || _transition < 0)
            _isInTransition = false;
        //if < 0 reset variable call function Random check for object bouffe
    }
}
