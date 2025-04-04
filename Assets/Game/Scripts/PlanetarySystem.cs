using System.Collections.Generic;

public class PlanetarySystem : IPlaneterySystem
{
    private List<IPlaneteryObject> _planetaryObjects;

    public PlanetarySystem()
    {
        _planetaryObjects = new List<IPlaneteryObject>();
    }

    public IEnumerable<IPlaneteryObject> PlaneteryObjects => _planetaryObjects;

    public void AddPlaneteryObject(IPlaneteryObject planet)
    {
        _planetaryObjects.Add(planet);
    }

    public void Update(float deltaTime)
    {
        foreach (PlanetaryObject planetaryObject in _planetaryObjects)
        {
            planetaryObject.UpdatePosition(deltaTime);
        }
    }
}