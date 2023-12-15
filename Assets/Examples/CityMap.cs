using Examples;
using Scriptables;
using UnityEngine;

namespace CyclesGen.Examples
{
    [CreateAssetMenu(fileName = "New City Map", menuName = "CyclesGen/Examples/City Map", order = 0)]
    public class CityMap : GraphScriptableBase<Road, Place, string>
    {
        
    }
}