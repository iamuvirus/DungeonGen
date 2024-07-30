namespace GenDLib
{
    public class RoomGenerator
    {

        public Dungeon Generate(Dungeon dungeon)
        {
            throw new NotImplementedException();
        }

        private bool Intersect(List<Area> areas, Area areaA, int offset)
        {
            var AX1 = areaA.PositionX;
            var AY1 = areaA.PositionY;
            var AX2 = areaA.PositionX1;
            var AY2 = areaA.PositionY1;

            foreach (var areaB in areas)
            {
                var BX1 = areaB.PositionX - offset;
                var BY1 = areaB.PositionY - offset;
                var BX2 = areaB.PositionX1 + offset;
                var BY2 = areaB.PositionY1 + offset;

                var intersect = AX1 < BX2 && AX2 > BX1 && AY1 < BY2 && AY2 > BY1;

                if (intersect)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
