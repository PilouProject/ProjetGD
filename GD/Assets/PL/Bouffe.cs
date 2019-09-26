using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouffe : MonoBehaviour
{
    public float _compteur;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _compteur -= Time.deltaTime;

        if (_compteur < 0.0f)
        {
            RandomCheck();
            _compteur = 5;
        }
    }

    private void RandomCheck()
    {
        if (Random.Range(0, 100) < 35)
            this.gameObject.SetActive(false);
    }
}
