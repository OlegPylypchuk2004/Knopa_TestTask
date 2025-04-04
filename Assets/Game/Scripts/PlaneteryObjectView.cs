using UnityEngine;

public class PlaneteryObjectView : MonoBehaviour
{
    [SerializeField, Range(0.25f, 2.5f)] private float _radiusCoef;
    [SerializeField] private MeshRenderer _meshRenderer;

    private IPlaneteryObject _planeteryObject;
    private float _radius;

    public IPlaneteryObject PlaneteryObject => _planeteryObject;
    public float Radius => _radius;

    public void Initialize(IPlaneteryObject planeteryObject)
    {
        _planeteryObject = planeteryObject;
        _radius = CalculateRadius();
        transform.localScale = Vector3.one * _radius * _radiusCoef;

        _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    private float CalculateRadius()
    {
        switch (_planeteryObject.MassClassEnum)
        {
            case MassClass.Asteroidan: return Random.Range(0f, 0.03f);
            case MassClass.Mercurian: return Random.Range(0.03f, 0.7f);
            case MassClass.Subterran: return Random.Range(0.5f, 1.2f);
            case MassClass.Terran: return Random.Range(0.8f, 1.9f);
            case MassClass.Superterran: return Random.Range(1.3f, 3.3f);
            case MassClass.Neptunian: return Random.Range(2.1f, 5.7f);
            case MassClass.Jovian: return Random.Range(3.5f, 27f);

            default: return 1f;
        }
    }
}