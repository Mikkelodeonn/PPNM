Out.convergence.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set out "$@";\
		set title "Convergence of the ground state energy of Hydrogen as a function of n";\
		set ylabel "energy [Hartree]";\
		set xlabel "n";\
		set yrange [-1:27];\
		set xrange [0:32];\
		set grid;\
		plot\
				-0.5 with lines lw 2 lc "dark-orange" title "exact"\
				,"$<" index 1 skip 1 with lines lc "royalblue" lw 4 title "calculated";\
	'| tee log.gpi | gnuplot

Out.txt:main.exe
	mono $< 1> $@ 2> log.txt
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

lanczos.dll: ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs ../A/random.cs ../A/lanczos.cs 
	mcs -target:library -out:lanczos.dll $^

main.exe:main.cs lanczos.dll 
	mcs -target:exe -out:main.exe -reference:lanczos.dll main.cs 

clean:
	$(RM) *.exe *.dll *.txt *.gpi [Oo]ut* 