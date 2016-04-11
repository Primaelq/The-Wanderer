using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour 
{
	SpellTemplate template;

	void Start()
	{
		if(template.castTime > 0)
		{

		}
		else
		{
			ExecuteSpell();
		}
	}

	private IEnumerator CastingSpell(float time)
	{
		//Update loading bar
		//Don't allow the player to move(?)/cast anything else while doing this
		float counter = 0;
		while(counter < template.castTime)
		{
			counter+= Time.deltaTime;
			yield return null;
			//Update loading bar
		}
		ExecuteSpell();
	}

	void ExecuteSpell()
	{

	}

}
