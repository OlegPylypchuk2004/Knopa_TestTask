using UnityEngine;

public class PlanetaryObject
{
    public PlanetaryObjectData Data { get; private set; }

    private float _orbitAngle;

    public PlanetaryObject(PlanetaryObjectData planetaryObjectData)
    {
        Data = planetaryObjectData;
    }

    public void UpdatePosition(float deltaTime)
    {
        _orbitAngle += Data.OrbitSpeed * deltaTime;
        float x = Data.OrbitCenter.x + Mathf.Cos(_orbitAngle) * Data.OrbitRadius;
        float z = Data.OrbitCenter.z + Mathf.Sin(_orbitAngle) * Data.OrbitRadius;
        Data.ViewTransform.localPosition = new Vector3(x, 0, z);
    }
}