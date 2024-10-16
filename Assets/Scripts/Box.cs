using UnityEngine;

public class Box : MonoBehaviour, Imoveable, Iexplode
{
    private Raycaster _raycaster;

    private void Awake()
    {
        _raycaster = new Raycaster();
    }

    public void MoveObject(Camera mainCamera)
    {        
        Vector3 point = _raycaster.PlaneRaycast(mainCamera, transform);
        transform.position = new Vector3(point.x, transform.position.y, point.z);
    }
}
