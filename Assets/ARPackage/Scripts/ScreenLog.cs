using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenLog : MonoBehaviour
{
	public TextMeshProUGUI logText;
	public static ScreenLog Instance {get; private set;}

	void Awake()
	{
		if (!Instance)
			Instance = this;
	}

	private void Start()
	{
		logText.text = "";
	}

	private void _log(string msg)
	{
		if (logText)
			logText.text += msg + "\n";
	}

	public static void Log(string msg)
	{
		if (Instance)
			Instance._log(msg);
		Debug.Log(msg);
	}
}
