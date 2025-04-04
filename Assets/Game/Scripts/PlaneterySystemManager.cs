using System.Linq;
using UnityEngine;

public class PlaneterySystemManager : MonoBehaviour
{
    private IPlaneterySystem _planeterySystem;
    private PlaneteryObjectFactory _planeteryObjectFactory;
    private IPlaneterySystemFactory _planeteryFactory;

    private void Start()
    {
        _planeteryObjectFactory = new PlaneteryObjectFactory();
        _planeteryFactory = new PlaneterySystemFactory(_planeteryObjectFactory);

        GeneratePlaneterySystem();
    }

    private void Update()
    {
        if (_planeterySystem != null)
        {
            _planeterySystem.Update(Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        if (_planeterySystem == null || _planeterySystem.PlaneteryObjects.Count() <= 0)
        {
            return;
        }

        foreach (PlaneteryObject planeteryObject in _planeterySystem.PlaneteryObjects)
        {
            //Gizmos.color = planetaryObject.MassSpecificationData.PlanetaryObjectColor;
            //Gizmos.DrawWireSphere(planetaryObject.Data.OrbitCenter, planetaryObject.Data.OrbitRadius);
        }
    }

    public void GeneratePlaneterySystem()
    {
        if (_planeterySystem != null)
        {
            foreach (Transform childTransform in transform)
            {
                Destroy(childTransform.gameObject);
            }
        }

        float totalSystemMass = Random.Range(5f, 15f);
        _planeterySystem = _planeteryFactory.Create(totalSystemMass);
    }
}