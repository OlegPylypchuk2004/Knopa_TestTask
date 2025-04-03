using UnityEngine;

public class PlanetaryObjectFactory
{
    private MassSpecificationData[] _massSpecificationDatas;
    private PlanetaryObjectView _planetaryObjectViewPrefab;

    public PlanetaryObjectFactory()
    {
        _massSpecificationDatas = Resources.LoadAll<MassSpecificationData>("Data/MassSpecifications");
        _planetaryObjectViewPrefab = Resources.Load<PlanetaryObjectView>("Prefabs/PlanetaryObjectView");
    }

    public PlanetaryObject CreateObject(float mass, Transform parent)
    {
        Vector3 orbitCenter = Vector3.zero;
        float orbitSpeed = Random.Range(0.25f, 1f);
        float orbitRadius = Mathf.Lerp(0.25f, 1f * 25f, orbitSpeed);

        PlanetaryObjectView planetaryObjectView = SpawnPlanetaryObjectView(parent);
        PlanetaryObjectData planetaryObjectData = new PlanetaryObjectData(orbitCenter, orbitSpeed, orbitRadius, planetaryObjectView.transform);
        PlanetaryObject planetaryObject = new PlanetaryObject(mass, DetermineMassSpecificationData(mass), planetaryObjectData);

        planetaryObjectView.Initialize(planetaryObject);

        return planetaryObject;
    }

    private MassSpecificationData DetermineMassSpecificationData(float mass)
    {
        for (int i = 0; i < _massSpecificationDatas.Length; i++)
        {
            if (_massSpecificationDatas[i].MinMass <= mass && _massSpecificationDatas[i].MaxMass >= mass)
            {
                return _massSpecificationDatas[i];
            }
        }

        return null;
    }

    private PlanetaryObjectView SpawnPlanetaryObjectView(Transform parent)
    {
        return GameObject.Instantiate(_planetaryObjectViewPrefab, parent);
    }
}