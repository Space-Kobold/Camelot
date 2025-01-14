// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Lidgren.Network;
using Robust.Shared.Network;
using Robust.Shared.Serialization;

namespace Content.Shared.Players.PlayTimeTracking;

/// <summary>
/// Sent server -> client to inform the client of their play times.
/// </summary>
public sealed class MsgPlayTime : NetMessage
{
    public override MsgGroups MsgGroup => MsgGroups.EntityEvent;

    public Dictionary<string, TimeSpan> Trackers = new();

    public override void ReadFromBuffer(NetIncomingMessage buffer, IRobustSerializer serializer)
    {
        var count = buffer.ReadVariableInt32();
        Trackers.EnsureCapacity(count);

        for (var i = 0; i < count; i++)
        {
            Trackers.Add(buffer.ReadString(), buffer.ReadTimeSpan());
        }
    }

    public override void WriteToBuffer(NetOutgoingMessage buffer, IRobustSerializer serializer)
    {
        buffer.WriteVariableInt32(Trackers.Count);

        foreach (var (role, time) in Trackers)
        {
            buffer.Write(role);
            buffer.Write(time);
        }
    }
}
