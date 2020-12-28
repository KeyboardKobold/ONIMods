using System.Collections.Generic;
using Harmony;
using STRINGS;

namespace FreeEnergyGeneratorMod
{
    public class GeneratorModPatches
    {
        [HarmonyPatch(typeof(GeneratedBuildings))]
        [HarmonyPatch(nameof(GeneratedBuildings.LoadGeneratedBuildings))]
        public class GeneratedBuildingPatch
        {

            private static string name =
                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{DevGeneratorConfig.ID.ToUpper()}.NAME");

            private static string desc =
                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{DevGeneratorConfig.ID.ToUpper()}.DESC");

            private static string effect = Strings.Get($"STRINGS.BUILDINGS.PREFABS.{DevGeneratorConfig.ID.ToUpper()}.EFFECT");

            public static void Prefix()
            {
                Debug.Log("Initializing Generator Mod Building");

                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{GeneratorModConfig.ID.ToUpper()}.NAME", name);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{GeneratorModConfig.ID.ToUpper()}.DESC", desc);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{GeneratorModConfig.ID.ToUpper()}.EFFECT", effect);
                ModUtil.AddBuildingToPlanScreen("Power", GeneratorModConfig.ID);
            }
        }

        /* TODO debate if this should be gated by research -- as a cheat mod I'm not sure if it makes any sense
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
        */
    }
}