using System.Collections.Generic;

public class PlanetarySystem
{
    private List<PlanetaryObject> _planetaryObjects;

    public PlanetarySystem()
    {
        _planetaryObjects = new List<PlanetaryObject>();
    }

    public void AddPlanet(PlanetaryObject planet)
    {
        _planetaryObjects.Add(planet);
    }

    public IEnumerable<PlanetaryObject> GetPlanets()
    {
        return _planetaryObjects;
    }

    public void UpdateSystem(float deltaTime)
    {
        foreach (PlanetaryObject planetaryObject in _planetaryObjects)
        {
            planetaryObject.UpdatePosition(deltaTime);
        }
    }
}