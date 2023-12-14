using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public Camera scrollCamera; 

    void Update()
    {
        PlayersList PL = GameObject.FindGameObjectWithTag("Event").GetComponent<PlayersList>();
        Camera currentCamera = scrollCamera != null ? scrollCamera : Camera.main;

        if (PL != null && PL.contentTransform != null && PL.contentRectTransform != null)
        {
            foreach (Transform playerTransform in PL.contentTransform)
            {
                GameObject playerObject = playerTransform.gameObject;
                playerObject.SetActive(IsPlayerVisible(playerObject, PL.contentRectTransform, currentCamera));
            }
        }
    }

    public bool IsPlayerVisible(GameObject playerObject, RectTransform contentRectTransform, Camera camera)
    {
        if (camera == null)
        {
            Debug.LogError("Camera not found.");
            return false;
        }

        Vector3 playerPosition = playerObject.transform.position;
        Vector3 screenPoint = camera.WorldToViewportPoint(playerPosition);

        return screenPoint.y > 0 && screenPoint.y < 1;
    }

    public void DestroyObjectAndParents()
    {
        Transform currentTransform = transform; 
        
        while (currentTransform != null)
        {
            Transform parentTransform = currentTransform.parent;
            Destroy(currentTransform.gameObject);
            currentTransform = parentTransform;
        }
    }
}
