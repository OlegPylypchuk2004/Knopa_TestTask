using System.Collections.Generic;

public class PlaneterySystem : IPlaneterySystem
{
    private List<IPlaneteryObject> _planeteryObjects;

    public PlaneterySystem(List<IPlaneteryObject> planeteryObjects)
    {
        _planeteryObjects = planeteryObjects;
    }

    public IEnumerable<IPlaneteryObject> PlaneteryObjects => _planeteryObjects;

    public void Update(float deltaTime)
    {
        foreach (PlanetaryObject planetaryObject in _planeteryObjects)
        {
            planetaryObject.UpdatePosition(deltaTime);
        }
    }
}