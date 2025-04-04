using UnityEngine;

public class PlaneteryObjectCatcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxRayDistance;
    [SerializeField] private LayerMask _itemLayerMask;

    private void Update()
    {
        PlaneteryObjectView planeteryObject = TryGetPlaneteryObject();

        if (planeteryObject != null)
        {
            Debug.Log($"{planeteryObject.PlaneteryObject.MassClassEnum}, with mass: {planeteryObject.PlaneteryObject.Mass}, with radius: {planeteryObject.Radius}");
        }
    }

    public PlaneteryObjectView TryGetPlaneteryObject()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance, _itemLayerMask))
        {
            if (hit.collider.TryGetComponent(out PlaneteryObjectView planeteryObject))
            {
                return planeteryObject;
            }
        }

        return null;
    }
}