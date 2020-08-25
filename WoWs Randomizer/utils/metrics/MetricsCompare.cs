using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WoWs_Randomizer.utils
{
    class MetricsCompare
    {
        public static void DoCompare(TableLayoutPanel Table, TableLayoutPanel Base)
        {
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

        public static Color GetBackgroundColor(Control Label, Control Value, Control BaseValue)
        {
            List<string> biggerIsBetter = new List<string>();
            biggerIsBetter.Add("Tier");
            biggerIsBetter.Add("HP");
            biggerIsBetter.Add("Engine/Speed");
            biggerIsBetter.Add("Gun Caliber");
            biggerIsBetter.Add("Traverse speed");
            biggerIsBetter.Add("Secondary Range");
            biggerIsBetter.Add("Range");
            biggerIsBetter.Add("Firechance Main");
            biggerIsBetter.Add("Firechance Secondary");
            biggerIsBetter.Add("Torpedo speed");
            biggerIsBetter.Add("Torpedo distance");

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

            List<string> smallerIsBetter = new List<string>();
            smallerIsBetter.Add("Reload Main");
            smallerIsBetter.Add("Reload Secondary");
            smallerIsBetter.Add("Traverse time 180°");
            smallerIsBetter.Add("Torpedo reload");
            smallerIsBetter.Add("Surface detection");
            smallerIsBetter.Add("Air detection");

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
