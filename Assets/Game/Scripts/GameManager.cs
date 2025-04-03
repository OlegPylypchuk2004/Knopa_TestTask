using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _totalSystemMass;
    [SerializeField] private int _planetsCount;

    private PlanetarySystem _planetarySystem;
    private PlanetaryObjectFactory _planetaryObjectFactory;
    private PlanetaryFactory _planetaryFactory;

    private void Start()
    {
        _planetaryObjectFactory = new PlanetaryObjectFactory();
        _planetaryFactory = new PlanetaryFactory(_planetaryObjectFactory);

        CreatePlanetarySystem();
    }

    private void Update()
    {
        if (_planetarySystem != null)
        {
            _planetarySystem.UpdateSystem(Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        if (_planetarySystem == null || _planetarySystem.GetPlanets().Count() <= 0)
        {
            return;
        }

        foreach (PlanetaryObject planetaryObject in _planetarySystem.GetPlanets())
        {
            Gizmos.color = planetaryObject.Data.MassSpecification.PlanetaryObjectColor;
            Gizmos.DrawWireSphere(planetaryObject.Data.OrbitCenter, planetaryObject.Data.OrbitRadius);
        }
    }

    private void CreatePlanetarySystem()
    {
        Transform parent = new GameObject("PlanetarySystem").transform;
        _planetarySystem = _planetaryFactory.Generate(_totalSystemMass, parent, _planetsCount);
    }
}