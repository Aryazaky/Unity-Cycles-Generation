using Examples;
using Scriptables;
using UnityEngine;

namespace CyclesGen.Examples
{
    [CreateAssetMenu(fileName = "New City Map Rule", menuName = "CyclesGen/Examples/City Map Rule", order = 0)]
    public class CityMapRule : RuleScriptableBase<CityMap, Road, Place, string>
    {
        
    }
}