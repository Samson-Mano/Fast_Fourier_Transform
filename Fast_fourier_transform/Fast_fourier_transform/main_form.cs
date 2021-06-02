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
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            // Show the paste button
            if (e.Button == MouseButtons.Right)
            {

                contextMenuStrip_datagridview.Show(dataGridView_timedomain, new Point(e.X, e.Y));
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Paste the data from excel format
            write_data_to_datagridview(Clipboard.GetText(), ref dataGridView_timedomain); ;
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the existing datas
            dataGridView_timedomain.Rows.Clear();
            dataGridView_timedomain.Refresh();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Import data
            import_data_from_textfile();
        }

        private void showChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show chart
            show_time_domain_chart();
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            // Import data
            import_data_from_textfile();
        }

        private void button_td_chart_Click(object sender, EventArgs e)
        {
            // Show time domain chart
            show_time_domain_chart();
        }

        private void button_fd_chart_Click(object sender, EventArgs e)
        {
            // show frequency domain chart
            show_frequency_domain_chart();
        }

        private void import_data_from_textfile()
        {
            // Import of Nodes from a Text File
            OpenFileDialog openfiledialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\"
            openfiledialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openfiledialog1.FilterIndex = 2;
            openfiledialog1.RestoreDirectory = true;

            if (openfiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // StreamReader txtreader = new StreamReader(File.OpenRead(openfiledialog1.FileName), Encoding.UTF8, true, 128);

                    string text = System.IO.File.ReadAllText(openfiledialog1.FileName);

                    write_data_to_datagridview(text,ref dataGridView_timedomain);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot read file from disk. Original error: " + ex.Message.ToString());
                }
            }
            openfiledialog1.Dispose();
        }

        private void write_data_to_datagridview(string s, ref DataGridView inpt_data_gridview)
        {
            try
            {
                // string s = Clipboard.GetText();

                string[] lines = s.Replace("\n", "").Split('\r');

                // Check 1
                if (lines.Length < 2)
                    return;

                // Check 2
                if (lines[0].Split('\t').Count() != 2)
                    return;

                // Clear the existing datas
                inpt_data_gridview.Rows.Clear();
                inpt_data_gridview.Refresh();

                inpt_data_gridview.Rows.Add(lines.Length - 1);
                string[] fields;
                int row = 0;
                int col = 0;

                foreach (string item in lines)
                {
                    fields = item.Split('\t');

                    foreach (string f in fields)
                    {
                        Console.WriteLine(f);
                        inpt_data_gridview[col, row].Value = f;
                        col++;
                    }
                    row++;
                    col = 0;
                }
            }
            catch (FormatException)
            {
                // MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }

        private void show_time_domain_chart()
        {
            // Check enough data is avaialble
            if (dataGridView_timedomain.Rows.Count < 2)
                return;

            // add chart
            // create data series
            List<double> x_datas = new List<double>();
            List<double> y_datas = new List<double>();

            foreach (DataGridViewRow dr in dataGridView_timedomain.Rows)
            {
                // Test empty string
                if (dr.Cells["Column_time"].Value.ToString() == "" || dr.Cells["Column_amplitude"].Value.ToString() == "")
                    continue;

                // Test the validity of data
                if (co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_time"].Value.ToString(), false, false) == false || co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_amplitude"].Value.ToString(), false, false) == false)
                    continue;

                // Add to x_datas, y_datas list
                x_datas.Add(Convert.ToDouble(dr.Cells["Column_time"].Value));
                y_datas.Add(Convert.ToDouble(dr.Cells["Column_amplitude"].Value));
            }

            // create chart data series  (unique id number)
            chart_view.chart_data_store.data_series_store c_data_series;
            c_data_series = new chart_view.chart_data_store.data_series_store("Time domain values",0, x_datas, y_datas, Color.BlueViolet,4,1);

            // Create chart data store
            chart_view.chart_data_store chart_data = new chart_view.chart_data_store("Time Domain", "Time (s)", "Amplitude");

            // Add data series
            chart_data.chart_add_data_series(c_data_series);

            chart_view chart_view_form = new chart_view(chart_data);

            chart_view_form.Show();
        }

        private void show_frequency_domain_chart()
        {
            // Check enough data is avaialble
            if (dataGridView_frequencydomain.Rows.Count < 2)
                return;

            // add chart
            // create data series
            List<double> f_datas = new List<double>();
            List<double> mag_datas = new List<double>();
            List<double> phase_datas = new List<double>();
            List<double> real_datas = new List<double>();
            List<double> img_datas = new List<double>();

            foreach (DataGridViewRow dr in dataGridView_frequencydomain.Rows)
            {
                // Test empty string
                if (dr.Cells["Column_freq"].Value.ToString() == "" || 
                    dr.Cells["Column_magnitude"].Value.ToString() == "" || 
                    dr.Cells["Column_phase"].Value.ToString() == "" || 
                    dr.Cells["Column_real"].Value.ToString() == "" ||
                    dr.Cells["Column_img"].Value.ToString() == "")
                    continue;

                // Test the validity of data
                if (co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_freq"].Value.ToString(), false, false) == false || 
                    co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_magnitude"].Value.ToString(), false, false) == false ||
                    co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_phase"].Value.ToString(), false, false) == false ||
                    co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_real"].Value.ToString(), false, false) == false ||
                    co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_img"].Value.ToString(), false, false) == false)
                    continue;

                // Add to x_datas, y_datas list
                f_datas.Add(Convert.ToDouble(dr.Cells["Column_freq"].Value));
                mag_datas.Add(Convert.ToDouble(dr.Cells["Column_magnitude"].Value));
                phase_datas.Add(Convert.ToDouble(dr.Cells["Column_phase"].Value));
                real_datas.Add(Convert.ToDouble(dr.Cells["Column_real"].Value));
                img_datas.Add(Convert.ToDouble(dr.Cells["Column_img"].Value));
            }

            // create chart data series  (unique id number)
            chart_view.chart_data_store.data_series_store c_data_series1, c_data_series2, c_data_series3, c_data_series4;
            c_data_series1 = new chart_view.chart_data_store.data_series_store("Magnitude", 0, f_datas, mag_datas, Color.Green,4,2);
            c_data_series2 = new chart_view.chart_data_store.data_series_store("Phase", 1, f_datas, phase_datas, Color.Violet,3,1);
            c_data_series3 = new chart_view.chart_data_store.data_series_store("Real", 2, f_datas, real_datas, Color.DarkRed,4,1);
            c_data_series4 = new chart_view.chart_data_store.data_series_store("img", 3, f_datas, img_datas, Color.RosyBrown,4,2);

            // Create chart data store
            chart_view.chart_data_store chart_data = new chart_view.chart_data_store("Frequency Domain", "Frequency (Hz)", "Magnitude/ Phase/ Real/ Img");

            // Add data series
            chart_data.chart_add_data_series(c_data_series1);
            chart_data.chart_add_data_series(c_data_series2);
            chart_data.chart_add_data_series(c_data_series3);
            chart_data.chart_add_data_series(c_data_series4);

            chart_view chart_view_form = new chart_view(chart_data);

            chart_view_form.Show();


        }

        private void button_fft_Click(object sender, EventArgs e)
        {
            // Check enough data is avaialble
            if (dataGridView_timedomain.Rows.Count < 2)
                return;

            
            // create data series
            List<double> x_datas = new List<double>();
            List<double> y_datas = new List<double>();

            foreach (DataGridViewRow dr in dataGridView_timedomain.Rows)
            {
                // Test empty string
                if (dr.Cells["Column_time"].Value.ToString() == "" || dr.Cells["Column_amplitude"].Value.ToString() == "")
                    continue;

                // Test the validity of data
                if (co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_time"].Value.ToString(), false, false) == false || co_functions.Test_a_textboxvalue_validity(dr.Cells["Column_amplitude"].Value.ToString(), false, false) == false)
                    continue;

                // Add to x_datas, y_datas list
                x_datas.Add(Convert.ToDouble(dr.Cells["Column_time"].Value));
                y_datas.Add(Convert.ToDouble(dr.Cells["Column_amplitude"].Value));
            }

            // Fast Fourier Transform
            process_data pd = new process_data(x_datas, y_datas);

            // Add the results to datagridview
            // Clear the existing datas
            dataGridView_frequencydomain.Rows.Clear();
            dataGridView_frequencydomain.Refresh();

            for (int i = 0;i<pd.fft_output.Count;i++)
            {
                dataGridView_frequencydomain.Rows.Add(pd.freq_output[i].ToString(),
                                                      pd.fft_output[i].GetMagnitude().ToString(),
                                                      pd.fft_output[i].GetPhase().ToString(),
                                                      pd.fft_output[i].Real.ToString(),
                                                      pd.fft_output[i].Imag.ToString());
            }


        }

    }
}
