using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private PlanetaryObject _planetaryObject;

    public void Initialize(PlanetaryObject planetaryObject)
    {
        _planetaryObject = planetaryObject;
        _meshRenderer.material.color = planetaryObject.MassSpecificationData.PlanetaryObjectColor;
    }
}