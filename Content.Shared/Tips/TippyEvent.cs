// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.Serialization;

namespace Content.Shared.Tips;

[Serializable, NetSerializable]
public sealed class TippyEvent : EntityEventArgs
{
    public TippyEvent(string msg)
    {
        Msg = msg;
    }

    public string Msg;
    public string? Proto;
    public float SpeakTime = 5;
    public float SlideTime = 3;
    public float WaddleInterval = 0.5f;
}
