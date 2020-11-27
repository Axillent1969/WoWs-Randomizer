using System.Collections.Generic;

namespace WoWs_Randomizer.objects.consumables
{
    public static class ConsumableTypeGroups
    {

        public static string GetConsumableInfoByGroupId(long groupId)
        {
            Dictionary<long, string> map = new Dictionary<long, string>();

            // a = All ships, t = Tech-tree ships only, p = premium only

            // HYDRO
            map.Add(1, "Battleship/9,10/germany/a");
            map.Add(2, "Cruiser/4,5,6,7/usa,japan,ussr,uk,france,pan_asia,commonwealth,pan_america/a");
            map.Add(3, "Cruiser/8,9,10/usa,japan,ussr,uk,france,pan_asia,commonwealth,pan_america/a");
            map.Add(4, "Cruiser/4,5,6,7/germany/a");
            map.Add(5, "Cruiser/8,9,10/germany/a");
            map.Add(6, "Destroyer/4,5,6,7/germany/a");
            map.Add(7, "Destroyer/8,9,10/germany/a");
            // SHORT RANGE HYDRO
            map.Add(8, "Destroyer/6,7,8,9,10/uk/a");
            // FAST DAMAGE CONTROL TEAM
            map.Add(9, "Battleship/3,4,5,6,7,8,9,10/ussr/a");
            // DAMAGE CONTROL PARTY
            map.Add(10, "Battleship/3,4,5,6,7,8,9,10/usa/a");
            map.Add(11, "Battleship/2,3,4,5,6,7,8,9,10/japan/a");
            map.Add(12, "Battleship/3,4,5,6,7,8,9,10/germany,uk,france,italy,pan_asia,europe/a");
            map.Add(13, "Cruiser/1/usa,japan,ussr,germany,uk,france,italy,pan_asia,europe/a");
            map.Add(14, "Cruiser/2,3,4,5,6,7,8,9,10/usa,japan,ussr,germany,uk,france,italy,pan_asia,commonwealth,pan_america/a");
            map.Add(15, "Destroyer/2,3,4,5,6,7,8,9,10/usa,japan,ussr,germany,uk,france,pan_asia,commonwealth,europe/a");
            map.Add(75, "AirCarrier/4,6,8,10/usa,japan,germany,uk/a");

            // REPAIR PARTY
            map.Add(16, "Battleship/3,4,5,6,7,8,9,10/usa/a");
            map.Add(17, "Battleship/2,3,4,5,6,7,8/japan,germany,france,italy/a");
            map.Add(18, "Battleship/9,10/japan,germany,france/a");
            map.Add(19, "Battleship/3,4,5,6,7,8,9,10/ussr/a");
            map.Add(20, "Battleship/2,3/uk/a");
            map.Add(21, "Battleship/4,5,6/uk/a");
            map.Add(22, "Battleship/7,8/uk/a");
            map.Add(23, "Cruiser/9,10/usa,japan,ussr,france,italy/a");
            map.Add(24, "Cruiser/9,10/germany/a");
            map.Add(25, "Destroyer/9,10/uk/a");
            // SPECIALIZED HEAL
            map.Add(26, "Battleship/9,10/uk/a");
            map.Add(27, "Cruiser/8,9,10/uk/a");
            // CATAPULT FIGHTER
            map.Add(28, "Battleship/7,8/usa,japan,uk,germany,france,ussr/a");
            map.Add(29, "Battleship/9/usa,japan,germany,uk,france,pan_asia,ussr/a");
            map.Add(30, "Battleship/10/usa,japan,germany/a");
            map.Add(31, "Cruiser/5,6/usa,japan,uk,commonwealth,germany,italy,france/a");
            map.Add(32, "Cruiser/7,8/usa,japan,uk,germany,italy,france/a");
            map.Add(33, "Cruiser/9/usa,japan,germany,italy,france,ussr/a");
            map.Add(34, "Cruiser/10/usa,japan,germany,italy/a");
            // SPOTTER PLANE
            map.Add(35, "Battleship/4,5,6,7,8,9,10/usa,japan/a");
            map.Add(36, "Battleship/5,6,7,8,9,10/germany/a");
            map.Add(37, "Battleship/5,6,7,8,9/uk/t");
            map.Add(38, "Cruiser/5,6,7,8,9,10/italy/a");
            // SHORT-BURST SMOKE GENERATOR
            map.Add(39, "Destroyer/2,3,4,5,6,7,8,9,10/uk/a");
            // SMOKE
            map.Add(40, "Destroyer/2,3,4,5,6,7,8,9,10/pan_asia/a");
            map.Add(41, "Destroyer/2/germany/a");
            map.Add(42, "Destroyer/3/germany/a");
            map.Add(43, "Destroyer/4/germany/a");
            map.Add(44, "Destroyer/5/germany/a");
            map.Add(45, "Destroyer/6/germany/a");
            map.Add(46, "Destroyer/7/germany/a");
            map.Add(47, "Destroyer/8/germany/a");
            map.Add(48, "Destroyer/9/germany/a");
            map.Add(49, "Destroyer/10/germany/a");
            map.Add(50, "Destroyer/2/japan,ussr/a");
            map.Add(51, "Destroyer/3/japan,ussr/a");
            map.Add(52, "Destroyer/4/japan,ussr/a");
            map.Add(53, "Destroyer/5/japan,ussr/a");
            map.Add(54, "Destroyer/6/japan,ussr/a");
            map.Add(55, "Destroyer/7/japan,ussr/a");
            map.Add(56, "Destroyer/8/japan,ussr/a");
            map.Add(57, "Destroyer/9/japan,ussr/a");
            map.Add(58, "Destroyer/10/japan,ussr/a");
            // EXHAUST SMOKE
            map.Add(59, "Cruiser/5,6/italy/a");
            map.Add(60, "Cruiser/7,8,9,10/italy/a");
            // SPEED BOOST
            map.Add(61, "Battleship/8,9,10/france/a");
            map.Add(62, "Cruiser/6,7/france/a");
            map.Add(63, "Cruiser/8,9,10/france/a");
            map.Add(64, "Destroyer/2,3,4,5,6,7,8,9,10/japan,usa,ussr,germany,pan_asia,commonwealth,europe/a");
            map.Add(65, "Destroyer/2,3,4,5,6,7/france/a");
            map.Add(66, "Destroyer/8,9,10/france/a");
            // MAIN BATTERY RELOAD BOOSTER
            map.Add(67, "Destroyer/6,7,8,9,10/france/a");
            map.Add(68, "Cruiser/6,7,8/france/a");
            map.Add(69, "Cruiser/9,10/france/a");
            // DEF AA
            map.Add(70, "Cruiser/6,7,8,9,10/usa/a");
            map.Add(71, "Cruiser/6,7,8,9,10/japan,germany,france/a");
            map.Add(72, "Cruiser/6,7,8,9,10/ussr/a");
            map.Add(73, "Destroyer/5,6,7,8,9,10/usa/t");
            map.Add(74, "Destroyer/8,9,10/europe/a");
            // CAP FIGHTERS
            map.Add(76, "AirCarrier/4,6,8,10/usa,japan,germany,uk/a");
            // ENGINE COOLING
            map.Add(77, "AirCarrier/4/usa,japan,uk/a");
            map.Add(78, "AirCarrier/4,6,8,10/germany/t");
            map.Add(79, "AirCarrier/6,8,10/usa,japan,uk/a");
            // PATROL FIGHTER
            map.Add(80, "AirCarrier/10/usa,japan,germany,uk/a");
            map.Add(81, "AirCarrier/8/usa,japan,germany,uk/a");
            map.Add(82, "AirCarrier/6/usa,japan,germany,uk/a");
            // AIRCRAFT REPAIR
            map.Add(83, "AirCarrier/8,10/usa,japan,germany,uk/a");

            if (map.ContainsKey(groupId))
            {
                return map[groupId];
            }
            return "";
        }
    }
}
