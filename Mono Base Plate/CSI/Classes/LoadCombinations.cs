using System.Collections.Generic;
using Mono_Base_Plate.CSI.Enums;
using Mono_Base_Plate.CSI.Structs;

namespace Mono_Base_Plate.CSI.Classes
{
    public class LoadCombinations
    {
        public string Name;
        public CombinationTypes CombinationType;

        public List<LoadCombinationItems> Items = new List<LoadCombinationItems>();

    }
}
