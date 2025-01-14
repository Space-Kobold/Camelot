// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.Serialization;

namespace Content.Shared.Wires
{
    [Serializable, NetSerializable]
    public enum WireVisVisuals
    {
        ConnectedMask
    }

    [Flags]
    [Serializable, NetSerializable]
    public enum WireVisDirFlags : byte
    {
        None = 0,
        North = 1,
        South = 2,
        East = 4,
        West = 8
    }
}
