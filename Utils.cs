using ByteSizeLib;
using System.Drawing;
using ZedGraph;

namespace Particionada_Estática {
    public class Utils {
        public static void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat) {
            CreateBarLabels(pane, isBarCenter, valueFormat, TextObj.Default.FontFamily,
                    TextObj.Default.FontSize, TextObj.Default.FontColor, true,
                    TextObj.Default.FontItalic, TextObj.Default.FontUnderline);
        }

        public static void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat,
            string fontFamily, float fontSize, Color fontColor, bool isBold, bool isItalic,
            bool isUnderline) {
            bool isVertical = pane.BarSettings.Base == BarBase.X;

            // keep a count of the number of BarItems
            int curveIndex = 0;

            // Get a valuehandler to do some calculations for us
            ValueHandler valueHandler = new ValueHandler(pane, true);

            // Loop through each curve in the list
            foreach (CurveItem curve in pane.CurveList) {
                // work with BarItems only
                BarItem bar = curve as BarItem;
                if (bar != null) {
                    IPointList points = curve.Points;

                    // ADD JKB 9/21/07
                    // The labelOffset should depend on whether the curve is YAxis or Y2Axis.
                    // JHC - Generalize to any value axis
                    // Make the gap between the bars and the labels = 1.5% of the axis range
                    float labelOffset;

                    Scale scale = curve.ValueAxis(pane).Scale;
                    labelOffset = (float)(scale.Max - scale.Min) * 0.015f;

                    // Loop through each point in the BarItem
                    for (int i = 0; i < points.Count; i++) {
                        // Get the high, low and base values for the current bar
                        // note that this method will automatically calculate the "effective"
                        // values if the bar is stacked
                        double baseVal, lowVal, hiVal;
                        valueHandler.GetValues(curve, i, out baseVal, out lowVal, out hiVal);

                        // Get the value that corresponds to the center of the bar base
                        // This method figures out how the bars are positioned within a cluster
                        float centerVal = (float)valueHandler.BarCenterValue(bar,
                            bar.GetBarWidth(pane), i, baseVal, curveIndex);

                        // Create a text label -- note that we have to go back to the original point
                        // data for this, since hiVal and lowVal could be "effective" values from a bar stack
                        string barLabelText = (isVertical ? points[i].Y : points[i].X).ToString(valueFormat);

                        // Calculate the position of the label -- this is either the X or the Y coordinate
                        // depending on whether they are horizontal or vertical bars, respectively
                        float position;
                        if (isBarCenter)
                            position = (float)(hiVal + lowVal) / 2.0f;
                        else if (hiVal >= 0)
                            position = (float)hiVal + labelOffset;
                        else
                            position = (float)hiVal - labelOffset;

                        // Create the new TextObj
                        TextObj label;
                        if (isVertical)
                            label = new TextObj(bar.Label.Text + " " + barLabelText, centerVal, position);
                        else
                            label = new TextObj(bar.Label.Text + " " + barLabelText, position, centerVal);

                        label.FontSpec.Family = fontFamily;

                        // Configure the TextObj

                        // CHANGE JKB 9/21/07
                        // CoordinateFrame should depend on whether curve is YAxis or Y2Axis.
                        label.Location.CoordinateFrame =
                            (isVertical && curve.IsY2Axis) ? CoordType.AxisXY2Scale : CoordType.AxisXYScale;

                        label.FontSpec.Size = fontSize;
                        label.FontSpec.FontColor = fontColor;
                        label.FontSpec.IsItalic = isItalic;
                        label.FontSpec.IsBold = isBold;
                        label.FontSpec.IsUnderline = isUnderline;

                        label.FontSpec.Angle = isVertical ? 0 : 0;
                        label.Location.AlignH = isBarCenter ? AlignH.Center :
                                    (hiVal >= 0 ? AlignH.Left : AlignH.Right);
                        label.Location.AlignV = AlignV.Center;
                        label.FontSpec.Border.IsVisible = false;
                        label.FontSpec.Fill.IsVisible = false;

                        // Add the TextObj to the GraphPane
                        pane.GraphObjList.Add(label);
                    }
                    curveIndex++;
                }
            }
        }

        public static double KB(double from, string suffix) {
            return suffix switch {
                "GB" => ByteSize.FromGibiBytes(from).KibiBytes,
                "MB" => ByteSize.FromMebiBytes(from).KibiBytes,
                "KB" => ByteSize.FromKibiBytes(from).KibiBytes,
                _ => -1,
            };
        }

    }
}
