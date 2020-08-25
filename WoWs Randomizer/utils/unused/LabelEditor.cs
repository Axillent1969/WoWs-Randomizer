using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WoWs_Randomizer.utils
{
    public class LabelEditor
    {
        private Label currentLabel = new Label();
        private string Unit = "";
        private double Value = 0;
        private bool Animate = true;
        private Color FinalColor = Color.Transparent;

        public LabelEditor(Label label)
        {
            currentLabel = label;
            Unit = GetUnit();
            Value = GetValue();
        }

        public void SetFinalColor(Color final) { FinalColor = final; }

        public void PerformAnimation(bool status) { Animate = status; }

        public void ChangeValue(double fixedvalue)
        {
            Value = fixedvalue;
            if ( Unit.Equals(""))
            {
                currentLabel.Text = Value.ToString();
            } else
            {
                currentLabel.Text = Value.ToString() + " " + Unit;
            }
            AnimateLabel();
        }

        public void SetUnit(string unit)
        {
            Unit = unit;
        }

        public double GetValue()
        {
            double current = 0;
        
            if (currentLabel.Text.ToString().Contains(" "))
            {
                current = double.Parse(currentLabel.Text.ToString().Split(' ')[0]);
            }
            else
            {
                current = double.Parse(currentLabel.Text.ToString());
            }
            return current;
        }

        public string GetUnit()
        {
            string unit = "";

            if (currentLabel.Text.ToString().Contains(" "))
            {
                unit = currentLabel.Text.ToString().Split(' ')[1];
            }
            else
            {
                unit = "";
            }
            return unit;
        }

        private void AnimateLabel()
        {
            if (Animate)
            {
                for (var i = 0; i < 3; i++)
                {
                    currentLabel.BackColor = Color.LightYellow;
                    currentLabel.Refresh();
                    Thread.Sleep(75);
                    currentLabel.BackColor = Color.LightBlue;
                    currentLabel.Refresh();
                    Thread.Sleep(75);
                }
            }
            currentLabel.BackColor = FinalColor;
            currentLabel.Refresh();
        }
    }

}
