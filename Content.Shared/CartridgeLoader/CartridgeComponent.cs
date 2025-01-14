// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Utility;

namespace Content.Shared.CartridgeLoader;

/// <summary>
/// This is used for defining values used for displaying in the program ui in yaml
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class CartridgeComponent : Component
{
    [DataField]
    public EntityUid? LoaderUid;

    [DataField(required: true)]
    public LocId ProgramName = "default-program-name";

    [DataField]
    public SpriteSpecifier? Icon;

    [AutoNetworkedField]
    public InstallationStatus InstallationStatus = InstallationStatus.Cartridge;
}

[Serializable, NetSerializable]
public enum InstallationStatus
{
    Cartridge,
    Installed,
    Readonly
}
