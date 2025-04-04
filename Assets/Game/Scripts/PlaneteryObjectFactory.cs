using UnityEngine;

public class PlaneteryObjectFactory
{
    private PlaneteryObjectView _planeteryObjectViewPrefab;

    public PlaneteryObjectFactory()
    {
        _planeteryObjectViewPrefab = Resources.Load<PlaneteryObjectView>("Prefabs/PlaneteryObjectView");
    }

    public IPlaneteryObject CreateObject(double mass)
    {
        PlaneteryObjectView planeteryObjectView = SpawnPlaneteryObjectView();
        IPlaneteryObject planeteryObject = new PlaneteryObject(mass, planeteryObjectView.transform);
        planeteryObjectView.Initialize(planeteryObject);

        return planeteryObject;
    }

    private PlaneteryObjectView SpawnPlaneteryObjectView()
    {
        return GameObject.Instantiate(_planeteryObjectViewPrefab);
    }
}