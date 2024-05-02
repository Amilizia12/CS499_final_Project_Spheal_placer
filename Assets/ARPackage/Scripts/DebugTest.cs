using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        number = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (number >=0)
        {
            Debug.Log("In DebugTest Update, count = " + number);
            DoSomething();
            number -= 1;  // reduce number by one
            Debug.Log("At end of DebugTest Update, count = " + number);
        }
    }

    private void DoSomething()
    {
        Debug.Log("In DebugTest DoSomething, count = " + number);
        number = -1;
    }
}
