using System;
using System.Drawing;
using System.Windows.Forms;

namespace stock_management_system
{
    public class DataGridViewProgressBarColumn : DataGridViewColumn
    {
        public DataGridViewProgressBarColumn() : base(new DataGridViewProgressBarCell())
        {
        }
    }

    public class DataGridViewProgressBarCell : DataGridViewTextBoxCell
    {
        public DataGridViewProgressBarCell()
        {
            this.ValueType = typeof(int); // Progress value as integer
        }

        // Override the Paint method to draw the progress bar.
        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // Ensure the value is an integer
            int progressVal = value != null ? Convert.ToInt32(value) : 0;
            float percentage = ((float)progressVal / 100.0f);

            // Draw the cell background
            base.Paint(g, clipBounds, cellBounds, rowIndex, elementState, null, null, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground);

            if (percentage > 0.0)
            {
                // Draw the progress bar
                Rectangle progressBarRect = new Rectangle(cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32(percentage * (cellBounds.Width - 4)), cellBounds.Height - 4);
                Brush progressBrush = new SolidBrush(Color.FromArgb(0, 173, 181));

                // Use the custom brush to fill the progress bar rectangle
                g.FillRectangle(progressBrush, progressBarRect);
            }

            // Draw the text (percentage)
            string text = progressVal.ToString() + "%";
            SizeF textSize = g.MeasureString(text, cellStyle.Font);
            float textX = cellBounds.X + (cellBounds.Width - textSize.Width) / 2;
            float textY = cellBounds.Y + (cellBounds.Height - textSize.Height) / 2;

            g.DrawString(text, cellStyle.Font, Brushes.White, textX, textY);
        }

        // Default value for new rows
        public override object DefaultNewRowValue
        {
            get
            {
                return 0; // Default progress is 0%
            }
        }
    }
}