using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AddPictureMode : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycaster;
    [SerializeField] GameObject placedPrefab;
    [SerializeField] float defaultScale = 0.5f;
    public ImageInfo imageInfo;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void OnEnable()
    {
        UIController.ShowUI("AddPicture");
    }

    public void OnPlaceObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        PlaceObject(touchPosition);
    }

    void PlaceObject(Vector2 touchPosition)
    {
        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            ARRaycastHit hit = hits[0];

            Vector3 position = hit.pose.position;
            Vector3 normal = -hit.pose.right;
            // Quaternion rotation = hit.pose.rotation;
            ScreenLog.Log("normal: " + normal);
            Quaternion rotation = Quaternion.LookRotation(normal, Vector3.up);

            GameObject spawned = Instantiate(placedPrefab, position, rotation);
            // spawned.transform.SetParent( transform.Parent );

            FramedPhoto picture = spawned.GetComponent<FramedPhoto>();
            picture.SetImage(imageInfo);

            spawned.transform.localScale = new Vector3(defaultScale, defaultScale, 1.0f);

            // Pose hitPose = hits[0].pose;
            // Instantiate(placedPrefab, hitPose.position, hitPose.rotation);

            ScreenLog.Log("Changing to Main Mode...");
            InteractionController.EnableMode("Main");
        }
    }
}
