using System;
using UnityEngine;

public class PlaneteryObjectFactory : IPlaneteryObjectFactory
{
    private PlaneteryObjectView _planeteryObjectViewPrefab;

    public event Action<IPlaneteryObject, PlaneteryObjectView> ObjectCreated;

    public PlaneteryObjectFactory()
    {
        _planeteryObjectViewPrefab = Resources.Load<PlaneteryObjectView>("Prefabs/PlaneteryObjectView");
    }

    public IPlaneteryObject CreateObject(double mass)
    {
        PlaneteryObjectView planeteryObjectView = SpawnPlaneteryObjectView();
        IPlaneteryObject planeteryObject = new PlaneteryObject(mass, planeteryObjectView.transform);
        planeteryObjectView.Initialize(planeteryObject);

        ObjectCreated?.Invoke(planeteryObject, planeteryObjectView);

        return planeteryObject;
    }

    private PlaneteryObjectView SpawnPlaneteryObjectView()
    {
        return GameObject.Instantiate(_planeteryObjectViewPrefab);
    }
}