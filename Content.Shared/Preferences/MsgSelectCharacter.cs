// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Lidgren.Network;
using Robust.Shared.Network;
using Robust.Shared.Serialization;

namespace Content.Shared.Preferences
{
    /// <summary>
    /// The client sends this to select a character slot.
    /// </summary>
    public sealed class MsgSelectCharacter : NetMessage
    {
        public override MsgGroups MsgGroup => MsgGroups.Command;

        public int SelectedCharacterIndex;

        public override void ReadFromBuffer(NetIncomingMessage buffer, IRobustSerializer serializer)
        {
            SelectedCharacterIndex = buffer.ReadVariableInt32();
        }

        public override void WriteToBuffer(NetOutgoingMessage buffer, IRobustSerializer serializer)
        {
            buffer.WriteVariableInt32(SelectedCharacterIndex);
        }
    }
}
