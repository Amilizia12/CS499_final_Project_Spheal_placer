using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour
{

    [ SerializeField ] GameObject placedPrefab;

   public GameObject spawnedObject;
    ARRaycastManager raycaster;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void OnPlaceObject( InputValue value ) {
        Vector2 touchPosition = value.Get<Vector2>();

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
        }
    }

    void Start()
    {
        raycaster = GetComponent<ARRaycastManager>();
    }

}
