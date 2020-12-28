using System;
using System.Collections.Generic;
using Database;
using Harmony;
using STRINGS;

namespace Generator
{
    public class GeneratorModPatches
    {
        [HarmonyPatch(typeof(GeneratedBuildings))]
        [HarmonyPatch(nameof(GeneratedBuildings.LoadGeneratedBuildings))]
        public class GeneratedBuildingPatch
        {

            private static string name = UI.FormatAsLink("Generator", GeneratorModConfig.ID);
            
            private static string desc = "This building is a Generator";

            private static string effect = "Generates " + UI.FormatAsLink("Power", "POWER");

            public static void Prefix()
            {
                Debug.Log("Initializing Generator Mod Building");
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{GeneratorModConfig.ID.ToUpper()}.NAME", name);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{GeneratorModConfig.ID.ToUpper()}.DESC", desc);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{GeneratorModConfig.ID.ToUpper()}.EFFECT", effect);
                //Strings.Add(NAME.key.String, NAME.text);
                //Strings.Add(DESC.key.String, DESC.text);
                //Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Power", GeneratorModConfig.ID);
            }
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class GeneratedBuildingDbPatch
        {
            public static void Prefix()
            {
                Debug.Log("Registering Generator Mod Research");

                var techList = new List<string>(Database.Techs.TECH_GROUPING["RenewableEnergy"]);
                techList.Add(GeneratorModConfig.ID);
                Database.Techs.TECH_GROUPING["RenewableEnergy"] = techList.ToArray();
            }
        }
    }
}