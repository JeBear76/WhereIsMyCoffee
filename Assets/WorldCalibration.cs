using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WorldCalibration : MonoBehaviour
{
    public Camera cam;
    public GameObject calibrator;
    public GameObject worldReference;

    void Update()
    {
        var screenCenter = cam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        Ray ray = cam.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hitInfo)
            && hitInfo.collider is not null
            && hitInfo.distance < 0.4f 
            && hitInfo.distance > 0.5f)
        {            
            ARSessionOrigin sessionOrigin = FindObjectOfType<ARSessionOrigin>();
            sessionOrigin.transform.position = worldReference.transform.position;
        }
        
    }
}
