// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

namespace Content.Shared.Atmos.Piping.Components;

/// <summary>
///     Raised directed on an atmos device when it is enabled.
/// </summary>
[ByRefEvent]
public readonly record struct AtmosDeviceEnabledEvent;