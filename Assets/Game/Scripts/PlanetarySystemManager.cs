using System.Linq;
using UnityEngine;

public class PlanetarySystemManager : MonoBehaviour
{
    [SerializeField] private float _totalSystemMass;
    [SerializeField] private int _planetsCount;

    private IPlaneterySystem _planetarySystem;
    private PlanetaryObjectFactory _planetaryObjectFactory;
    private IPlanetarySystemFactory _planetaryFactory;

    private void Start()
    {
        _planetaryObjectFactory = new PlanetaryObjectFactory();
        _planetaryFactory = new PlanetarySystemFactory(_planetaryObjectFactory);

        GeneratePlanetarySystem();
    }

    private void Update()
    {
        if (_planetarySystem != null)
        {
            _planetarySystem.Update(Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        if (_planetarySystem == null || _planetarySystem.PlaneteryObjects.Count() <= 0)
        {
            return;
        }

        foreach (PlanetaryObject planetaryObject in _planetarySystem.PlaneteryObjects)
        {
            //Gizmos.color = planetaryObject.MassSpecificationData.PlanetaryObjectColor;
            //Gizmos.DrawWireSphere(planetaryObject.Data.OrbitCenter, planetaryObject.Data.OrbitRadius);
        }
    }

    public void GeneratePlanetarySystem()
    {
        if (_planetarySystem != null)
        {
            foreach (Transform childTransform in transform)
            {
                Destroy(childTransform.gameObject);
            }
        }

        _planetarySystem = _planetaryFactory.Create(_totalSystemMass);
    }
}