using UnityEngine;

public class PlanetaryObjectFactory
{
    private PlanetaryObjectView _planetaryObjectViewPrefab;

    public PlanetaryObjectFactory()
    {
        _planetaryObjectViewPrefab = Resources.Load<PlanetaryObjectView>("Prefabs/PlanetaryObjectView");
    }

    public IPlaneteryObject CreateObject(double mass)
    {
        PlanetaryObjectView planetaryObjectView = SpawnPlanetaryObjectView();
        IPlaneteryObject planetaryObject = new PlanetaryObject(mass, planetaryObjectView.transform);
        planetaryObjectView.Initialize(planetaryObject);

        return planetaryObject;
    }

    private PlanetaryObjectView SpawnPlanetaryObjectView()
    {
        return GameObject.Instantiate(_planetaryObjectViewPrefab);
    }
}