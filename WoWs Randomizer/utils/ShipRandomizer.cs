using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.utils
{
    class ShipRandomizer
    {
        private Dictionary<string, List<string>> Selection = null;
        private bool UniqueSelection = false;
        private List<long> PersonalShips = new List<long>();
        private List<long> AlreadyRandomizedShips = new List<long>();
        private HashSet<long> ExcludedShips = new HashSet<long>();
        private List<Ship> MyShips = new List<Ship>();

        private List<string> SelectionCountry;
        private List<string> SelectionShipclass;
        private List<string> SelectionTier;
        private List<string> SelectionPremium;

        public ShipRandomizer(HashSet<long> ExcludedShips)
        {
            this.ExcludedShips = ExcludedShips;
        }

        public void AddPersonalShips(List<long> PersonalShips)
        {
            this.PersonalShips = PersonalShips;
        }

        public void AddSelection(Dictionary<string,List<string>> Selection)
        {
            this.Selection = Selection;
            ParseSelection();
        }

        public Ship GetRandomShip()
        {
            MyShips.Clear();
            if (Selection == null || Selection.Count == 0 || IsNoSelectionMade())
            {
                MyShips.AddRange(GetShipsToSelectFrom());
            } else
            {
                MakeSelection();
            }

            Ship ThisShip = null;
            if (MyShips.Count > 0)
            {
                int MAX = MyShips.Count;
                do
                {
                    Random Rand = new Random();
                    int SHIPNO = Rand.Next(0, MAX);
                    ThisShip = MyShips[SHIPNO];
                    if (UniqueSelection)
                    {
                        if (!AlreadyRandomizedShips.Contains(ThisShip.ID))
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            if (ThisShip != null)
            {
                AlreadyRandomizedShips.Add(ThisShip.ID);
            }
            return ThisShip;
        }
        
        private void MakeSelection()
        {
            foreach (Ship Ship in GetShipsToSelectFrom())
            {
                bool AddShip = true;

                if (Ship.Name.StartsWith("["))
                {
                    AddShip = false;
                }
                if (AddShip == true && SelectionCountry.Count > 0 && !SelectionCountry.Contains(Ship.Country))
                {
                    AddShip = false;
                }
                if (AddShip == true && SelectionShipclass.Count > 0 && !SelectionShipclass.Contains(Ship.ShipType.ToLower()))
                {
                    AddShip = false;
                }
                if (AddShip == true && SelectionTier.Count > 0 && !SelectionTier.Contains(Ship.Tier.ToString()))
                {
                    AddShip = false;
                }
                if (AddShip == true && SelectionPremium.Count == 1)
                {
                    if (SelectionPremium.Contains("Premium") && Ship.Premium == false)
                    {
                        AddShip = false;
                    }
                    else if (SelectionPremium.Contains("Techtree") && Ship.Premium == true)
                    {
                        AddShip = false;
                    }
                }
                if (AddShip && UniqueSelection)
                {
                    if (AlreadyRandomizedShips.Contains(Ship.ID))
                    {
                        AddShip = false;
                    }
                }
                if (AddShip)
                {
                    MyShips.Add(Ship);
                }
            }
        }

        private void ParseSelection()
        {
            SelectionCountry = Selection["country"];
            SelectionShipclass = Selection["shipclass"];
            SelectionTier = Selection["tier"];
            SelectionPremium = Selection["premium"];
            if ( Selection.ContainsKey("unique"))
            {
                UniqueSelection = true;
            } else
            {
                UniqueSelection = false;
            }
        }

        private bool IsNoSelectionMade()
        {
            return (SelectionCountry.Count == 0 && SelectionShipclass.Count == 0 && SelectionTier.Count == 0 && (SelectionPremium.Count == 0 || SelectionPremium.Count == 2));
        }

        private List<Ship> GetShipsToSelectFrom()
        {
            List<Ship> ListedShips = new List<Ship>();
            if (this.PersonalShips.Count > 0)
            {
                foreach (long ID in this.PersonalShips)
                {
                    Ship findShip = Program.AllShips.Find(x => x.ID == ID);
                    if (findShip != null)
                    {
                        ListedShips.Add(findShip);
                    }
                }
            }
            else
            {
                ListedShips.AddRange(Program.AllShips);
            }

            if (ExcludedShips.Count > 0)
            {
                foreach (long value in ExcludedShips)
                {
                    Ship findShip = ListedShips.Find(x => x.ID == value);
                    if (findShip != null)
                    {
                        ListedShips.Remove(findShip);
                    }
                }
            }
            return ListedShips;
        }
    }
}
