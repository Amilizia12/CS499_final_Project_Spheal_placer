using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageButtons : MonoBehaviour
{
    [SerializeField] GameObject imageButtonPrefab;
    [SerializeField] ImagesData imagesData;
    [SerializeField] AddPictureMode addPicture;

    // Start is called before the first frame update
    void Start()
    {
        for (int idx = transform.childCount - 1; idx >= 0; idx--)
        {
            GameObject.Destroy(transform.GetChild(idx).gameObject);
        }

        foreach (ImageInfo image in imagesData.images)
        {
            GameObject obj = Instantiate(imageButtonPrefab, transform);
            RawImage rawimage = obj.GetComponent<RawImage>();
            rawimage.texture = image.texture;
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick(image));
        }
    }

    void OnClick(ImageInfo image)
    {
        addPicture.imageInfo = image;
        InteractionController.EnableMode("AddPicture");
    }
}
