using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphealChange : MonoBehaviour
{
  PlaceObjectOnPlane manager;
    // Start is called before the first frame update
    void Start()
    {
      manager = GetComponent<PlaceObjectOnPlane>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void rotate() {
      manager.spawnedObject  = null; 
    }
   public void shrink() {
      manager.spawnedObject.transform.localScale *= 0.5f;


    }
   public void grow() {
      manager.spawnedObject.transform.localScale *= 2f;

    }
}
