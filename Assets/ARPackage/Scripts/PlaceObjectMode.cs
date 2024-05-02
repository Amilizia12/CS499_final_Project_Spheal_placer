using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectMode : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycaster;
    GameObject placedPrefab;
    GameObject spawnedObject;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void OnEnable()
    {
        UIController.ShowUI("PlaceObject");
    }

    public void SetPlacedPrefab(GameObject prefab)
    {
        placedPrefab = prefab;
    }

    public void OnPlaceObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        PlaceObject(touchPosition);
    }

      void PlaceObject( Vector2 touchPosition ) {
            
        if ( raycaster.Raycast( touchPosition, hits, TrackableType.PlaneWithinPolygon ) ) {
            Pose hitPose = hits[ 0 ].pose;

            if ( spawnedObject == null ) {
                spawnedObject = Instantiate( placedPrefab, hitPose.position, hitPose.rotation );
                ScreenLog.Log( "An object was created!" );
            }
            else {
                spawnedObject.transform.SetPositionAndRotation( hitPose.position, hitPose.rotation );
                ScreenLog.Log( "The object was moved..." );
            }
             InteractionController.EnableMode("Main");
        }
    }


}
