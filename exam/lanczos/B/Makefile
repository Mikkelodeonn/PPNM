Out.convergence.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set out "$@";\
		set title "Convergence of the ground state energy as a function of N";\
		set ylabel "energy [Hartree]";\
		set xlabel "N";\
		set yrange [-1:3];\
		plot\
				"$<" with lines title "calculated" \
				,-0.5 with lines title "exact";\
	'| tee log.gpi | gnuplot

Out.txt:main.exe
	mono $< 1> $@ 2> log.txt
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

lanczos.dll: ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs ../A/random.cs ../A/lanczos.cs EVD.cs
	mcs -target:library -out:lanczos.dll $^

main.exe:main.cs lanczos.dll 
	mcs -target:exe -out:main.exe -reference:lanczos.dll main.cs 

clean:
	$(RM) *.exe *.dll *.txt [Oo]ut* 