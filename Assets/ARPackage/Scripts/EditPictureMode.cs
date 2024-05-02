using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditPictureMode : MonoBehaviour
{
    public FramedPhoto currentPicture; 
    Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    public void OnSelectObject( InputValue value )
    {
        Vector2 touchPosition = value.Get<Vector2>();
        FindObjectToEdit( touchPosition );
    }

    void FindObjectToEdit( Vector2 touchPosition )
    {
        Ray ray = camera.ScreenPointToRay( touchPosition );
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer( "PlacedObjects" );
        if ( Physics.Raycast( ray, out hit, 50f, layerMask ) ) {
            if ( hit.collider.gameObject != currentPicture.gameObject ) {
                currentPicture.BeingEdited( false );
                FramedPhoto picture = hit.collider.GetComponentInParent<FramedPhoto>();
                currentPicture = picture;
                picture.BeingEdited( true );
            }
        }
    }

    void OnEnable()
    {
        UIController.ShowUI("EditPicture");
        if ( currentPicture ) {
            currentPicture.BeingEdited( true );
        }
    }

    void OnDisable()
    {
        if ( currentPicture ) {
            currentPicture.BeingEdited( false );
        }
    }

public void DeletePicture()
{
    GameObject.Destroy( currentPicture.gameObject );
    InteractionController.EnableMode( "Main" );
}

}
