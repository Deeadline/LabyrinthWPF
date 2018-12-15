using Labirynt.Elements.Utils;

namespace Labirynt.Elements.Player
{
    public interface IPlayer
    {
        GraphicRepresentation GraphicRepresentation { get; set; }
        Collision Collider { get; set; }
        Coordinate GetMoveCoordinates(int x, int y);
        void Move(Coordinate moveCoordinate);
        void Redraw();
    }
}