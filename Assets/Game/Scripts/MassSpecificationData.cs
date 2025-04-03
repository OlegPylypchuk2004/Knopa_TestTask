using UnityEngine;

[CreateAssetMenu(fileName = "MassSpecificationData", menuName = "Data/MassSpecification")]
public class MassSpecificationData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public float MinMass { get; private set; }
    [field: SerializeField] public float MaxMass { get; private set; }
    [field: SerializeField] public float MinRadius { get; private set; }
    [field: SerializeField] public float MaxRadius { get; private set; }
    [field: SerializeField] public Color PlanetaryObjectColor { get; private set; }

    private void OnValidate()
    {
        if (MinMass > MaxMass)
        {
            MaxMass = MinMass;
        }

        if (MinRadius > MaxRadius)
        {
            MaxRadius = MinRadius;
        }
    }
}