using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour
{
    [SerializeField, Range(0.25f, 2.5f)] private float _radiusCoef;
    [SerializeField] private MeshRenderer _meshRenderer;

    private IPlaneteryObject _planetaryObject;

    public void Initialize(IPlaneteryObject planetaryObject)
    {
        _planetaryObject = planetaryObject;

        //double radius = _planetaryObject.MassClassEnum.MinRadius + (_planetaryObject.MassClassEnum.MaxRadius - _planetaryObject.MassClassEnum.MinRadius) * new System.Random().NextDouble();
        //transform.localScale = Vector3.one * (float)(radius * _radiusCoef);

        //_meshRenderer.material.color = planetaryObject.MassClassEnum.PlanetaryObjectColor;
    }
}