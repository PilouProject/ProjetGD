using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dayNight : MonoBehaviour
{
    public float timeForOneCycleInS = 60f;
    int nbDay = 0;
    float time;
    int x;
    float speed;

    public Slider sleepSlider;
    public Light sun;
	public Canvas startMenu;
	public Canvas gameOverCanvas;
	public Canvas HUDCanvas;
	
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        x = 0;
        speed = 360 / timeForOneCycleInS;
    }

    // Update is called once per frame
    void Update()
    {
		if (!startMenu.gameObject.activeSelf && !gameOverCanvas.gameObject.activeSelf)
        {
			if (Time.time >= time + (1 / speed))
			{
				sun.transform.Rotate(new Vector3(1, 0, 0));
				time = Time.time;
				x++;
				if (x == 360)
				{
					x = 0;
					nbDay++;
					decreaseSleep();
					if (nbDay == 3)
					{
						gameOverCanvas.gameObject.SetActive(true);
						HUDCanvas.gameObject.SetActive(false);
					}
				}
			}
		}
    }

    void decreaseSleep()
    {
        sleepSlider.value += -1;
    }
}
