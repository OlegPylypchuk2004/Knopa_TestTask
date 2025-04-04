using UnityEngine;

public class PlaneteryObjectView : MonoBehaviour
{
    [SerializeField, Range(0.25f, 2.5f)] private float _radiusCoef;
    [SerializeField] private MeshRenderer _meshRenderer;

    private IPlaneteryObject _planeteryObject;

    public void Initialize(IPlaneteryObject planeteryObject)
    {
        _planeteryObject = planeteryObject;
        transform.localScale = Vector3.one * _planeteryObject.Radius * _radiusCoef;

        _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}