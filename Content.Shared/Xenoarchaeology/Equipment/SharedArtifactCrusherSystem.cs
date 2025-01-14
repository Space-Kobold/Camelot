// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Content.Shared.Examine;
using Content.Shared.Storage.Components;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Containers;
using Content.Shared.Emag.Systems;

namespace Content.Shared.Xenoarchaeology.Equipment;

/// <summary>
/// This handles logic relating to <see cref="ArtifactCrusherComponent"/>
/// </summary>
public abstract class SharedArtifactCrusherSystem : EntitySystem
{
    [Dependency] protected readonly SharedAppearanceSystem Appearance = default!;
    [Dependency] protected readonly SharedAudioSystem AudioSystem = default!;
    [Dependency] protected readonly SharedContainerSystem ContainerSystem = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ArtifactCrusherComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<ArtifactCrusherComponent, StorageAfterOpenEvent>(OnStorageAfterOpen);
        SubscribeLocalEvent<ArtifactCrusherComponent, StorageOpenAttemptEvent>(OnStorageOpenAttempt);
        SubscribeLocalEvent<ArtifactCrusherComponent, ExaminedEvent>(OnExamine);
        SubscribeLocalEvent<ArtifactCrusherComponent, GotEmaggedEvent>(OnEmagged);
    }

    private void OnInit(Entity<ArtifactCrusherComponent> ent, ref ComponentInit args)
    {
        ent.Comp.OutputContainer = ContainerSystem.EnsureContainer<Container>(ent, ent.Comp.OutputContainerName);
    }

    private void OnStorageAfterOpen(Entity<ArtifactCrusherComponent> ent, ref StorageAfterOpenEvent args)
    {
        StopCrushing(ent);
        ContainerSystem.EmptyContainer(ent.Comp.OutputContainer);
    }

    private void OnEmagged(Entity<ArtifactCrusherComponent> ent, ref GotEmaggedEvent args)
    {
        ent.Comp.AutoLock = true;
        args.Handled = true;
    }

    private void OnStorageOpenAttempt(Entity<ArtifactCrusherComponent> ent, ref StorageOpenAttemptEvent args)
    {
        if (ent.Comp.AutoLock && ent.Comp.Crushing)
            args.Cancelled = true;
    }

    private void OnExamine(Entity<ArtifactCrusherComponent> ent, ref ExaminedEvent args)
    {
        args.PushMarkup(ent.Comp.AutoLock ? Loc.GetString("artifact-crusher-examine-autolocks") : Loc.GetString("artifact-crusher-examine-no-autolocks"));
    }

    public void StopCrushing(Entity<ArtifactCrusherComponent> ent, bool early = true)
    {
        var (_, crusher) = ent;

        if (!crusher.Crushing)
            return;

        crusher.Crushing = false;
        Appearance.SetData(ent, ArtifactCrusherVisuals.Crushing, false);

        if (early)
        {
            AudioSystem.Stop(crusher.CrushingSoundEntity?.Item1, crusher.CrushingSoundEntity?.Item2);
            crusher.CrushingSoundEntity = null;
        }

        Dirty(ent, ent.Comp);
    }
}
