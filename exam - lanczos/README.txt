Exam question 12: Lanczos tridiagonalization algorithm.

A) Implement the Lanczos tridiagonalization algorithm for real symmetric matrices.

I have succesfully implemented the Lanczos tridiagonalization algorithm for real symmetric matrices, as described in the provided Wikipedia article. 
The method containing the implementation takes a matrix 'A' and an integer 'n' as inputs. 'A' being a real symmetric matrix and 'n' the number of Lanczos 
iterations, and thus also the dimension of the resulting tridiagonal matrix 'T'. The algorithm further outputs the matrix 'V', containing orthonormal
columns and fulfilling the identity T = V^T*A*V. I have tested the algorithm and provided checks for the case of n=N and n<N,
where N is the dimension of the input matrix A. 

B) Consider the hydrogen atom using our discretization method with the given Δr and rmax=NΔr. 
Use the Lanczos iteration algorithm and build a size-n (where n≤N) tridiagonal representation T of the Hamiltonian. 
Calculate the ground state energy of the matrix T. Investigate the convergence of the ground state energy as function of n.

I built the Hydrogen representation of Hydrogen using the procedure outlined in the "eigenvalues" homework, with rmax=8 Bohr radii and dr=0.1 Bohr radii. 
I then used my Lanczos method to approximate the Hamiltonian on a tridiagonal form 'T', and calculated the lowest eigenvalue (i.e. the ground state energy),
by QR diagonalization (I wanted to use something other than the Jacobi eigenvalue algorithm, as that was to be explored in exercise C). Finally, I plotted
the convergence of the ground state energy as a function of n(<=N).


C) Check whether Jacobi eigenvalue algorithm can be tuned to take advantage of the tridiagonal form of a matrix.

In order to check whether the Jacobi eigenvalue algorithm could be tuned by the Lanczos iterations, I first showed that for a randomly generated 10x10 matrix
the regular Jacobi algorithm and the one applied to the resulting 'T' matrix from performing Lanczos iterations indeed produced the same eigenvalues. 
Then I solved for the ground state energy of the Hydrogen atom once again, now timing the program both for the regular and tuned Jacobi algorithms, while
also comparing their presicion. I chose to use a number of Lnaczos iterations equal to half the dimension of the input matrix, so n=N/2. This was justified
by the convergence plot produced for various input matrix sizes (10 -> 100). Lastly, I recorded and compared the running times of the regular Jacobi algorithm
with the Lanczos tuned variant as a function of N, for various values of n, showing a considerable speed-up without much loss of precision.

Self-evaluation: I believe that I have fulfilled the requirements of the exercise and presented my work in a clear way, thus evaluating my own
performance as earning 10/10 points. 
