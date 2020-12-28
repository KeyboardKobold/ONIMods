using System;
using STRINGS;

namespace FreeEnergyGeneratorMod
{
    public class FreeEnergyGenerator : Generator
    {
        
        protected const int OnActivateChangeFlag = -2079840530;
        protected static readonly EventSystem.IntraObjectHandler<FreeEnergyGenerator> OnActivateChangeDelegate = new EventSystem.IntraObjectHandler<FreeEnergyGenerator>(OnActivateChangedStatic);

        private static void OnActivateChangedStatic(FreeEnergyGenerator gen, object data) => gen.OnActivateChanged(data as Operational);

        protected virtual void OnActivateChanged(Operational data) =>
            selectable.SetStatusItem(Db.Get().StatusItemCategories.Power, data.IsActive ? Db.Get().BuildingStatusItems.Wattage : Db.Get().BuildingStatusItems.GeneratorOffline, this);

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            Subscribe(OnActivateChangeFlag, OnActivateChangeDelegate);
        }

        public override void EnergySim200ms(float dt)
        {
            base.EnergySim200ms(dt);

            this.operational.SetFlag(Generator.wireConnectedFlag, this.CircuitID != ushort.MaxValue);
            this.operational.SetActive(true);

            if (!this.operational.IsOperational) return;
            
            this.GenerateJoules(this.WattageRating * dt);
            this.selectable.SetStatusItem(Db.Get().StatusItemCategories.Power,
                Db.Get().BuildingStatusItems.Wattage, this);
        }
    }
}