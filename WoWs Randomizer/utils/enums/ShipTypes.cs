namespace WoWs_Randomizer.utils
{
    public class ShipTypes : Enumeration
    {
        public static readonly ShipTypes DD = new ShipTypes("Destroyer", "Destroyer");
        public static readonly ShipTypes CA = new ShipTypes("Cruiser", "Cruiser");
        public static readonly ShipTypes BB = new ShipTypes("Battleship", "Battleship");
        public static readonly ShipTypes CV = new ShipTypes("AirCarrier", "Aircraft Carrier");

        public ShipTypes(string abbreviation, string name) : base(abbreviation, name)
        {

        }
    }
}
