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

    [MenuItem("Window/Spells Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SpellsCreator));
    }

    void OnGUI()
    {
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
        if (GUILayout.Button("Create"))
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
        }
    }
}
