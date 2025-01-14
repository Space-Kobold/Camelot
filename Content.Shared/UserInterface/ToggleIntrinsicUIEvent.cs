// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Content.Shared.Actions;
using JetBrains.Annotations;
using Robust.Shared.Serialization.TypeSerializers.Implementations;

namespace Content.Shared.UserInterface;

[UsedImplicitly]
public sealed partial class ToggleIntrinsicUIEvent : InstantActionEvent
{
    [DataField("key", customTypeSerializer: typeof(EnumSerializer), required: true)]
    public Enum? Key { get; set; }
}
