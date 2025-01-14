// SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
//
// SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

using Robust.Shared.Serialization;

namespace Content.Shared.Tabletop.Events
{
    /// <summary>
    /// Event to tell other clients that we are dragging this item. Necessery to handle multiple users
    /// trying to move a single item at the same time.
    /// </summary>
    [Serializable, NetSerializable]
    public sealed class TabletopDraggingPlayerChangedEvent : EntityEventArgs
    {
        /// <summary>
        /// The UID of the entity being dragged.
        /// </summary>
        public NetEntity DraggedEntityUid;

        public bool IsDragging;

        public TabletopDraggingPlayerChangedEvent(NetEntity draggedEntityUid, bool isDragging)
        {
            DraggedEntityUid = draggedEntityUid;
            IsDragging = isDragging;
        }
    }
}
