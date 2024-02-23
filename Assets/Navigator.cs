using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Navigator : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;

    Transform startPoint;
    public Transform endPoint;
    NavMeshPath path;

    float elapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        elapsed = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        startPoint = cam.transform;
        
        elapsed += Time.deltaTime;
        if(elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(startPoint.position, endPoint.position, NavMesh.AllAreas, path);
        }
        
        lineRenderer.positionCount = path.corners.Length;
        IEnumerable<Vector3> pathRoute = path.corners.Select(v => v + Vector3.up);
        lineRenderer.SetPositions(pathRoute.ToArray());
    }
}
