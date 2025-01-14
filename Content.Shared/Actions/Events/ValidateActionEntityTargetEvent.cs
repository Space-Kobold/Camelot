// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

namespace Content.Shared.Actions.Events;

[ByRefEvent]
public record struct ValidateActionEntityTargetEvent(EntityUid User, EntityUid Target, bool Cancelled = false);
