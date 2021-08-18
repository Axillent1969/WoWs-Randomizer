using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WoWs_Randomizer.utils
{
    class MetricsCompare
    {
        private static List<string> smallerIsBetter = new List<string>();
        private static List<string> biggerIsBetter = new List<string>();

        public static void DoCompare(TableLayoutPanel Table, TableLayoutPanel Base)
        {
            if ( smallerIsBetter.Count == 0 || biggerIsBetter.Count == 0)
            {
                PrepareLists();
            }
            for (var row = 0; row < Table.RowCount; row++)
            {
                Control label = Table.GetControlFromPosition(0, row);
                Control value = Table.GetControlFromPosition(1, row);
                if (!value.Text.Equals(label.Text))
                {
                    bool found = false;
                    for (var brow = 0; brow < Base.RowCount; brow++)
                    {
                        Control blabel = Base.GetControlFromPosition(0, brow);
                        Control BaseValue = Base.GetControlFromPosition(1, brow);

                        if (blabel.Text.Equals(label.Text) && ((value.Tag != null && value.Tag.Equals(BaseValue.Tag)) || value.Tag == null))
                        {
                            value.BackColor = GetBackgroundColor(label, value, BaseValue);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        value.BackColor = Color.LightYellow;
                    }
                }
            }
        }

        private static void PrepareLists()
        {
            biggerIsBetter.Add(MetricsTableComposer.SHIP_TIER);
            biggerIsBetter.Add(MetricsTableComposer.SHIP_HP);
            biggerIsBetter.Add(MetricsTableComposer.SHIP_SPEED);
            biggerIsBetter.Add(MetricsTableComposer.GUN_CALIBER);
            biggerIsBetter.Add(MetricsTableComposer.TRAVERSE_SPEED);
            biggerIsBetter.Add(MetricsTableComposer.RANGE_SECONDARY);
            biggerIsBetter.Add(MetricsTableComposer.RANGE_MAIN);
            biggerIsBetter.Add(MetricsTableComposer.FIRECHANCE_MAIN);
            biggerIsBetter.Add(MetricsTableComposer.FIRECHANCE_SECONDARY);
            biggerIsBetter.Add(MetricsTableComposer.TORPEDO_SPEED);
            biggerIsBetter.Add(MetricsTableComposer.TORPEDO_RANGE);
            biggerIsBetter.Add(MetricsTableComposer.TORPEDO_DAMAGE);
            biggerIsBetter.Add(MetricsTableComposer.HE_DAMAGE);
            biggerIsBetter.Add(MetricsTableComposer.AP_DAMAGE);
            for(int i = 0; i < 6; i++)
            {
                biggerIsBetter.Add("Slot #" + i.ToString() + ": " + MetricsTableComposer.AA_CALIBER);
                biggerIsBetter.Add("Slot #" + i.ToString() + ": " + MetricsTableComposer.AA_DAMAGE);
            }

            smallerIsBetter.Add(MetricsTableComposer.RELOAD_MAIN);
            smallerIsBetter.Add(MetricsTableComposer.RELOAOD_SECONDARY);
            smallerIsBetter.Add(MetricsTableComposer.TRAVERSE_SPEED_180);
            smallerIsBetter.Add(MetricsTableComposer.TORPEDO_RELOAD);
            smallerIsBetter.Add(MetricsTableComposer.SURFACE_DETECTION);
            smallerIsBetter.Add(MetricsTableComposer.AIR_DETECTION);
            smallerIsBetter.Add(MetricsTableComposer.TURNING_RADIUS);
            smallerIsBetter.Add(MetricsTableComposer.RUDDER_SHIFT);
            smallerIsBetter.Add(MetricsTableComposer.DISPERSION);
        }

        private static Color GetBackgroundColor(Control Label, Control Value, Control BaseValue)
        {
            foreach (string label in biggerIsBetter)
            {
                if (Label.Text.Equals(label))
                {
                    double tBase = double.Parse(BaseValue.Text.Split(' ')[0]);
                    double tVal = double.Parse(Value.Text.Split(' ')[0]);

                    if (tVal > tBase)
                    {
                        return Color.LightGreen;
                    }
                    else if (tVal < tBase)
                    {
                        return Color.LightCoral;
                    }
                    else
                    {
                        return Color.Transparent;
                    }
                }
            }

            if (Label.Text.Equals("Premium"))
            {
                if (BaseValue.Text.Equals("Yes") && Value.Text.Equals("No"))
                {
                    return Color.LightCoral;
                }
                else if (BaseValue.Text.Equals("No") && Value.Text.Equals("Yes"))
                {
                    return Color.LightGreen;
                }
                else
                {
                    return Color.Transparent;
                }
            }

            foreach (string label in smallerIsBetter)
            {
                if (Label.Text.Equals(label))
                {
                    double tBase = double.Parse(BaseValue.Text.Split(' ')[0]);
                    double tValue = double.Parse(Value.Text.Split(' ')[0]);
                    if (tValue < tBase)
                    {
                        return Color.LightGreen;
                    }
                    else if (tValue > tBase)
                    {
                        return Color.LightCoral;
                    }
                    else
                    {
                        return Color.Transparent;
                    }
                }
            }
            return Color.Transparent;
        }
    }
}
