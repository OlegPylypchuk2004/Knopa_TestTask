using System.Collections.Generic;

public interface IPlaneterySystem
{
    public IEnumerable<IPlaneteryObject> PlaneteryObjects { get; }
    public void Update(float deltaTime);
    public void AddPlaneteryObject(IPlaneteryObject planet);
}