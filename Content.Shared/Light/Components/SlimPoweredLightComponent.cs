// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.GameStates;

namespace Content.Shared.Light.Components;

// All content light code is terrible and everything is baked-in. Power code got predicted before light code did.
/// <summary>
/// Handles turning a pointlight on / off based on power. Nothing else
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class SlimPoweredLightComponent : Component
{
    /// <summary>
    /// Used to make this as being lit. If unpowered then the light will still be off.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool Enabled = true;
}
