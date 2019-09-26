using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dayNight : MonoBehaviour
{
    public float timeForOneCycleInS = 60f;
    int nbDay = 0;
    float time;
    float x;
    float speed;

    public Slider sleepSlider;
    public Slider foodSlider;
    public Light sun;
    public Light moon;
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
			if (Time.time >= time + (1 / speed * 0.2f))
			{
				sun.transform.Rotate(new Vector3(0.2f, 0, 0));
                moon.transform.Rotate(new Vector3(0.2f, 0, 0));
                time = Time.time;
				x += 0.2f;
				if (x >= 360)
				{
					x = 0;
					nbDay++;
					decreaseSleep();
					if (nbDay == sleepSlider.maxValue)
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
        sleepSlider.value = sleepSlider.value - 1;
    }

    public void resetLvl()
    {
        sun.transform.SetPositionAndRotation(new Vector3(0, 3, 0), Quaternion.Euler(10f, -95f, 0f));
        moon.transform.SetPositionAndRotation(new Vector3(0, 3, 0), Quaternion.Euler(190f, -95f, 0f));
        sleepSlider.value = sleepSlider.maxValue;
        foodSlider.value = 0;
        nbDay = 0;
        x = 0;
    }

    public void needMoreFoodOnSLider(int newValueFood)
    {
        foodSlider.maxValue = newValueFood;
    }
}
