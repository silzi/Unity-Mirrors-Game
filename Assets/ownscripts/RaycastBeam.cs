using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBeam : MonoBehaviour
{
    public LayerMask layerMask;
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 inDirection;
    public List<Transform> mirrors;
    public List<Vector3> hitPoints;
    public int nReflections = 2;
    public Shader lineShader;


    void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        hitPoints = new List<Vector3>();
    }

    void Start()
    {
        lineRenderer.material = new Material(lineShader);
        lineRenderer.startColor = new Color(1f, 1f, 0.03f, 0.5f);
        lineRenderer.endColor = new Color(1f, 1f, 1f, 0.5f);
        lineRenderer.startWidth = 0.9f;
        lineRenderer.endWidth = 0.2f;
    }

    void Update()
    {
        nReflections = Mathf.Clamp(nReflections, 1, nReflections);
        ray = new Ray(transform.position, transform.forward);

        // Clear all the linerenderer positions
        hitPoints.Clear();

        // Add the initial ray to the linerenderer
        hitPoints.Add(transform.position);

 

        RayManager.rayManager.RemoveReflections();

        for (int i = 0; i <= nReflections; i++)
        {
            //If no ray reflect 
            if (i == 0)
            {
                //Check ray hits  
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 20, layerMask))
                {
                    // Calculate reflection direction
                    inDirection = Vector3.Reflect(ray.direction, hit.normal);

                    // Construct the new ray based on the direction and hit point of the previous one
                    ray = new Ray(hit.point, inDirection);

                   

                    // Ray hits the object
                    RayManager.rayManager.RayReflected(hit.transform);
                    hitPoints.Add(hit.point);
                }
            }
            else // Ray has reflected 
            {
                //Check ray hits 
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 20, layerMask))
                {
                    inDirection = Vector3.Reflect(inDirection, hit.normal);

                    ray = new Ray(hit.point, inDirection);

                   

                    // Ray hits the object
                    RayManager.rayManager.RayReflected(hit.transform);
                    hitPoints.Add(hit.point);
                }
            }
        }

        // Set linerenderer position count as hitpoint count
        lineRenderer.numPositions = hitPoints.Count;

        for (int r = 0; r < hitPoints.Count; r++)
        {
            lineRenderer.SetPosition(r, hitPoints[r]);
        }
    }
}

