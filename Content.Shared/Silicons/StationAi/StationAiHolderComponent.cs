// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Content.Shared.Containers.ItemSlots;
using Robust.Shared.GameStates;

namespace Content.Shared.Silicons.StationAi;

/// <summary>
/// Allows moving a <see cref="StationAiCoreComponent"/> contained entity to and from this component.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class StationAiHolderComponent : Component
{
    public const string Container = StationAiCoreComponent.Container;

    [DataField]
    public ItemSlot Slot = new();
}
