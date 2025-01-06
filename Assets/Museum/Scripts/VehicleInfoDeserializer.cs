using Newtonsoft.Json;
using UnityEngine;

public class VehicleInfoDeserializer
{
    public Information DeserializeInformation()
    {
        var jsonTA = Resources.Load("Information") as TextAsset;
        var information = JsonConvert.DeserializeObject<Information>(jsonTA.text);

        return information;
    }
}
