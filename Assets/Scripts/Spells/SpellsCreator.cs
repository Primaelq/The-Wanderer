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

        //GUILayout.BeginHorizontal();
        type = EditorGUILayout.Popup("Type", type, types);
        //GUILayout.EndHorizontal();

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

        }
    }
}
