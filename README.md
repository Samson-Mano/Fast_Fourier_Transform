# Fast Fourier Transform  <br />
C# implementation of Cooley–Tukey's FFT algorithm. <br />
Cooley–Tukey's fast Fourier transform (FFT) algorithm is a method for computing the finite Fourier transform of a series of N (complex) data points in approximately
N log, N operations. FFT operates on inputs that contain an integer power of two number of samples, the input data length will be augmented by zero padding at the end. <br />
A chart visualizer tool is developed to visualize the input and output data. <br />

![](/Fast_fourier_transform/Images/data_view.png)<br /><br />

# Example 1  <br />
Simple cosine function 10 hz <br />
![](/Fast_fourier_transform/Images/td_cos_example.png)<br /><br />
![](/Fast_fourier_transform/Images/fft_cos_example.png)<br /><br />

# Example 2  <br />
Summation of cos and sin functions 10, 20 30 and 70 hz
![](/Fast_fourier_transform/Images/example_1.png)<br /><br />
![](/Fast_fourier_transform/Images/timeseries_combinationt1.png)<br /><br />
![](/Fast_fourier_transform/Images/FFT_combinationt1.png)<br /><br />

# Example 3  <br />
Sine sweep 10 to 40 Hz 1G at 0.5 octave
![](/Fast_fourier_transform/Images/sinesweep_td.png)<br /><br />
![](/Fast_fourier_transform/Images/sinesweep_fft.png)<br /><br />

# References  <br />
•	 https://en.wikipedia.org/wiki/Cooley%E2%80%93Tukey_FFT_algorithm  <br />
•	 https://rosettacode.org/wiki/Fast_Fourier_transform#C.23  <br />
•	 https://github.com/tha7556/Signal-Processing/blob/master/Signal%20Processing/Project3/Fourier.cs  <br />
•	 http://paulbourke.net/miscellaneous/dft/  <br />
•	 https://dsp.stackexchange.com/questions/36955/considering-the-fft-of-real-complex-signals  <br />
•	 https://www.reed.edu/physics/courses/Physics331.f08/pdf/Fourier.pdf  <br />
•	 https://www.gaussianwaves.com/2015/11/interpreting-fft-results-obtaining-magnitude-and-phase-information/   <br />
•	 https://www.gaussianwaves.com/2015/11/interpreting-fft-results-complex-dft-frequency-bins-and-fftshift/  <br />
 <br />
Below used for chart visualizer development  <br />
•	 https://peltiertech.com/calculate-nice-axis-scales-in-your-excel-worksheet/  <br />
•	 https://peltiertech.com/calculate-nice-axis-scales-in-excel-vba/  <br />
