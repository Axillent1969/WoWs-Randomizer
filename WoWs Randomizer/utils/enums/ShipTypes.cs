namespace WoWs_Randomizer.utils
{
    public class ShipTypes : Enumeration
    {
        public static readonly ShipTypes DD = new ShipTypes("Destroyer", "Destroyer","dd");
        public static readonly ShipTypes CA = new ShipTypes("Cruiser", "Cruiser","ca");
        public static readonly ShipTypes BB = new ShipTypes("Battleship", "Battleship","bb");
        public static readonly ShipTypes CV = new ShipTypes("AirCarrier", "Aircraft Carrier","cv");
        public static readonly ShipTypes SM = new ShipTypes("Submarine", "Submarine","sub");

        public ShipTypes(string abbreviation, string name, string code) : base(abbreviation, name,code)
        {

        }

        public static ShipTypes GetShipType(string shiptype)
        {
            ShipTypes[] allTypes = { ShipTypes.DD, ShipTypes.CA, ShipTypes.BB, ShipTypes.CV, ShipTypes.SM };
            string compare = shiptype.ToLower();

            foreach(ShipTypes ship in allTypes)
            {
                if ( compare.Equals(ship.Abbreviation.ToLower()) || compare.Equals(ship.Code) || compare.Equals(ship.Name.ToLower()))
                {
                    return ship;
                }
            }
            return null;
        }
    }
}
