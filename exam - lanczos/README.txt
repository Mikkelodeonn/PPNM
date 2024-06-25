Exam question 12: Lanczos tridiagonalization algorithm.

A) Implement the Lanczos tridiagonalization algorithm for real symmetric matrices.

I have succesfully implemented the Lanczos tridiagonalization algorithm for real symmetric matrices, as described in the provided Wikipedia article. 
The method containing the implementation takes a matrix 'A' and an integer 'n' as inputs. 'A' being a real symmetric matrix of dimension 'N' and 'n' the 
number of Lanczos iterations, and thus also the dimension of the resulting tridiagonal matrix 'T'. The algorithm further outputs the matrix 'V', containing 
orthonormal columns and fulfilling the identity T = V^T*A*V. I have tested the algorithm and provided checks for the case of n=N and n<N.

B) Consider the hydrogen atom using our discretization method with the given Δr and rmax=NΔr. 
Use the Lanczos iteration algorithm and build a size-n (where n≤N) tridiagonal representation T of the Hamiltonian. 
Calculate the ground state energy of the matrix T. Investigate the convergence of the ground state energy as function of n.

I built the Hamiltonian matrix representation of Hydrogen using the procedure outlined in the "eigenvalues" homework, with rmax=8 Bohr radii and 
dr=0.1 Bohr radii. I then used my Lanczos method to approximate the Hamiltonian on a tridiagonal form 'T', and calculated the lowest eigenvalue 
(i.e. the ground state energy), by QR diagonalization (I wanted to use something other than the Jacobi eigenvalue algorithm, as that was to be 
explored in exercise C). Finally, I plotted the convergence of the ground state energy as a function of n<=N.


C) Check whether Jacobi eigenvalue algorithm can be tuned to take advantage of the tridiagonal form of a matrix.

To check this I rewrote my cyclic sweep Jacobi routine to only perform rotations on the non-zero elements of a tridiagonal matrix. Then I confirmed that 
the regular and tuned Jacobi algorithms both produced the correct eigenvalues of an arb. NxN matrix. 

To check whether the tuned Jacobi was faster I computed eigenvalues of matrices of increasing dimension, recorded the running time and compared. 
I varied the dimension of the input matrix in order to estimate the time complexity and varied the number Lanczos iterations done while building matrix T 
to show a potential speed up. This was justified by the investigation of the convergence of the lowest eigenvalue of matrices of increasing dimension as a 
function Lanczos iterations n (both for the reg. and tuned Jacobi algorithms) to display the validity of the approximation for n<N. Finally, I chose a 
value for n (4N/5) and compared the running times for the reg. Jacobi on a real symmetric matrix and the tridiagonal matrix T with the tuned Jacobi 
algorithm on matrix T. This showed that the Jacobi algorithm is O(n) faster when tuned for a tridiagonal matrix. The time complexity was improved 
from O(n^3) to O(n^2), which is indicated by the fits on the figure. 

Self-evaluation: I believe that I have fulfilled the requirements of the exercise and presented my work in a clear way, thus evaluating my own
performance as earning 10/10 points. 
