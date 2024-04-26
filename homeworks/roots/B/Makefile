all: out.txt out.wave_func.png

out.wave_func.png: out.txt Makefile
	echo '\
		set terminal png background "white";\
		set output "$@";\
		set ylabel "wave function";\
		set xlabel "r [bohr radii]";\
		plot\
		"$<" index 1 with lines lw 2 title "calculated"\
		, "$<" index 2 with lines lt 4 lw 2 title "exact";\
		' | tee log.gpi | gnuplot

out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs roots.dll
	mcs -target:exe -out:main.exe -reference:roots.dll main.cs

roots.dll: ../A/roots.cs RK.cs matrix.cs vector.cs qrgs.cs genlist.cs
	mcs -target:library -out:roots.dll $^

clean:
	$(RM) *.exe *.dll *.gpi *.png [Oo]ut*
