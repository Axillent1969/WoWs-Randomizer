using System;
using System.Collections.Generic;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.utils
{
    class ShipFinder
    {
        public static List<Ship> FindShips(List<long> ShipIds, long GroupId,List<long> Exceptions)
        {
            List<Ship> Ships = new List<Ship>();

            if ( ShipIds.Count != 0 )
            {
                foreach(long id in ShipIds)
                {
                    Ship ship = Program.AllShips.Find(e => e.ID == id);
                    Ships.Add(ship);
                }
            } else if ( GroupId != 0)
            {

                string groupSelection = Consumable.GetConsumableInfoByGroupId(GroupId);
                if ( !groupSelection.Equals(""))
                {
                    string[] groupSplit = groupSelection.Split('/');
                    string shipclass = groupSplit[0];
                    List<string> tiers = ConvertToList(groupSplit[1]);
                    List<string> nations = ConvertToList(groupSplit[2]);
                    string flag = groupSplit[3];

                    foreach (string tier in tiers)
                    {
                        int currentTier = int.Parse(tier);
                        foreach (string nation in nations)
                        {
                            List<Ship> subsetShips = Program.AllShips.FindAll(e => e.Tier == currentTier && e.Country.Equals(nation) && e.ShipType.Equals(shipclass));

                            if (flag.Equals("t") || flag.Equals("p"))
                            {
                                foreach (Ship entry in subsetShips)
                                {
                                    if ((flag.Equals("t") && entry.Premium == false) || (flag.Equals("p") && entry.Premium == true)) { Ships.Add(entry); }
                                }
                            } else
                            {
                                if (subsetShips.Count > 0)
                                {
                                    Ships.AddRange(subsetShips);
                                }
                            }
                        }
                    }
                }
            }
            if ( Exceptions.Count > 0 )
            {
                foreach(long shipId in Exceptions)
                {
                    Ship ship = Ships.Find(e => e.ID == shipId);
                    if (ship != null) { Ships.Remove(ship); }
                }
            }
            return Ships;
        }

        private static List<string> ConvertToList(string value)
        {
            List<string> values = new List<string>();
            if (value.Contains(","))
            {
                string[] subSplit = value.Split(',');
                foreach (string itm in subSplit)
                {
                    values.Add(itm);
                }
            }
            else
            {
                values.Add(value);
            }
            return values;
        }
    }
}
