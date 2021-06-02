# Fast_Fourier_Transform  <br />
C# implementation of Cooley–Tukey's FFT algorithm. <br />
Cooley–Tukey's fast Fourier transform (FFT) algorithm is a method for computing the finite Fourier transform of a series of N (complex) data points in approximately
N log, N operations. <br />
FFT operates on inputs that contain an integer power of two number of samples, the input data length will be augmented by zero padding at the end. <br />
A chart visualizer tool is developed to visualize the input and output data. <br />

# Example 1  <br />
Simple cosine function 10 hz <br />
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />

# Example 2  <br />
Summation of cos and sin functions 10, 20 30 and 70 hz
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />

# Example 3  <br />
Sine sweep 10 to 40 Hz 1G at 0.5 octave
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />
![](/Lagrange_points/Images/lpt_065.PNG)<br /><br />

# References  <br />
•	 https://en.wikipedia.org/wiki/Cooley%E2%80%93Tukey_FFT_algorithm
•	 https://rosettacode.org/wiki/Fast_Fourier_transform#C.23
•	 https://github.com/tha7556/Signal-Processing/blob/master/Signal%20Processing/Project3/Fourier.cs
•	 http://paulbourke.net/miscellaneous/dft/
•	 https://dsp.stackexchange.com/questions/36955/considering-the-fft-of-real-complex-signals
•	 https://www.reed.edu/physics/courses/Physics331.f08/pdf/Fourier.pdf
•	 https://www.gaussianwaves.com/2015/11/interpreting-fft-results-obtaining-magnitude-and-phase-information/ 
•	 https://www.gaussianwaves.com/2015/11/interpreting-fft-results-complex-dft-frequency-bins-and-fftshift/

Below used for chart visualizer development
•	 https://peltiertech.com/calculate-nice-axis-scales-in-your-excel-worksheet/
•	 https://peltiertech.com/calculate-nice-axis-scales-in-excel-vba/
