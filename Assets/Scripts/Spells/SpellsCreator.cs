using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpellsCreator : EditorWindow
{
    string spellName, description;

    Sprite icon;

    string[] types = {"Attack", "Treat", "Invocation"};

    int damages, health, type;

    bool zone, stopPlayerWhenCasting, divideDamages, divideHealth;

    float radius, castTime, rechargeTime;

    GameObject prefab, particleEffect;

    Animation playerAnimLoading, playerAnimLauching;

	GameObject spellObject; //Will be null only if this spell wasn't created yet

    [MenuItem("Window/Spells Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SpellsCreator));
    }

    void OnGUI()
    {
		EditorGUILayout.Separator();	
		EditorGUILayout.LabelField("Editing existing asset: "+(spellObject != null));
        EditorGUILayout.Separator();
        spellName = EditorGUILayout.TextField("Name", spellName);
        EditorGUILayout.Separator();
        description = EditorGUILayout.TextField("Description", description);
        EditorGUILayout.Separator();
        icon = (Sprite)EditorGUILayout.ObjectField("Icon", icon, typeof(Sprite), false);
        EditorGUILayout.Separator();
        
        type = EditorGUILayout.Popup("Type", type, types);

        EditorGUI.indentLevel++;
        switch (type)
        {
            case 0:
                damages = EditorGUILayout.IntField("Damages", damages);
                break;
            case 1:
                health = EditorGUILayout.IntField("Health", health);
                break;
            case 2:
                prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false);
                break;
        }
        EditorGUI.indentLevel--;

        EditorGUILayout.Separator();
        if(zone = EditorGUILayout.Toggle("Zone", zone))
        {
            EditorGUI.indentLevel++;
            radius = EditorGUILayout.FloatField("Radius", radius);
            if(type == 0)
            {
                divideDamages = EditorGUILayout.Toggle("Divide Damages", divideDamages);
            }
            else if(type == 1)
            {
                divideHealth = EditorGUILayout.Toggle("Divide Health", divideHealth);
            }
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.Separator();
        castTime = EditorGUILayout.FloatField("Cast Time", castTime);
        rechargeTime = EditorGUILayout.FloatField("Recharge Time", rechargeTime);
        EditorGUILayout.Separator();
        stopPlayerWhenCasting = EditorGUILayout.Toggle("Stop player when casting", stopPlayerWhenCasting);
        EditorGUILayout.Separator();
        particleEffect = (GameObject)EditorGUILayout.ObjectField("Particle Effect", particleEffect, typeof(GameObject), false);
        EditorGUILayout.Separator();
        EditorGUILayout.PrefixLabel("Player Animations");
        EditorGUI.indentLevel++;
        playerAnimLoading = (Animation)EditorGUILayout.ObjectField("Loading", playerAnimLoading, typeof(Animation), false);
        playerAnimLauching = (Animation)EditorGUILayout.ObjectField("Launching", playerAnimLauching, typeof(Animation), false);
        EditorGUI.indentLevel--;
        GUILayout.Space(50);

        if (GUILayout.Button("Save"))
        {
			SaveSpell();
		}
		if (GUILayout.Button("New Spell Template"))
		{
			NewSpell();
		}
		if (GUILayout.Button("Load Spell Template"))
		{
			LoadSpell();
		}
    }

	private void LoadSpell()
	{
		string absPath = EditorUtility.OpenFilePanel("Select Spell Template ","Assets/Prefabs/Spells/", "");
		if(absPath.StartsWith(Application.dataPath))
		{
			string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
			GameObject tempSpell = AssetDatabase.LoadAssetAtPath(relPath, typeof (GameObject)) as GameObject;
			SpellTemplate spellt = tempSpell.GetComponent<SpellTemplate>();
			if(spellt != null)
			{
				//TODO: add divideHealth, and stopPlayerWhenCasting
				spellObject = tempSpell;
				spellName = spellt.spellName;
				description = spellt.description;
				icon = spellt.icon;
				type = spellt.type;
				damages = spellt.damages;
				health = spellt.health;
				zone = spellt.zone;
				divideDamages = spellt.divideDamages;
				radius = spellt.radius;
				castTime = spellt.castTime;
				rechargeTime = spellt.rechargeTime;
				prefab = spellt.prefab;
				particleEffect = spellt.particleEffect;
				playerAnimLoading = spellt.loading;
				playerAnimLauching = spellt.launching;
			}
			else
			{
				Debug.LogError("Selected prefab didn't have a 'spell template' script attached to them");
			}
		}
	}

	private void NewSpell()
	{
		//New spell
		spellObject = null;
		//Resetting editor
		spellName = "";
		description = "";
		icon = null;
		type = 0;
		damages = 0;
		health = 0;
		zone = false;
		divideHealth = false;
		divideDamages = false;
		radius = 0.0f;
		castTime = 0.0f;
		rechargeTime = 0.0f;
		stopPlayerWhenCasting = false;
		prefab = null;
		particleEffect = null;
		playerAnimLoading = null;
		playerAnimLauching = null;
	}

	private void SaveSpell()
	{
		if(spellObject == null)
		{
			Debug.Log("Creating this as a new spell since it was never saved before");
			CreateSpell();
		}
		else
		{
			if(spellObject.name != spellName)
			{
				string relPath = AssetDatabase.GetAssetPath(spellObject);
				AssetDatabase.RenameAsset(relPath, spellName);
			}
			Debug.Log("Saving spell!");
			GameObject tempSpell = spellObject;
			tempSpell.GetComponent<SpellTemplate>().spellName = spellName;
			tempSpell.GetComponent<SpellTemplate>().description = description;
			tempSpell.GetComponent<SpellTemplate>().icon = icon;
			tempSpell.GetComponent<SpellTemplate>().type = type;
			switch(type)
			{
			case 0:
				tempSpell.GetComponent<SpellTemplate>().damages = damages;
				break;
			case 1:
				tempSpell.GetComponent<SpellTemplate>().health = health;
				break;
			case 2:
				tempSpell.GetComponent<SpellTemplate>().prefab = prefab;
				break;
			}
			tempSpell.GetComponent<SpellTemplate>().zone = zone;
			if(zone)
			{
				tempSpell.GetComponent<SpellTemplate>().radius = radius;
				tempSpell.GetComponent<SpellTemplate>().divideDamages = divideDamages;
			}
			tempSpell.GetComponent<SpellTemplate>().castTime = castTime;
			tempSpell.GetComponent<SpellTemplate>().rechargeTime = rechargeTime;
			tempSpell.GetComponent<SpellTemplate>().particleEffect = particleEffect;
			tempSpell.GetComponent<SpellTemplate>().loading = playerAnimLoading;
			tempSpell.GetComponent<SpellTemplate>().launching = playerAnimLauching;
		}
	}

	private void CreateSpell()
	{
		GameObject tempSpell = new GameObject();
		tempSpell.AddComponent<SpellTemplate>();
		tempSpell.GetComponent<SpellTemplate>().spellName = spellName;
		tempSpell.GetComponent<SpellTemplate>().description = description;
		tempSpell.GetComponent<SpellTemplate>().icon = icon;
		tempSpell.GetComponent<SpellTemplate>().type = type;
		switch(type)
		{
		case 0:
			tempSpell.GetComponent<SpellTemplate>().damages = damages;
			break;
		case 1:
			tempSpell.GetComponent<SpellTemplate>().health = health;
			break;
		case 2:
			tempSpell.GetComponent<SpellTemplate>().prefab = prefab;
			break;
		}
		tempSpell.GetComponent<SpellTemplate>().zone = zone;
		if(zone)
		{
			tempSpell.GetComponent<SpellTemplate>().radius = radius;
			tempSpell.GetComponent<SpellTemplate>().divideDamages = divideDamages;
		}
		tempSpell.GetComponent<SpellTemplate>().castTime = castTime;
		tempSpell.GetComponent<SpellTemplate>().rechargeTime = rechargeTime;
		tempSpell.GetComponent<SpellTemplate>().particleEffect = particleEffect;
		tempSpell.GetComponent<SpellTemplate>().loading = playerAnimLoading;
		tempSpell.GetComponent<SpellTemplate>().launching = playerAnimLauching;

		GameObject newSpell = PrefabUtility.CreatePrefab("Assets/Prefabs/Spells/" + spellName + ".prefab", tempSpell);
		//string relPath = AssetDatabase.GetAssetPath(newSpell);
		spellObject = newSpell;
		DestroyImmediate(tempSpell);
	}
}
