using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Test : MonoBehaviour
{
    ///
    private int position;
    private Dictionary<int, PropertyData> propertyData;
    ///

    private void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData == null || propertyData.Count == 0)
        {
            Debug.LogError("propertyData is null or empty.");
            return;
        }

        // Group properties by their Group (colour) field
        // var groupedByColour = propertyData.Values.Where(property => !string.IsNullOrEmpty(property.Group)).GroupBy(property => property.Group).ToDictionary(group => group.Key, group => group.ToArray());

        PropertyData[] brownGroupOwners;
        PropertyData[] blueGroupOwners;
        PropertyData[] purpleGroupOwners;
        PropertyData[] orangeGroupOwners;
        PropertyData[] redGroupOwners;
        PropertyData[] yellowGroupOwners;
        PropertyData[] greenGroupOwners;
        PropertyData[] deepBlueGroupOwners;

        foreach(var property in propertyData) {
            Switch(property.Group) {
                case "brown": 
                    brownGroup.append(property.Owner);
                case "blue":
                    blueGroup.append(property.Owner);
                case "purple":
                    purpleGroup.append(property.Owner);
                case "orange":
                    orangeGroup.append(property.Owner);
                case "red":
                    redGroup.append(property.Owner);
                case "yellow":
                    yellowGroup.append(property.Owner);
                case "green":
                    greenGroup.append(property.Owner);
            }
        }

        // Example: Log each group and its properties
        // foreach (var group in groupedByColour)
        // {
        //     Debug.Log($"Group: {group.Key} - Total: {group.Value.Length}");
        //     foreach (var property in group.Value)
        //     {
        //         Debug.Log($"  - {property.Position}: {property.NameProperty}");
        //         array = Array.Find(groups, g => g.StartsWith(property.Group));
        //         array.append(property.NameProperty)
        //     }
        // }

        List<int> brownGroup = new List<int>();
        List<int> blueGroup = new List<int>();
        List<int> purpleGroup = new List<int>();
        List<int> orangeGroup = new List<int>();
        List<int> redGroup = new List<int>();
        List<int> yellowGroup = new List<int>();
        List<int> greenGroup = new List<int>();
        List<int> deepBlueGroup = new List<int>();

        foreach(var property in propertyData) {
            switch(property.Group) {
                case "Brown": 
                    brownGroup.Add(property.Position);
                case "Blue":
                    blueGroup.Add(property.Position);
                case "Purple":
                    purpleGroup.Add(property.Position);
                case "Orange":
                    orangeGroup.Add(property.Position);
                case "Red":
                    redGroup.Add(property.Position);
                case "Yellow":
                    yellowGroup.Add(property.Position);
                case "Green":
                    greenGroup.Add(property.Position);
                case "Deep blue":
                    deepBlueGroup.Add(property.Position);
            }
        }

        Dictionary<string, List<int>> colourPositions = new Dictionary<string, List<int>>() {
            {"Brown", brownGroup},
            {"Blue", blueGroup},
            {"Purple", purpleGroup},
            {"Orange", orangeGroup},
            {"Red", redGroup},
            {"Yellow", yellowGroup},
            {"Green", greengroup},
            {"Deep blue", deepBlueGroup}
        };
        // var sampleProperty = propertyData[1];
        // if (colourPositions.TryGetValue(sampleProperty.Group, out List<int> positions)) {
        //      Debug.Log($"Positions in {sampleProperty.Group} group: {string.Join(", ", positions)}");
        // }

        // property blueGroup[] = blueGroup.append(property.NameProperty)

        // OPTIONAL: If you want to use arrays for each color later
        // PropertyData[] brownGroup = groupedByColour.ContainsKey("Brown") ? groupedByColour["Brown"] : new PropertyData[0];
        // PropertyData[] blueGroup = groupedByColour.ContainsKey("Blue") ? groupedByColour["Blue"] : new PropertyData[0];
        // PropertyData[] purpleGroup = groupedByColour.ContainsKey("Purple") ? groupedByColour["Purple"] : new PropertyData[0];
        // PropertyData[] orangeGroup = groupedByColour.ContainsKey("Orange") ? groupedByColour["Orange"] : new PropertyData[0];
        // PropertyData[] redGroup = groupedByColour.ContainsKey("Red") ? groupedByColour["Red"] : new PropertyData[0];
        // PropertyData[] yellowGroup = groupedByColour.ContainsKey("Yellow") ? groupedByColour["Yellow"] : new PropertyData[0];
        // PropertyData[] greenGroup = groupedByColour.ContainsKey("Green") ? groupedByColour["Green"] : new PropertyData[0];
        // PropertyData[] deepBlueGroup = groupedByColour.ContainsKey("Deep blue") ? groupedByColour["Deep blue"] : new PropertyData[0];
        
        // // And so on...
        // foreach (var property in brownGroup) {
        //     Debug.Log($"Name: {property.NameProperty} - Position: {property.Position} - Group: {property.Group}");
        // }

        // foreach (var property in blueGroup) {
        //     Debug.Log($"Name: {property.NameProperty} - Position: {property.Position} - Group: {property.Group}");
        // }

        // foreach (var property in greenGroup) {
        //     Debug.Log($"Name: {property.NameProperty} - Position: {property.Position} - Group: {property.Group}");
        // }
    }


}
