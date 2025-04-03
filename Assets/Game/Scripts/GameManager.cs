using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _totalSystemMass;
    [SerializeField] private int _planetsCount;

    private PlanetarySystem _planetarySystem;
    private PlanetaryFactory _factory;

    private void Start()
    {
        _factory = new PlanetaryFactory(Resources.LoadAll<MassSpecificationData>("Data/MassSpecifications"));

        CreatePlanetarySystem();
    }

    private void Update()
    {
        if (_planetarySystem != null)
        {
            _planetarySystem.UpdateSystem(Time.deltaTime);
        }
    }

    private void CreatePlanetarySystem()
    {
        Transform parent = new GameObject("PlanetarySystem").transform;
        _planetarySystem = _factory.Generate(_totalSystemMass, parent, _planetsCount);
    }
}