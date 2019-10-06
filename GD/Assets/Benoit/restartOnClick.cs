using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartOnClick : MonoBehaviour
{
	public GameObject foodContainer;
	public GameObject player;
	public Canvas gameOverMenu;
	public Canvas pauseMenu;
	public int repartitionSize;
	
    // Start is called before the first frame update
    public void doRestartGame()
	{
        SceneManager.LoadScene("MainScene");
        //Component[] foodComponents = foodContainer.GetComponentsInChildren<Component>(true);
        //foreach (Component foodElement in foodComponents)
        //{
        //    player.transform.position = new Vector3(0, 1, 0);
        //    foodElement.gameObject.SetActive(true);
        //    float x = Random.Range(-repartitionSize, repartitionSize);
        //    float z = Random.Range(-repartitionSize, repartitionSize);
        //    Vector3 pos = new Vector3(x, 1, z);
        //    foodElement.gameObject.transform.position = pos;
        //    pauseMenu.gameObject.SetActive(false);
        //    gameOverMenu.gameObject.SetActive(false);
        //}
    }
}
