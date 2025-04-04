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
        Vector3 orbitCenter = Vector3.zero;
        float orbitSpeed = Random.Range(0.25f, 1f);
        float orbitRadius = Mathf.Lerp(0.25f, 1f * 25f, orbitSpeed);

        PlanetaryObjectView planetaryObjectView = SpawnPlanetaryObjectView();
        //PlanetaryObjectData planetaryObjectData = new PlanetaryObjectData(orbitCenter, orbitSpeed, orbitRadius, planetaryObjectView.transform);
        IPlaneteryObject planetaryObject = new PlanetaryObject(mass);

        planetaryObjectView.Initialize(planetaryObject);

        return planetaryObject;
    }

    private PlanetaryObjectView SpawnPlanetaryObjectView()
    {
        return GameObject.Instantiate(_planetaryObjectViewPrefab);
    }
}