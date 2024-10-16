using UnityEngine;

public class Raycaster
{
    public bool ShootRayFromCamera(Camera mainCamera, out RaycastHit hit)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }

    public Vector3 PlaneRaycast(Camera mainCamera, Transform moveableObject)
    {
        Plane plane = new Plane(Vector3.up, moveableObject.position);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 point = moveableObject.position;

        if (plane.Raycast(ray, out float distance))
        {
            point = ray.GetPoint(distance);               
        }   
        
        return point;
    }
}
