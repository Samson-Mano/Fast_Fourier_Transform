using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Fast_fourier_transform
{
    public partial class chart_view : Form
    {
        private chart_data_store the_chart;
        private chart_option chart_option_form;

        // Chart Format details
        public class chart_data_store
        {
            Color axis_color;
            bool paint_chart_title = true;
            string chart_title;

            // Horizontal Axis
            // Axis option
            double horizontal_bound_width;
            double horizontal_bounds_maximum;
            double horizontal_bounds_minimum;
            double horizontal_units_major;
            double horizontal_units_minor;
            bool show_horizontal_major_grid_line = true;
            bool show_horizontal_minor_grid_line = false;
            string horizontal_axis_title;

            // Vertical Axis
            // Axis option
            double vertical_bound_height;
            double vertical_bounds_maximum;
            double vertical_bounds_minimum;
            double vertical_units_major;
            double vertical_units_minor;
            bool show_vertical_major_grid_line = true;
            bool show_vertical_minor_grid_line = false;
            string vertical_axis_title;

            // Maximum and minimum for scale
            double data_max_X;
            double data_max_Y;
            double data_min_X;
            double data_min_Y;

            bool chart_x_format_automatic;
            bool chart_y_format_automatic;

            #region "Public read only properties"
            // Public read only variables format chart area
            public string _chart_title
            {
                get { return chart_title; }
            }

            public Color _axis_color
            {
                get { return axis_color; }
            }

            public bool _paint_chart_title
            {
                get { return paint_chart_title; }
            }

            // Public read only variables format horizontal axis
            public string _horizontal_axis_title
            {
                get { return horizontal_axis_title; }
            }

            public double _horizontal_bounds_maximum
            {
                get { return horizontal_bounds_maximum; }
            }

            public double _horizontal_bounds_minimum
            {
                get { return horizontal_bounds_minimum; }
            }

            public double _horizontal_units_major
            {
                get { return horizontal_units_major; }
            }

            public double _horizontal_units_minor
            {
                get { return horizontal_units_minor; }
            }

            public bool _show_horizontal_major_grid_line
            {
                get { return show_horizontal_major_grid_line; }
            }

            public bool _show_horizontal_minor_grid_line
            {
                get { return show_horizontal_minor_grid_line; }
            }

            public bool _chart_x_format_automatic
            {
                get { return chart_x_format_automatic; }
            }

            // Public read only variables format vertical axis
            public string _vertical_axis_title
            {
                get { return vertical_axis_title; }
            }

            public double _vertical_bounds_maximum
            {
                get { return vertical_bounds_maximum; }
            }

            public double _vertical_bounds_minimum
            {
                get { return vertical_bounds_minimum; }
            }

            public double _vertical_units_major
            {
                get { return vertical_units_major; }
            }

            public double _vertical_units_minor
            {
                get { return vertical_units_minor; }
            }

            public bool _show_vertical_major_grid_line
            {
                get { return show_vertical_major_grid_line; }
            }

            public bool _show_vertical_minor_grid_line
            {
                get { return show_vertical_minor_grid_line; }
            }

            public bool _chart_y_format_automatic
            {
                get { return chart_y_format_automatic; }
            }

            // data series
            public List<data_series_store> _data_series_list
            {
                get { return data_series_list; }
            }
            #endregion


            // All data series
            List<data_series_store> data_series_list = new List<data_series_store>();

            public chart_data_store(string i_chart_title = "Chart Title", string i_horizontal_axis_title = "X Axis", string i_vertical_axis_title = "Y Axis")
            {
                // Constructor
                data_series_list = new List<data_series_store>();
                chart_x_format_automatic = true;
                chart_y_format_automatic = true;

                axis_color = Color.Blue;

                // set title
                chart_title = i_chart_title;
                horizontal_axis_title = i_horizontal_axis_title;
                vertical_axis_title = i_vertical_axis_title;
            }

            public void format_chart_area(string i_chart_title, bool i_paint_chart_title, Color i_axis_color)
            {
                // Format chart area
                chart_title = i_chart_title;
                paint_chart_title = i_paint_chart_title;
                axis_color = i_axis_color;
            }

            public void format_horizontal_axis(string i_horiz_axis_title, double i_horiz_max_bounds, double i_horiz_min_bounds, double i_horiz_major_units, double i_horiz_minor_units, bool i_show_major_units, bool i_show_minor_units, bool is_automatic)
            {
                // Format horizontal axis
                // axis title
                horizontal_axis_title = i_horiz_axis_title;
                // grid lines visibility control
                show_horizontal_major_grid_line = i_show_major_units;
                show_horizontal_minor_grid_line = i_show_minor_units;

                if (is_automatic == false)
                {
                    // user initiated axis formating
                    chart_x_format_automatic = false;

                    // Adjust bounds from user input
                    // Bounds
                    horizontal_bounds_maximum = i_horiz_max_bounds;
                    horizontal_bounds_minimum = i_horiz_min_bounds;
                    horizontal_bound_width = horizontal_bounds_maximum - horizontal_bounds_minimum;
                    // grid units
                    horizontal_units_major = i_horiz_major_units;
                    horizontal_units_minor = i_horiz_minor_units;
                }
                else
                {
                    chart_x_format_automatic = true;

                    // Automatic chart formating
                    format_chart_axis(data_max_X, data_min_X, ref horizontal_bound_width, ref horizontal_bounds_maximum, ref horizontal_bounds_minimum, ref horizontal_units_major, ref horizontal_units_minor);
                }
            }

            public void format_vertical_axis(string i_vert_axis_title, double i_vert_max_bounds, double i_vert_min_bounds, double i_vert_major_units, double i_vert_minor_units, bool i_show_major_units, bool i_show_minor_units, bool is_automatic)
            {
                // Format vertical axis
                // axis title
                vertical_axis_title = i_vert_axis_title;
                // grid lines visibility control
                show_vertical_major_grid_line = i_show_major_units;
                show_vertical_minor_grid_line = i_show_minor_units;

                if (is_automatic == false)
                {
                    // user initiated axis formating
                    chart_y_format_automatic = false;

                    // Adjust bounds from user input
                    // Bounds
                    vertical_bounds_maximum = i_vert_max_bounds;
                    vertical_bounds_minimum = i_vert_min_bounds;
                    vertical_bound_height = vertical_bounds_maximum - vertical_bounds_minimum;
                    // grid units
                    vertical_units_major = i_vert_major_units;
                    vertical_units_minor = i_vert_minor_units;
                }
                else
                {
                    chart_y_format_automatic = true;

                    // Automatic chart formating
                    format_chart_axis(data_max_Y, data_min_Y, ref vertical_bound_height, ref vertical_bounds_maximum, ref vertical_bounds_minimum, ref vertical_units_major, ref vertical_units_minor);
                }
            }

            public void format_data_series(int s_index, string i_data_series_name, Color i_chart_color, int i_chart_type, int i_marker_type, int i_line_width, int i_line_pattern)
            {
                data_series_list[s_index].format_this_data_series(i_data_series_name, i_chart_color, i_chart_type, i_marker_type, i_line_width, i_line_pattern);
            }

            public void chart_add_data_series(data_series_store i_data_series)
            {
                data_series_list.Add(i_data_series);

                // adjust the maximum after new series is added
                set_maximum_minimum();

                if (chart_x_format_automatic == true)
                {
                    // if x format automatic is true then format the bounds
                    format_chart_axis(data_max_X, data_min_X, ref horizontal_bound_width, ref horizontal_bounds_maximum, ref horizontal_bounds_minimum, ref horizontal_units_major, ref horizontal_units_minor);
                }

                if (chart_y_format_automatic == true)
                {
                    // if y format automatic is true then format the bounds
                    format_chart_axis(data_max_Y, data_min_Y, ref vertical_bound_height, ref vertical_bounds_maximum, ref vertical_bounds_minimum, ref vertical_units_major, ref vertical_units_minor);
                }
            }

            private void set_maximum_minimum()
            {
                // Set extremes
                data_max_X = Double.MinValue;
                data_max_Y = Double.MinValue;

                data_min_X = Double.MaxValue;
                data_min_Y = Double.MaxValue;

                foreach (data_series_store data_series in data_series_list)
                {
                    // set max x
                    data_max_X = Math.Max(data_series._max_X, data_max_X);
                    // set min x
                    data_min_X = Math.Min(data_series._min_X, data_min_X);

                    // set max y
                    data_max_Y = Math.Max(data_series._max_Y, data_max_Y);
                    // set min X
                    data_min_Y = Math.Min(data_series._min_Y, data_min_Y);
                }
            }

            private void format_chart_axis(double dMax, double dMin, ref double bound_dist, ref double bounds_maximum, ref double bounds_minimum,
                                                                   ref double units_major, ref double units_minor)
            {
                // VBA Code from Jon Peltier, Kyle Whitmire, Slightly modified and implemented in C#
                // Primary variables
                double dPower, dScale, dSmall, dTemp;

                // Check if max and min are the same
                if (dMax == dMin)
                {
                    dTemp = dMax;
                    dMax = dMax * 1.01;
                    dMin = dMin * 0.99;
                }

                // Make dMax a little bigger and dMin a little smaller (by 1% of their difference)
                // dMax a little bigger
                if (dMax > 0)
                {
                    dMax = dMax + ((dMax - dMin) * 0.01);
                }
                else if (dMax < 0)
                {
                    dMax = Math.Max(dMax + (dMax - dMin) * 0.01, 0);
                }
                else
                {
                    dMax = 0;
                }

                // dMin a little smaller
                if (dMin > 0)
                {
                    dMin = Math.Max(dMin - (dMax - dMin) * 0.01, 0);
                }
                else if (dMin < 0)
                {
                    dMin = dMin - ((dMax - dMin) * 0.01);
                }
                else
                {
                    dMin = 0;
                }

                // What if they are both 0?
                if ((dMax == 0) && (dMin == 0))
                {
                    dMax = 1;
                }

                // This bit rounds the maximum and minimum values to reasonable values
                // to chart.  If not done, the axis numbers will look very silly
                // Find the range of values covered
                dPower = Math.Log(dMax - dMin, 10) / Math.Log(10, 10);
                dScale = Math.Pow(10, (dPower - Convert.ToInt32(dPower)));

                // Find the scaling factor
                if (dScale > 0 && dScale < 2.5)
                {
                    dScale = 0.2;
                    dSmall = 0.05;
                }
                else if (dScale > 2.5 && dScale < 5)
                {
                    dScale = 0.5;
                    dSmall = 0.1;
                }
                else if (dScale > 5 && dScale < 7.5)
                {
                    dScale = 1;
                    dSmall = 0.2;
                }
                else
                {
                    dScale = 2;
                    dSmall = 0.5;
                }


                // Calculate the scaling factor (major & minor unit)
                dScale = dScale * Math.Pow(10, Convert.ToInt32(dPower));
                dSmall = dSmall * Math.Pow(10, Convert.ToInt32(dPower));


                // Round the axis values to the nearest scaling factor
                bounds_minimum = dScale * (Convert.ToInt32(dMin / dScale) - 1);
                bounds_maximum = dScale * (Convert.ToInt32(dMax / dScale) + 1);
                units_minor = dSmall;
                units_major = dScale;
                bound_dist = bounds_maximum - bounds_minimum;
            }

            public class data_series_store
            {
                // Type
                int unique_id; // unique id
                bool show_chart;

                int chart_type; // 0 - Scatter, 1 - Scatter with straight lines, 2 - Scatter with straight line and markers,
                                // 3 - Scatter with smooth lines, 4 - Scatter with smooth lines and markers
                int marker_type;  // 0 - circle, 1 - filled circle, 2 - rectangle, 3 - filled rectangle 
                                  // 4 - triangle, 5 - filled triangle
                int line_pattern_type; // 0 - solid, 1 - dash 31, 2 - dash 32
                float[] pattern_set = new float[] { 3 }; // deflault is solid
                int marker_size;
                int line_width;
                Color chart_color;
                List<double> X_vals;
                List<double> Y_vals;
                string series_name;

                public readonly double _max_X;
                public readonly double _max_Y;
                public readonly double _min_X;
                public readonly double _min_Y;

                #region "Public read only properties"
                public string _menuitem_name
                {
                    get { return "data_series" + unique_id; }
                }

                public bool _show_chart
                {
                    get { return show_chart; }
                }

                public string _series_name
                {
                    get { return series_name; }
                }

                public Color _chart_color
                {
                    get { return chart_color; }
                }

                public int _chart_type
                {
                    get { return chart_type; }
                }

                public int _marker_type
                {
                    get { return marker_type; }
                }

                public int _line_width
                {
                    get { return line_width; }
                }

                public int _line_pattern
                {
                    get { return line_pattern_type; }
                }
                #endregion

                public data_series_store(string i_series_name, int uniq_id, List<double> i_x_vals, List<double> i_y_vals, Color i_chart_color, int i_chrat_type = 4, int i_marker_type = 3, int i_marker_size = 4, int i_line_width = 2, int i_line_pattern = 0)
                {
                    unique_id = uniq_id;
                    show_chart = true;
                    // Set series name
                    series_name = i_series_name;

                    // Add the x_y
                    X_vals = new List<double>();
                    X_vals.AddRange(i_x_vals);

                    Y_vals = new List<double>();
                    Y_vals.AddRange(i_y_vals);

                    // chart color
                    chart_color = i_chart_color;

                    // Manage types
                    chart_type = i_chrat_type;
                    marker_type = i_marker_type;
                    marker_size = i_marker_size;
                    line_width = i_line_width;
                    line_pattern_type = i_line_pattern;

                    // Set the maximum and minimum
                    _max_X = X_vals.Max();
                    _min_X = X_vals.Min();

                    _max_Y = Y_vals.Max();
                    _min_Y = Y_vals.Min();
                }

                public void update_chart_view(bool i_show_chart)
                {
                    show_chart = i_show_chart;
                }

                public void format_this_data_series(string i_data_series_name, Color i_chart_color, int i_chart_type, int i_marker_type, int i_line_width, int i_pattern)
                {
                    // Series name
                    series_name = i_data_series_name;
                    // chart color
                    chart_color = i_chart_color;
                    // chart type
                    chart_type = i_chart_type;
                    // marker type
                    marker_type = i_marker_type;
                    // Line width
                    line_width = i_line_width;
                    // Line pattern
                    line_pattern_type = i_pattern;
                    // Set tje dash pattern float
                    if (line_pattern_type == 0)
                    {
                        // solid pattern
                        pattern_set = new float[] { 1 };
                    }
                    else if (line_pattern_type == 1)
                    {
                        // Dash pattern 3 1
                        pattern_set = new float[] { 3, 1 };
                    }
                    else if (line_pattern_type == 2)
                    {
                        // Dash pattern 4 1
                        pattern_set = new float[] { 4, 1 };
                    }
                    else if (line_pattern_type == 3)
                    {
                        // Dash pattern 1 3
                        pattern_set = new float[] { 1, 3 };
                    }
                    else if (line_pattern_type == 4)
                    {
                        // Dash pattern 1 1
                        pattern_set = new float[] { 1, 1 };
                    }
                    else if (line_pattern_type == 5)
                    {
                        // Dash pattern 3 1 1 1
                        pattern_set = new float[] { 3, 1, 1, 1 };
                    }
                    else if (line_pattern_type == 6)
                    {
                        // Dash pattern 4 2 2 2
                        pattern_set = new float[] { 4, 2, 2, 2 };
                    }

                }

                public void paint_chart(ref Graphics gr0, double scaleX, double scaleY, double horiz_max, double horiz_min, double vert_max, double vert_min)
                {
                    double tempX, tempY;
                    PointF temp_pt;
                    int var_count = Math.Min(X_vals.Count, Y_vals.Count);
                    List<PointF>[] all_pts = new List<PointF>[100];
                    int seg_k = -1;

                    // segment break control
                    bool seg_break = true;

                    // intial declaration
                    // all_pts[0] = new List<PointF>();

                    for (int i = 0; i < var_count; i++)
                    {
                        // Skip if the points are beyond bounds
                        if (X_vals[i] < horiz_min || X_vals[i] > horiz_max || Y_vals[i] < vert_min || Y_vals[i] > vert_max)
                        {
                            seg_break = true;
                            continue;
                        }
                        else if (seg_break == true)
                        {
                            seg_break = false;
                            seg_k++;
                            if (seg_k == 100) // Exit if the segment reaches 100
                                return;
                            all_pts[seg_k] = new List<PointF>();
                        }


                        tempX = (X_vals[i] - horiz_min) / (horiz_max - horiz_min);
                        tempY = (Y_vals[i] - vert_min) / (vert_max - vert_min);

                        // Paint the chart
                        temp_pt = new PointF(co_functions.tosingle(tempX * scaleX), co_functions.tosingle(tempY * scaleY));

                        // Add to point list
                        all_pts[seg_k].Add(temp_pt);

                        // Paint marker
                        if (chart_type == 0 || chart_type == 2 || chart_type == 4)
                        {
                            // 0 - Scatter, 2 - Scatter with smooth lines and markers, 4 - Scatter with straight line and markers
                            paint_marker(ref gr0, temp_pt);
                        }
                    }

                    if (chart_type == 1 || chart_type == 2)
                    {
                        // Paint chart straight lines
                        for (int i = 0; i <= seg_k; i++)
                        {
                            using (Pen dashed_pen = new Pen(Color.FromArgb(240, chart_color), line_width))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;

                                dashed_pen.DashPattern = pattern_set;

                                gr0.DrawLines(dashed_pen, all_pts[i].ToArray());
                            }

                            // gr0.DrawLines(new Pen(Color.FromArgb(240, chart_color), line_width), all_pts[i].ToArray());
                        }
                    }
                    else if (chart_type == 3 || chart_type == 4)
                    {
                        // Paint chart smooth lines
                        for (int i = 0; i <= seg_k; i++)
                        {
                            using (Pen dashed_pen = new Pen(Color.FromArgb(240, chart_color), line_width))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;

                                dashed_pen.DashPattern = pattern_set;

                                gr0.DrawCurve(dashed_pen, all_pts[i].ToArray());
                            }
                            // gr0.DrawCurve(new Pen(Color.FromArgb(240, chart_color), line_width), all_pts[i].ToArray());
                        }
                    }

                }

                private void paint_marker(ref Graphics gr0, PointF pt)
                {
                    switch (marker_type)
                    {
                        case 0: // 0 - circle
                            gr0.DrawEllipse(new Pen(chart_color, 1), pt.X - marker_size, pt.Y - marker_size, 2 * marker_size, 2 * marker_size);
                            break;
                        case 1: // 1 - filled circle
                            gr0.FillEllipse(new Pen(chart_color, 1).Brush, pt.X - marker_size, pt.Y - marker_size, 2 * marker_size, 2 * marker_size);
                            break;
                        case 2: // 2 - rectangle
                            gr0.DrawRectangle(new Pen(chart_color, 1), pt.X - marker_size, pt.Y - marker_size, 2 * marker_size, 2 * marker_size);
                            break;
                        case 3: // 3 - filled rectangle
                            gr0.FillRectangle(new Pen(chart_color, 1).Brush, pt.X - marker_size, pt.Y - marker_size, 2 * marker_size, 2 * marker_size);
                            break;
                        case 4: // 4 - triangle
                            paint_equilateral_triangle(ref gr0, pt, false);
                            break;
                        case 5: // 5 - filled triangle
                            paint_equilateral_triangle(ref gr0, pt, true);
                            break;
                    }
                }

                private void paint_equilateral_triangle(ref Graphics gr0, PointF pt, bool fill)
                {
                    PointF[] p = new PointF[3];


                    double side_length = marker_size * Math.Sqrt(3);
                    // Calculate three vertices of the triangle
                    p[0] = new PointF(co_functions.tosingle(pt.X), co_functions.tosingle(pt.Y + (Math.Sqrt(3) / 3) * side_length));  // Top vertex
                    p[1] = new PointF(co_functions.tosingle(pt.X - (side_length / 2)), co_functions.tosingle(pt.Y - (Math.Sqrt(3) / 6) * side_length));  // Bottom left vertex
                    p[2] = new PointF(co_functions.tosingle(pt.X + (side_length / 2)), co_functions.tosingle(pt.Y - (Math.Sqrt(3) / 6) * side_length));  // Bottom right vertex

                    if (fill == true)
                    {
                        // Fill Triangle
                        gr0.FillPolygon(new Pen(chart_color, 1).Brush, p);
                    }
                    else
                    {
                        gr0.DrawPolygon(new Pen(chart_color, 1), p);
                    }
                }

            }

            #region " Painting of Chart "
            public void paint_chart(ref Graphics gr0, double pos_x, double neg_x, double pos_y, double neg_y)
            {
                // Paint chart background
                gr0.DrawEllipse(new Pen(Color.Black), -3, -3, 6, 6);

                // Draw a X line
                //gr0.DrawLine(new Pen(axis_color), 3, 0, pos_x - 3, 0);
                //gr0.DrawLine(new Pen(axis_color), 0, 3, 0, pos_y - 3);

                double scale_Xwidth, scale_Yheight;
                scale_Xwidth = pos_x + neg_x;
                scale_Yheight = pos_y + neg_y;

                if (paint_chart_title == true)
                {
                    // Paint Chart title
                    string_store c_axis_title = new string_store(chart_title.ToString(), new Font("Cambria", 20), Color.FromArgb(254, axis_color), true, false);
                    PointF c_title_pt = new PointF(co_functions.tosingle(scale_Xwidth * 0.5), -co_functions.tosingle(scale_Yheight + 50));
                    c_axis_title.paint_me(ref gr0, ref c_title_pt);
                }

                double temp_var, hx, vy;

                // Horizontal Axis
                // Draw horizontal minor axis
                if (show_horizontal_minor_grid_line == true)
                {
                    for (hx = horizontal_bounds_minimum; hx <= horizontal_bounds_maximum; hx = hx + horizontal_units_minor)
                    {
                        temp_var = (hx - horizontal_bounds_minimum) / horizontal_bound_width;
                        // minor axis
                        gr0.DrawLine(new Pen(Color.FromArgb(100, axis_color)), co_functions.tosingle(temp_var * scale_Xwidth), 0, co_functions.tosingle(temp_var * scale_Xwidth), co_functions.tosingle(pos_y + neg_y));
                    }
                }

                // Draw horizontal major axis
                for (hx = horizontal_bounds_minimum; hx <= horizontal_bounds_maximum; hx = hx + horizontal_units_major)
                {
                    temp_var = (hx - horizontal_bounds_minimum) / horizontal_bound_width;
                    // major axis
                    if (show_horizontal_major_grid_line == true)
                    {
                        gr0.DrawLine(new Pen(Color.FromArgb(240, axis_color)), co_functions.tosingle(temp_var * scale_Xwidth), 0, co_functions.tosingle(temp_var * scale_Xwidth), co_functions.tosingle(pos_y + neg_y));
                    }

                    // major axis tick
                    gr0.DrawLine(new Pen(Color.FromArgb(240, axis_color)), co_functions.tosingle(temp_var * scale_Xwidth), 0, co_functions.tosingle(temp_var * scale_Xwidth), -10);
                    // Paint majot axis title

                    string_store h_marking = new string_store(hx.ToString(), new Font("Cambria", 10), Color.FromArgb(254, axis_color), true, false);
                    PointF h_marking_pt = new PointF(co_functions.tosingle(temp_var * scale_Xwidth), 20);
                    //y_marking.paint_me(ref gr0, ref y_marking_pt);
                    h_marking.paint_me(ref gr0, ref h_marking_pt);

                }

                // Draw Horizontal axis title
                string_store h_axis_title = new string_store(horizontal_axis_title.ToString(), new Font("Cambria", 14), Color.FromArgb(254, axis_color), true, false);
                PointF h_title_pt = new PointF(co_functions.tosingle(scale_Xwidth * 0.5), 50);
                h_axis_title.paint_me(ref gr0, ref h_title_pt);

                // Vertical Axis
                // Draw vertical minor axis
                if (show_vertical_minor_grid_line == true)
                {
                    for (vy = vertical_bounds_minimum; vy <= vertical_bounds_maximum; vy = vy + vertical_units_minor)
                    {
                        temp_var = (vy - vertical_bounds_minimum) / vertical_bound_height;
                        // minor axis
                        gr0.DrawLine(new Pen(Color.FromArgb(100, axis_color)), 0, co_functions.tosingle(temp_var * scale_Yheight), co_functions.tosingle(pos_x + neg_x), co_functions.tosingle(temp_var * scale_Yheight));
                    }
                }

                // Draw vertical major axis
                for (vy = vertical_bounds_minimum; vy <= vertical_bounds_maximum; vy = vy + vertical_units_major)
                {
                    temp_var = (vy - vertical_bounds_minimum) / vertical_bound_height;
                    // major axis
                    if (show_vertical_major_grid_line == true)
                    {
                        gr0.DrawLine(new Pen(Color.FromArgb(240, axis_color)), 0, co_functions.tosingle(temp_var * scale_Yheight), co_functions.tosingle(pos_x + neg_x), co_functions.tosingle(temp_var * scale_Yheight));
                    }

                    // major axis tick
                    gr0.DrawLine(new Pen(Color.FromArgb(240, axis_color)), 0, co_functions.tosingle(temp_var * scale_Yheight), -10, co_functions.tosingle(temp_var * scale_Yheight));
                    // Paint majot axis title
                    string_store v_marking = new string_store(vy.ToString(), new Font("Cambria", 10), Color.FromArgb(254, axis_color), true, false);
                    PointF v_marking_pt = new PointF(-20, co_functions.tosingle(temp_var * scale_Yheight));
                    //y_marking.paint_me(ref gr0, ref y_marking_pt);
                    v_marking.paint_me_vertical(ref gr0, ref v_marking_pt);

                }

                // Draw vertical axis title
                string_store v_axis_title = new string_store(vertical_axis_title.ToString(), new Font("Cambria", 14), Color.FromArgb(254, axis_color), true, false);
                PointF v_title_pt = new PointF(-50, co_functions.tosingle(scale_Yheight * 0.5));
                v_axis_title.paint_me_vertical(ref gr0, ref v_title_pt);

                // Paint the graph
                for (int i = 0; i < data_series_list.Count; i++)
                {
                    if (data_series_list[i]._show_chart == true)
                    {
                        data_series_list[i].paint_chart(ref gr0, scale_Xwidth, scale_Yheight, horizontal_bounds_maximum, horizontal_bounds_minimum, vertical_bounds_maximum, vertical_bounds_minimum);
                    }
                }
            }

            // Class 3 - string values are stored in this class
            public class string_store
            {
                string my_string;
                Font my_font;
                Color my_color;
                Brush paint_brush;
                bool my_visible;
                bool paint_vertical;

                public Color my_clr
                {
                    get { return my_color; }
                }

                public Font m_fnt
                {
                    get { return my_font; }
                }

                public string_store(string str0, Font fnt0, Color clr0, bool is_visible, bool is_vertical)
                {
                    my_string = str0;
                    my_font = fnt0;
                    my_color = clr0;
                    paint_brush = new Pen(my_color, 2).Brush;
                    my_visible = is_visible;
                    paint_vertical = is_vertical;
                }

                public void paint_me_vertical(ref Graphics gr0, ref PointF location, int x_offset = 0, int y_offset = 0, bool is_bold_true = false)
                {
                    if (my_visible == true)
                    {
                        SizeF str_size = new SizeF();
                        str_size = gr0.MeasureString(my_string, my_font);
                        // Paint the x-axis in vertical alignment
                        System.Drawing.Drawing2D.GraphicsState temp_gstate = gr0.Save();

                        // Rotate text to paint in correct orientation
                        gr0.MultiplyTransform(new Matrix(1, 0, 0, -1, 0, 0));

                        gr0.TranslateTransform((location.X + x_offset - co_functions.tosingle(str_size.Height * 0.5)), -(location.Y - y_offset - co_functions.tosingle(str_size.Width * 0.5)));
                        gr0.RotateTransform(270);
                        gr0.TranslateTransform(-(location.X + x_offset - co_functions.tosingle(str_size.Height * 0.5)), (location.Y - y_offset - co_functions.tosingle(str_size.Width * 0.5)));

                        if (is_bold_true == true)
                            my_font = new Font(my_font.FontFamily, my_font.Size, FontStyle.Bold);

                        //// Rotate text to paint in correct orientation
                        //gr0.MultiplyTransform(new Matrix(1, 0, 0, -1, 0, 0));

                        gr0.DrawString(my_string, my_font, paint_brush, (location.X + x_offset - co_functions.tosingle(str_size.Height * 0.5)), -(location.Y - y_offset - co_functions.tosingle(str_size.Width * 0.5)));
                        gr0.Restore(temp_gstate);
                    }

                }

                public void paint_me(ref Graphics gr0, ref PointF location, int x_offset = 0, int y_offset = 0, bool is_bold_true = false)
                {
                    if (my_visible == true)
                    {
                        SizeF str_size = new SizeF();
                        str_size = gr0.MeasureString(my_string, my_font);

                        if (is_bold_true == true)
                            my_font = new Font(my_font.FontFamily, my_font.Size, FontStyle.Bold);


                        // Rotate text to paint in correct orientation
                        GraphicsState transState = gr0.Save();
                        gr0.MultiplyTransform(new Matrix(1, 0, 0, -1, 0, 0));

                        gr0.DrawString(my_string, my_font,
                                        paint_brush,
                                        location.X + x_offset - co_functions.tosingle(str_size.Width * 0.5),
                                        location.Y + y_offset - co_functions.tosingle(str_size.Height * 0.5));

                        gr0.Restore(transState);
                    }
                }
            }
            #endregion
        }

        public chart_view(chart_data_store inpt_charts)
        {
            // intitialize the charts
            this.the_chart = inpt_charts;

            InitializeComponent();

            // Add chart data series to menu item
            ToolStripMenuItem[] items = new ToolStripMenuItem[inpt_charts._data_series_list.Count];
            int i = 0;
            foreach (chart_data_store.data_series_store i_data_series in inpt_charts._data_series_list)
            {

                // Tool strip add menu item
                items[i] = new ToolStripMenuItem();
                items[i].Name = i_data_series._menuitem_name;
                items[i].Text = i_data_series._series_name;
                items[i].Click += new EventHandler(MenuItemClickHandler);
                items[i].CheckOnClick = true;
                items[i].Checked = true;
                i++;
            }

            dataSeriesToolStripMenuItem.DropDownItems.AddRange(items);

            mt_pic.Refresh();
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            // Take some action based on the data in clickedItem

            // Find the data series which is being clicked
            foreach (chart_data_store.data_series_store i_data_series in the_chart._data_series_list)
            {
                if (i_data_series._menuitem_name == clickedItem.Name)
                {
                    i_data_series.update_chart_view(clickedItem.Checked);
                    mt_pic.Refresh();
                    return;
                }
            }
        }

        private void main_pic_Paint(object sender, PaintEventArgs e)
        {
            // Smoothing 
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float mid_x = co_functions.tosingle(main_pic.Width * 0.1);
            float mid_y = co_functions.tosingle(1 * main_pic.Height * 0.85);

            e.Graphics.ScaleTransform(1, -1);
            e.Graphics.TranslateTransform(mid_x, -1 * mid_y);


            Graphics gr0 = e.Graphics;
            // Paint the chart
            this.the_chart.paint_chart(ref gr0, co_functions.tosingle(main_pic.Width * 0.9), -co_functions.tosingle(main_pic.Width * 0.1), co_functions.tosingle(main_pic.Height * 0.85), -co_functions.tosingle(main_pic.Height * 0.15));
        }

        private void main_pic_SizeChanged(object sender, EventArgs e)
        {
            // Size changes
            mt_pic.Refresh();
        }


        #region " Format Chart"
        private void formatChartAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart_option_form = new chart_option(this, ref the_chart, 0);
            chart_option_form.ShowDialog();
        }

        private void formatHorizontalAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart_option_form = new chart_option(this, ref the_chart, 1);
            chart_option_form.ShowDialog();
        }

        private void formatVerticalAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart_option_form = new chart_option(this, ref the_chart, 2);
            chart_option_form.ShowDialog();
        }

        private void formatDataSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart_option_form = new chart_option(this, ref the_chart, 3);
            chart_option_form.ShowDialog();
        }
        #endregion

    }
}
