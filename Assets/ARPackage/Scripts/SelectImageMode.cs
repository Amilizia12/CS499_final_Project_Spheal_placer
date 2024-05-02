using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectImageMode : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        UIController.ShowUI("SelectImage");
    }
}
