using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _totalSystemMass;
    [SerializeField] private int _planetsCount;

    private PlanetarySystem _planetarySystem;
    private PlanetaryObjectFactory _planetaryObjectFactory;
    private PlanetaryFactory _planetaryFactory;
    private GameObject _systemView;

    private void Start()
    {
        _planetaryObjectFactory = new PlanetaryObjectFactory();
        _planetaryFactory = new PlanetaryFactory(_planetaryObjectFactory);

        GeneratePlanetarySystem();
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

    public void GeneratePlanetarySystem()
    {
        if (_systemView != null)
        {
            Destroy(_systemView.gameObject);
        }

        _systemView = new GameObject("PlanetarySystem");
        _planetarySystem = _planetaryFactory.Generate(_totalSystemMass, _systemView.transform, _planetsCount);
    }
}