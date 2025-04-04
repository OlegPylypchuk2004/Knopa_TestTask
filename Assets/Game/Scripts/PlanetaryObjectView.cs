using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour
{
    [SerializeField, Range(0.25f, 2.5f)] private float _radiusCoef;
    [SerializeField] private MeshRenderer _meshRenderer;

    private IPlaneteryObject _planetaryObject;

    public void Initialize(IPlaneteryObject planetaryObject)
    {
        _planetaryObject = planetaryObject;
        transform.localScale = Vector3.one * _planetaryObject.Radius * _radiusCoef;

        _meshRenderer.material.color = Color.white;
    }
}