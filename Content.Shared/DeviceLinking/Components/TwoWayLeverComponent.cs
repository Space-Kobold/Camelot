// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.DeviceLinking.Components;

/// <summary>
/// Simple ternary state for device linking.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class TwoWayLeverComponent : Component
{
    [DataField, AutoNetworkedField]
    public TwoWayLeverState State;

    [DataField, AutoNetworkedField]
    public bool NextSignalLeft;

    [DataField]
    public ProtoId<SourcePortPrototype> LeftPort = "Left";

    [DataField]
    public ProtoId<SourcePortPrototype> RightPort = "Right";

    [DataField]
    public ProtoId<SourcePortPrototype> MiddlePort = "Middle";
}
