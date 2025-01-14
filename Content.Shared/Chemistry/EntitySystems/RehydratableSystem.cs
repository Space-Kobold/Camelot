// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Content.Shared.Administration.Logs;
using Content.Shared.Chemistry.Components;
using Content.Shared.Database;
using Content.Shared.FixedPoint;
using Content.Shared.Popups;
using Robust.Shared.Network;
using Robust.Shared.Random;

namespace Content.Shared.Chemistry.EntitySystems;

public sealed class RehydratableSystem : EntitySystem
{
    [Dependency] private readonly INetManager _net = default!;
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    [Dependency] private readonly SharedSolutionContainerSystem _solutions = default!;
    [Dependency] private readonly SharedTransformSystem _xform = default!;
    [Dependency] private readonly ISharedAdminLogManager _adminLogger = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<RehydratableComponent, SolutionContainerChangedEvent>(OnSolutionChange);
    }

    private void OnSolutionChange(Entity<RehydratableComponent> ent, ref SolutionContainerChangedEvent args)
    {
        var quantity = _solutions.GetTotalPrototypeQuantity(ent, ent.Comp.CatalystPrototype);
        _adminLogger.Add(LogType.Action, LogImpact.Medium, $"{ToPrettyString(ent.Owner)} was hydrated, now contains a solution of: {SharedSolutionContainerSystem.ToPrettyString(args.Solution)}.");
        if (quantity != FixedPoint2.Zero && quantity >= ent.Comp.CatalystMinimum)
        {
            Expand(ent);
        }
    }

    // Try not to make this public if you can help it.
    private void Expand(Entity<RehydratableComponent> ent)
    {
        if (_net.IsClient)
            return;

        var (uid, comp) = ent;

        var randomMob = _random.Pick(comp.PossibleSpawns);

        var target = Spawn(randomMob, Transform(uid).Coordinates);
        _adminLogger.Add(LogType.Action, LogImpact.Medium, $"{ToPrettyString(ent.Owner)} has been hydrated correctly and spawned: {ToPrettyString(target)}.");

        _popup.PopupEntity(Loc.GetString("rehydratable-component-expands-message", ("owner", uid)), target);

        _xform.AttachToGridOrMap(target);
        var ev = new GotRehydratedEvent(target);
        RaiseLocalEvent(uid, ref ev);

        // prevent double hydration while queued
        RemComp<RehydratableComponent>(uid);
        QueueDel(uid);
    }
}
