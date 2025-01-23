using Content.Server.Fluids.EntitySystems;
using Content.Shared._APCore.Chemistry.Registry;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reaction;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FixedPoint;
using JetBrains.Annotations;
using Robust.Shared.Map;

namespace Content.Server.Chemistry.TileReactions
{
    [UsedImplicitly]
    [DataDefinition]
    public sealed partial class SpillIfPuddlePresentTileReaction : ITileReaction
    {
        public FixedPoint2 TileReact(TileRef tile,
            ReagentDefinition reagent,
            FixedPoint2 reactVolume,
            IEntityManager entityManager,
            List<ReagentData>? data)
        {
            var spillSystem = entityManager.System<PuddleSystem>();
            if (reactVolume < 5 || !spillSystem.TryGetPuddle(tile, out _))
                return FixedPoint2.Zero;

            return spillSystem.TrySpillAt(tile, new Solution(reagent.ID, reactVolume, data), out _, sound: false, tileReact: false)
                ? reactVolume
                : FixedPoint2.Zero;
        }
    }
}
