using UnityEngine;
using System.Collections;

public class Timer
{
	//public int importance;
	public float timerTime; //The time until the timer ends
	public float timerCounter; //The counter that counts until the timer ends

	//This method is used for counting. It should be called every frame.
	public void UpdateTimer()
	{
		if(timerTime > 0) //If you need to count
		{
			if(timerCounter < timerTime)
			{
				timerCounter += Time.deltaTime;
			}
			else
			{
				//Stop counting
				timerTime = 0;
				timerCounter = 0;
			}
		}
	}

	//A method to check if the timer is still counting
	public bool CheckEnd()
	{
		if(timerTime == 0)
			return true;
		return false;
	}
}
