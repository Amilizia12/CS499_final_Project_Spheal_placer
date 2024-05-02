using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class InteractionModeDictionary : SerializableDictionaryBase<string, GameObject> { }

public class InteractionController : Singleton<InteractionController>
{
    [SerializeField] InteractionModeDictionary interactionModes;

    GameObject currentMode;

    protected override void Awake()
    {
        base.Awake();
        ResetAllModes();
    }

    void Start()
    {
        _EnableMode("Startup");
    }

    public static void EnableMode(string name)
    {
        Instance?._EnableMode(name);
    }

    void _EnableMode(string name)
    {
        GameObject modeObject;
        ScreenLog.Log("mode: " + name);
        if (interactionModes.TryGetValue(name, out modeObject))
        {
            StartCoroutine(ChangeMode(modeObject));
        }
        else
        {
            ScreenLog.Log("undefined mode named " + name);
        }
    }

    void ResetAllModes()
    {
        foreach (GameObject mode in interactionModes.Values)
        {
            mode.SetActive(false);
        }
    }

    IEnumerator ChangeMode(GameObject mode)
    {
        if (mode == currentMode)
            yield break;

        if (currentMode)
        {
            currentMode.SetActive(false);
            yield return null;
        }

        currentMode = mode;
        ScreenLog.Log("Successfully changed to mode: " + mode.name);
        mode.SetActive(true);
    }

}
