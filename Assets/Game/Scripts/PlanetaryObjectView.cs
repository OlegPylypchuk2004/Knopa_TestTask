using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour
{
    [SerializeField, Range(0.25f, 2.5f)] private float _radiusCoef;
    [SerializeField] private MeshRenderer _meshRenderer;

    private PlanetaryObject _planetaryObject;

    public void Initialize(PlanetaryObject planetaryObject)
    {
        _planetaryObject = planetaryObject;
        transform.localScale = Vector3.one * Random.Range(_planetaryObject.MassSpecificationData.MinRadius, _planetaryObject.MassSpecificationData.MaxRadius) * _radiusCoef;
        _meshRenderer.material.color = planetaryObject.MassSpecificationData.PlanetaryObjectColor;
    }
}