// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

namespace Content.Shared.Climbing.Events;

/// <summary>
/// Raised on an entity when it ends climbing.
/// </summary>
[ByRefEvent]
public readonly record struct EndClimbEvent;
