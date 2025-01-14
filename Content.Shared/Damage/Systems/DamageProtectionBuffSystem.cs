// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Content.Shared.Damage.Components;

namespace Content.Shared.Damage.Systems;

public sealed class DamageProtectionBuffSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DamageProtectionBuffComponent, DamageModifyEvent>(OnDamageModify);
    }

    private void OnDamageModify(EntityUid uid, DamageProtectionBuffComponent component, DamageModifyEvent args)
    {
        foreach (var modifier in component.Modifiers.Values)
            args.Damage = DamageSpecifier.ApplyModifierSet(args.Damage, modifier);
    }
}
