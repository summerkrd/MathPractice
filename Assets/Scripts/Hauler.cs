using UnityEngine;

public class Hauler : MonoBehaviour
{
    [SerializeField] private GameObject _explodeEffectPrefab;

    private Camera _mainCamera;
    private Raycaster _raycaster;
    private Explode _explode;
    private RaycastHit _hit;
    private Imoveable _moveable;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _raycaster = new Raycaster();
        _explode = new Explode();
    }

    private void Update()
    {
        if (_raycaster.ShootRayFromCamera(_mainCamera, out _hit))
        {
            DragDrop();

            SomeExplode();
        }
    }

    private void DragDrop()
    {
        if (_hit.collider.TryGetComponent<Imoveable>(out _moveable))
        {
            if (Input.GetMouseButton(0))
            {
                _moveable.MoveObject(_mainCamera);
            }
        }
    }

    private void SomeExplode()
    {
        if (_hit.collider.GetComponent<Ground>() && Input.GetMouseButton(1))
        {
            var effect = Instantiate(_explodeEffectPrefab, _hit.point, Quaternion.identity);
            Destroy(effect, 2);

            _explode.DoExplode(_hit.point);
        }
    }
}
