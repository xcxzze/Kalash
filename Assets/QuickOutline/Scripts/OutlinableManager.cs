using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutlinableManager : MonoBehaviour
{
    [HideInInspector] public List<Outlinable> outlinables;
    private VehicleInfoDeserializer vehicleInfoDeserializer = new();
    private Information info;

    public GameObject vehicleRoot;

    public void Awake()
    {
        info = vehicleInfoDeserializer.DeserializeInformation();

        if (vehicleRoot == null)
        {
            return;
        }

        outlinables = vehicleRoot.GetComponentsInChildren<Outlinable>().ToList();

        foreach (var outlinable in outlinables)
        {
            outlinable.outline = outlinable.GetComponent<Outline>();
            outlinable.color = outlinable.outline.OutlineColor;
            outlinable.outline.enabled = false;
            outlinable.isChangable = true;
            outlinable.isOnceUnchangable = false;

            string childName = outlinable.transform.name;

            if (info.vehicles.ContainsKey(vehicleRoot.name))
            {
                var vehicle = info.vehicles[vehicleRoot.name];
                if (vehicle.parts.ContainsKey(childName))
                {
                    outlinable.info = vehicle.parts[childName];
                }
            }
        }
    }

    public Outlinable FindOutlinableByName(string name)
    {
        return outlinables.FirstOrDefault(q => q.transform.name == name);
    }

    public void SwitchOutline(Outlinable outlinable)
    {
        if (outlinable.isOnceUnchangable)
        {
            outlinable.isOnceUnchangable = false;
            return;
        }
        if (outlinable.isChangable)
        {
            outlinable.outline.enabled = !outlinable.outline.enabled;
        }
    }
}