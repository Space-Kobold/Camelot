// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Content.Shared.Stunnable;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Server.Stunnable.Components;

[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
[Access(typeof(SharedStunbatonSystem))]
public sealed partial class StunbatonComponent : Component
{
    [DataField("energyPerUse"), ViewVariables(VVAccess.ReadWrite)]
    [AutoNetworkedField]
    public float EnergyPerUse = 350;

    [DataField("sparksSound")]
    public SoundSpecifier SparksSound = new SoundCollectionSpecifier("sparks");
}
