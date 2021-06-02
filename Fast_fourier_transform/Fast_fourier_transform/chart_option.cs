using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_fourier_transform
{
    public partial class chart_option : Form
    {
        chart_view my_parent_form;
        chart_view.chart_data_store the_chart;
        int tab_id;

        public chart_option(chart_view t_form, ref chart_view.chart_data_store t_the_chart, int i_tab_id)
        {
            InitializeComponent();

            my_parent_form = t_form;
            the_chart = t_the_chart;
            tab_id = i_tab_id;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // tab id
            if (tab_id == 0)
            {
                // Format chart area
                the_chart.format_chart_area(textBox_chart_title.Text, checkBox_show_chart_title.Checked, button_axis_color.BackColor);
            }
            else if (tab_id == 1)
            {
                // Format horizontal axis
                if (radioButton_h_automatic.Checked == true)
                {
                    the_chart.format_horizontal_axis(textBox_h_axis_title.Text, 0, 0, 0, 0, checkBox_h_major_gridlines.Checked, checkBox_h_minor_gridlines.Checked, true);
                }
                else
                {
                    // Check the validity of bounds
                    if (co_functions.Test_a_textboxvalue_validity(textBox_h_max_bounds.Text, false, false) == true &&
                       co_functions.Test_a_textboxvalue_validity(textBox_h_min_bounds.Text, false, false) == true &&
                       co_functions.Test_a_textboxvalue_validity(textBox_h_major_units.Text, false, false) == true &&
                       co_functions.Test_a_textboxvalue_validity(textBox_h_minor_units.Text, false, false) == true)
                    {
                        double t_h_max_bounds, t_h_min_bounds, t_h_maj_units, t_h_min_units;
                        t_h_max_bounds = Convert.ToDouble(textBox_h_max_bounds.Text);
                        t_h_min_bounds = Convert.ToDouble(textBox_h_min_bounds.Text);
                        t_h_maj_units = Convert.ToDouble(textBox_h_major_units.Text);
                        t_h_min_units = Convert.ToDouble(textBox_h_minor_units.Text);

                        // Check the validity of the bounds
                        if (t_h_max_bounds > t_h_min_bounds && t_h_maj_units > t_h_min_units)
                        {
                            the_chart.format_horizontal_axis(textBox_h_axis_title.Text, t_h_max_bounds, t_h_min_bounds, t_h_maj_units, t_h_min_units, checkBox_h_major_gridlines.Checked, checkBox_h_minor_gridlines.Checked, false);
                        }
                    }
                }

            }
            else if (tab_id == 2)
            {
                // Format vertical axis
                if (radioButton_v_automatic.Checked == true)
                {
                    the_chart.format_vertical_axis(textBox_v_axis_title.Text, 0, 0, 0, 0, checkBox_v_major_gridlines.Checked, checkBox_v_minor_gridlines.Checked, true);
                }
                else
                {
                    // Check the validity of bounds
                    if (co_functions.Test_a_textboxvalue_validity(textBox_v_max_bounds.Text, false, false) == true &&
                       co_functions.Test_a_textboxvalue_validity(textBox_v_min_bounds.Text, false, false) == true &&
                       co_functions.Test_a_textboxvalue_validity(textBox_v_major_units.Text, false, false) == true &&
                       co_functions.Test_a_textboxvalue_validity(textBox_v_minor_units.Text, false, false) == true)
                    {
                        double t_v_max_bounds, t_v_min_bounds, t_v_maj_units, t_v_min_units;
                        t_v_max_bounds = Convert.ToDouble(textBox_v_max_bounds.Text);
                        t_v_min_bounds = Convert.ToDouble(textBox_v_min_bounds.Text);
                        t_v_maj_units = Convert.ToDouble(textBox_v_major_units.Text);
                        t_v_min_units = Convert.ToDouble(textBox_v_minor_units.Text);

                        // Check the validity of the bounds
                        if (t_v_max_bounds > t_v_min_bounds && t_v_maj_units > t_v_min_units)
                        {
                            the_chart.format_vertical_axis(textBox_v_axis_title.Text, t_v_max_bounds, t_v_min_bounds, t_v_maj_units, t_v_min_units, checkBox_v_major_gridlines.Checked, checkBox_v_minor_gridlines.Checked, false);
                        }
                    }
                }
            }
            else if (tab_id == 3)
            {
                // Format data series
                int s_index = comboBox_dataseries_list.SelectedIndex;

                the_chart.format_data_series(s_index, textBox_data_series_list.Text, button_data_color.BackColor, comboBox_charttype.SelectedIndex, comboBox_markertype.SelectedIndex, comboBox_linewidth.SelectedIndex + 1,comboBox_linepattern.SelectedIndex);

                set_data_series_list();
            }
            my_parent_form.mt_pic.Refresh();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart_option_Load(object sender, EventArgs e)
        {
            // Form load
            // tab id
            if (tab_id == 0)
            {
                // Format chart area
                textBox_chart_title.Text = the_chart._chart_title;
                button_axis_color.BackColor = the_chart._axis_color;
                checkBox_show_chart_title.Checked = the_chart._paint_chart_title;

                // Remove other tabs
                tabControl_chart.TabPages.Remove(tabPage_horizontal_axis);
                tabControl_chart.TabPages.Remove(tabPage_vertical_axis);
                tabControl_chart.TabPages.Remove(tabPage_data_series);
            }
            else if (tab_id == 1)
            {
                // Format horizontal axis
                textBox_h_axis_title.Text = the_chart._horizontal_axis_title;
                textBox_h_max_bounds.Text = the_chart._horizontal_bounds_maximum.ToString();
                textBox_h_min_bounds.Text = the_chart._horizontal_bounds_minimum.ToString();
                textBox_h_major_units.Text = the_chart._horizontal_units_major.ToString();
                textBox_h_minor_units.Text = the_chart._horizontal_units_minor.ToString();
                checkBox_h_major_gridlines.Checked = the_chart._show_horizontal_major_grid_line;
                checkBox_h_minor_gridlines.Checked = the_chart._show_horizontal_minor_grid_line;
                if (the_chart._chart_x_format_automatic == true)
                {
                    radioButton_h_automatic.Checked = true;
                    radioButton_h_axis_value.Checked = false;
                }
                else
                {
                    radioButton_h_automatic.Checked = false;
                    radioButton_h_axis_value.Checked = true;
                }

                automatic_option_control();
                // Remove other tabs
                tabControl_chart.TabPages.Remove(tabPage_chart_area);
                tabControl_chart.TabPages.Remove(tabPage_vertical_axis);
                tabControl_chart.TabPages.Remove(tabPage_data_series);
            }
            else if (tab_id == 2)
            {
                // Format vertical axis
                textBox_v_axis_title.Text = the_chart._vertical_axis_title;
                textBox_v_max_bounds.Text = the_chart._vertical_bounds_maximum.ToString();
                textBox_v_min_bounds.Text = the_chart._vertical_bounds_minimum.ToString();
                textBox_v_major_units.Text = the_chart._vertical_units_major.ToString();
                textBox_v_minor_units.Text = the_chart._vertical_units_minor.ToString();
                checkBox_v_major_gridlines.Checked = the_chart._show_vertical_major_grid_line;
                checkBox_v_minor_gridlines.Checked = the_chart._show_vertical_minor_grid_line;
                if (the_chart._chart_y_format_automatic == true)
                {
                    radioButton_v_automatic.Checked = true;
                    radioButton_v_axis_value.Checked = false;
                }
                else
                {
                    radioButton_v_automatic.Checked = false;
                    radioButton_v_axis_value.Checked = true;
                }

                automatic_option_control();
                // Remove other tabs
                tabControl_chart.TabPages.Remove(tabPage_chart_area);
                tabControl_chart.TabPages.Remove(tabPage_horizontal_axis);
                tabControl_chart.TabPages.Remove(tabPage_data_series);
            }
            else if (tab_id == 3)
            {
                // Format data series
                // Add to combobox list
                foreach (chart_view.chart_data_store.data_series_store ds in the_chart._data_series_list)
                {
                    comboBox_dataseries_list.Items.Add(ds._series_name);
                }

                comboBox_dataseries_list.SelectedIndex = 0;
                set_data_series_list();

                // Remove other tabs
                tabControl_chart.TabPages.Remove(tabPage_chart_area);
                tabControl_chart.TabPages.Remove(tabPage_horizontal_axis);
                tabControl_chart.TabPages.Remove(tabPage_vertical_axis);
            }
        }

        private void button_axis_color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                button_axis_color.BackColor = colorDlg.Color;
            }
        }

        private void button_data_color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                button_data_color.BackColor = colorDlg.Color;
            }
        }

        private void set_data_series_list()
        {
            int s_index = comboBox_dataseries_list.SelectedIndex;

            //comboBox_dataseries_list.Items[s_index] = the_chart._data_series_list[s_index]._series_name;
            //comboBox_dataseries_list.SelectedIndex = s_index;
            // data series name
            textBox_data_series_list.Text = the_chart._data_series_list[s_index]._series_name;
            // data series color
            button_data_color.BackColor = the_chart._data_series_list[s_index]._chart_color;
            // data series chart type
            comboBox_charttype.SelectedIndex = the_chart._data_series_list[s_index]._chart_type;
            // data series marker type
            comboBox_markertype.SelectedIndex = the_chart._data_series_list[s_index]._marker_type;
            // data series line width
            comboBox_linewidth.SelectedIndex = the_chart._data_series_list[s_index]._line_width-1;
            // Line pattern
            comboBox_linepattern.SelectedIndex = the_chart._data_series_list[s_index]._line_pattern;
        }

        private void automatic_option_control()
        {
            if (tab_id == 1)
            {
                // If automatic is checked
                if (radioButton_h_automatic.Checked == false)
                {
                    // Disable horizontal axis bound input
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = true;
                    label4.Enabled = true;

                    textBox_h_max_bounds.Enabled = true;
                    textBox_h_min_bounds.Enabled = true;
                    textBox_h_major_units.Enabled = true;
                    textBox_h_minor_units.Enabled = true;
                }
                else
                {
                    // Enable horizontal axis bound input
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    label4.Enabled = false;

                    textBox_h_max_bounds.Enabled = false;
                    textBox_h_min_bounds.Enabled = false;
                    textBox_h_major_units.Enabled = false;
                    textBox_h_minor_units.Enabled = false;
                }
            }
            else if (tab_id == 2)
            {
                // If automatic is checked
                if (radioButton_v_automatic.Checked == false)
                {
                    // Disable vertical axis bound input
                    label9.Enabled = true;
                    label10.Enabled = true;
                    label11.Enabled = true;
                    label12.Enabled = true;

                    textBox_v_max_bounds.Enabled = true;
                    textBox_v_min_bounds.Enabled = true;
                    textBox_v_major_units.Enabled = true;
                    textBox_v_minor_units.Enabled = true;
                }
                else
                {
                    // Enable vertical axis bound input
                    label9.Enabled = false;
                    label10.Enabled = false;
                    label11.Enabled = false;
                    label12.Enabled = false;

                    textBox_v_max_bounds.Enabled = false;
                    textBox_v_min_bounds.Enabled = false;
                    textBox_v_major_units.Enabled = false;
                    textBox_v_minor_units.Enabled = false;
                }
            }
        }

        private void radioButton_h_automatic_CheckedChanged(object sender, EventArgs e)
        {
            automatic_option_control();
        }

        private void radioButton_h_axis_value_CheckedChanged(object sender, EventArgs e)
        {
            automatic_option_control();
        }

        private void radioButton_v_automatic_CheckedChanged(object sender, EventArgs e)
        {
            automatic_option_control();
        }

        private void radioButton_v_axis_value_CheckedChanged(object sender, EventArgs e)
        {
            automatic_option_control();
        }

        private void comboBox_dataseries_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            set_data_series_list();
        }

    }
}
