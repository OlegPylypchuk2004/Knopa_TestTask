using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneterySystemManager : MonoBehaviour
{
    private IPlaneterySystem _planeterySystem;
    private PlaneteryObjectFactory _planeteryObjectFactory;
    private IPlaneterySystemFactory _planeteryFactory;

    private List<PlaneteryObjectView> _planeteryObjectViews;

    private void Start()
    {
        _planeteryObjectFactory = new PlaneteryObjectFactory();
        _planeteryObjectViews = new List<PlaneteryObjectView>();
        _planeteryObjectFactory.ObjectCreated += OnPlaneteryObjectCreated;

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

    private void OnDestroy()
    {
        _planeteryObjectFactory.ObjectCreated -= OnPlaneteryObjectCreated;
    }

    private void OnDrawGizmos()
    {
        if (_planeterySystem == null || _planeterySystem.PlaneteryObjects.Count() <= 0)
        {
            return;
        }

        foreach (PlaneteryObject planeteryObject in _planeterySystem.PlaneteryObjects)
        {
            Gizmos.DrawWireSphere(planeteryObject.OrbitCenter, planeteryObject.OrbitRadius);
        }
    }

    public void GeneratePlaneterySystem()
    {
        if (_planeteryObjectViews != null && _planeteryObjectViews.Count > 0)
        {
            foreach (PlaneteryObjectView planeteryObjectView in _planeteryObjectViews)
            {
                Destroy(planeteryObjectView.gameObject);
            }

            _planeteryObjectViews.Clear();
        }

        float totalSystemMass = Random.Range(5f, 15f);
        _planeterySystem = _planeteryFactory.Create(totalSystemMass);
    }

    private void OnPlaneteryObjectCreated(IPlaneteryObject planeteryObject, PlaneteryObjectView planeteryObjectView)
    {
        _planeteryObjectViews.Add(planeteryObjectView);
    }
}