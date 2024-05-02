using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphealChange : MonoBehaviour
{
  PlaceObjectOnPlane manager;
    int spinCount = 4;
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
      manager.spawnedObject.transform.rotation *= Quaternion.AngleAxis(90, Vector3.up);

    }
   public void shrink() {
      manager.spawnedObject.transform.localScale *= 0.5f;
     }
    public void spin() {
          spinCount = 4;
          Invoke("RoundRotate",1f);

    }

   void RoundRotate() {
     spinCount--;
     if(spinCount >= 0 ) {
        rotate();
        Invoke("RoundRotate",0.4f);
     }
   }
   public void grow() {
      manager.spawnedObject.transform.localScale *= 2f;

    }
}
