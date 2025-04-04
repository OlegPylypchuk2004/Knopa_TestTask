using System;

public interface IPlaneteryObjectFactory
{
    public event Action<IPlaneteryObject, PlaneteryObjectView> ObjectCreated;

    public IPlaneteryObject CreateObject(double mass);
}