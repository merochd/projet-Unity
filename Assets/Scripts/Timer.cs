using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI timerText;
	public bool GameEnd = false;
	float elapsedTime;
    void Update()
    {
		if(GameEnd == false)
		{
        	elapsedTime += Time.deltaTime;
	        // on met a jour le temps ecoulé
        	int minutes = Mathf.FloorToInt(elapsedTime/60);
        	int seconds = Mathf.FloorToInt(elapsedTime%60);
	        // on le fait passer au format min + secondes
        	timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	        // on l'affiche
		}
    }

	public void StopTimer()
	{
		GameEnd = true;
		// on arrete la boucle qui met a jour le timer
	}
}
