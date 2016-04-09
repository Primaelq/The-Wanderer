using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericEntity : MonoBehaviour 
{
	//TODO: think about adding damage
	public float health;
	public float maxHealth;
	public float baseSpeed;
	public float currentSpeed;

	[HideInInspector]
	public bool canAttack = true;

	BoolTimer canAttackTimer;
	List<FloatTimer> slowTimer;
	FloatTimer stunTimer;

	//Use a single one for effects that don't stack (for an instance, bools) and a list of them for affects that do

	//Non-Stacking timers:
	//Display in bar: timerName.timerCounter / timerName.timerTime

	//Stacking timers:
	//Display in bar: counterTime of the timer with biggest timerName.timerTime / timerTimer ofF the timer with biggest timerName.timerTime;
	//Even though it would seem like it's just a new effect in the bar, the effects could still stack

	//NOTE: when I say stacking status effects, I mean effects that start their value stacks, not that their overall time stacks. 
	//Meaning, that a stacking 'slow' effect would make the player slower and continue until the newest time it was casted. 
	//I do not mean it would start once the current effect ends.

	//Use a single timer for effects that stack, use a List<> of timers for effects that do.

	void Start()
	{
		canAttackTimer = new BoolTimer();
		slowTimer = new List<FloatTimer>();
	}

	void Update()
	{
		//Non-Stacking timers:
		canAttackTimer.UpdateTimer();
		//Stacking timers:
		currentSpeed = UpdateStackingSlowTimer(slowTimer, baseSpeed);
		stunTimer.UpdateTimer;
		if(stunTimer.timerTime > 0)
		{
			currentSpeed = 0;
		}

	}

	//Example method for using slow-timers
	private float UpdateStackingSlowTimer(List<FloatTimer> stackTimer, float speed)
	{
		List<FloatTimer> timersToRemove;

		foreach(FloatTimer timer in stackTimer)
		{
			speed = speed / timer.value;
			timer.UpdateTimer();
			if(timer.CheckEnd())
			{
				timersToRemove.Add(timer);
			}
		}

		foreach(FloatTimer timer in timersToRemove)
		{
			stackTimer.Remove(timer);
		}

		return speed;
	}

}
