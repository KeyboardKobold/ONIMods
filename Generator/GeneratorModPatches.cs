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
        [HarmonyPatch("LoadGeneratedBuildings")]
        public class GeneratedBuildingPatch
        {
            public static LocString NAME = new LocString("Generator",
                "STRINGS.BUILDINGS.PREFABS." + GeneratorModConfig.ID.ToUpper() + ".NAME");

            public static LocString DESC = new LocString("This building is a Generator",
                "STRINGS.BUILDINGS.PREFABS." + GeneratorModConfig.ID.ToUpper() + ".DESC");

            public static LocString EFFECT = new LocString("Generates " + UI.FormatAsLink("Power", "POWER"),
                "STRINGS.BUILDINGS.PREFABS." + GeneratorModConfig.ID.ToUpper() + ".EFFECT");

            public static void Prefix()
            {
                Debug.Log("Initializing Generator Mod Building"); // TODO missing slider tooltip?
                /* STACK HERE
[DebugConsole][1]: Error[Exception]: NullReferenceException: Object reference not set to an instance of an object
EnergyGenerator.ISliderControl.GetSliderTooltip () (at <1c58b1f98f5849baa9083bfd5185b144>:0)
SliderSet.SetTarget (ISliderControl target) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
SingleSliderSideScreen.SetTarget (UnityEngine.GameObject new_target) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
DetailsScreen.<Refresh>b__41_0 (DetailsScreen+SideScreenRef scn) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
System.Collections.Generic.List`1[T].ForEach (System.Action`1[T] action) (at <9577ac7a62ef43179789031239ba8798>:0)
DetailsScreen.Refresh (UnityEngine.GameObject go) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
RootMenu.OnSelectObject (System.Object data) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
EventSystem.Trigger (UnityEngine.GameObject go, System.Int32 hash, System.Object data) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KMonoBehaviour.Trigger (System.Int32 hash, System.Object data) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
SelectTool.Select (KSelectable new_selected, System.Boolean skipSound) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
SelectTool.OnLeftClickDown (UnityEngine.Vector3 cursor_pos) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
PlayerController.OnKeyDown (KButtonEvent e) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
KInputHandler.HandleKeyDown (KButtonEvent e) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputHandler.HandleKeyDown (KButtonEvent e) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputHandler.HandleEvent (KInputEvent e) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputController.Dispatch () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputManager.Dispatch () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputManager.Update () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
GameInputManager.Update () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
Global.Update () (at <1c58b1f98f5849baa9083bfd5185b144>:0)

  [DebugConsole][1]: Error[Exception]: NullReferenceException: Object reference not set to an instance of an object
EnergyGenerator.ISliderControl.GetSliderTooltip () (at <1c58b1f98f5849baa9083bfd5185b144>:0)
SliderSet.SetTarget (ISliderControl target) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
SingleSliderSideScreen.SetTarget (UnityEngine.GameObject new_target) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
DetailsScreen.<Refresh>b__41_0 (DetailsScreen+SideScreenRef scn) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
System.Collections.Generic.List`1[T].ForEach (System.Action`1[T] action) (at <9577ac7a62ef43179789031239ba8798>:0)
DetailsScreen.Refresh (UnityEngine.GameObject go) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
RootMenu.OnSelectObject (System.Object data) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
EventSystem.Trigger (UnityEngine.GameObject go, System.Int32 hash, System.Object data) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KMonoBehaviour.Trigger (System.Int32 hash, System.Object data) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
SelectTool.Select (KSelectable new_selected, System.Boolean skipSound) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
SelectTool.OnLeftClickDown (UnityEngine.Vector3 cursor_pos) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
PlayerController.OnKeyDown (KButtonEvent e) (at <1c58b1f98f5849baa9083bfd5185b144>:0)
KInputHandler.HandleKeyDown (KButtonEvent e) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputHandler.HandleKeyDown (KButtonEvent e) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputHandler.HandleEvent (KInputEvent e) (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputController.Dispatch () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputManager.Dispatch () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
KInputManager.Update () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
GameInputManager.Update () (at <f30d3c85d1f64155aa0dc6c7adb0d1eb>:0)
Global.Update () (at <1c58b1f98f5849baa9083bfd5185b144>:0)
                 */
                
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Power", GeneratorModConfig.ID);
            }

            public static void Postfix()
            {
                Debug.Log("Registering Generator Mod Building");
                var obj = Activator.CreateInstance(typeof(GeneratorModConfig));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class GeneratedBuildingDbPatch
        {
            public static void Prefix()
            {
                Debug.Log("Registering Generator Mod Research");
                var ls = new List<string>(Techs.TECH_GROUPING["RenewableEnergy"])
                    {GeneratorModConfig.ID}; //TODO use ls.add instead for cleanliness?
                Techs.TECH_GROUPING["RenewableEnergy"] = ls.ToArray();
            }
        }
    }
}