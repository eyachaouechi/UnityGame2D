using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject myPices;
	float currentTime = 0f;
    float startingTime = 60f;
	
	
 public TextMeshProUGUI countdownText; 
	   public GameObject GameOver;
    void Start(){

    pointsToWin = myPices.transform.childCount/2;
		 currentTime = startingTime;
		  countdownText.text = currentTime.ToString("0");

		
    }
    void Update()
{
if (currentPoints >= pointsToWin){
    transform.GetChild(0).gameObject.SetActive(true);
	
}
else if (currentTime.ToString("0") == "0"){
   	GameOver.SetActive(true);
	
}
else {
	
currentTime -= 1 * Time.deltaTime;
 countdownText.text = currentTime.ToString("0");

}
}
public void AddPoints()
{
    currentPoints++;
}
}