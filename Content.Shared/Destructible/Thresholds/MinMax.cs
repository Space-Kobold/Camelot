// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.Random;

namespace Content.Shared.Destructible.Thresholds;

[DataDefinition, Serializable]
public partial struct MinMax
{
    [DataField]
    public int Min;

    [DataField]
    public int Max;

    public MinMax(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public readonly int Next(IRobustRandom random)
    {
        return random.Next(Min, Max + 1);
    }

    public readonly int Next(System.Random random)
    {
        return random.Next(Min, Max + 1);
    }
}
