// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.Weapons.Ranged.Components;

[RegisterComponent, NetworkedComponent]
public sealed partial class HitscanBatteryAmmoProviderComponent : BatteryAmmoProviderComponent
{
    [ViewVariables(VVAccess.ReadWrite), DataField("proto", required: true, customTypeSerializer: typeof(PrototypeIdSerializer<HitscanPrototype>))]
    public string Prototype = default!;
}
