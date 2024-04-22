all: Out.damped.int.png Out.simple.int.png

Out.damped.int.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "time [s]";\
			set ylabel "y";\
			set title "Linear interpolation of damped pendulum";\
			set grid;\
			plot\
					"$<" index 0 with lines title "theta(t)" \
					,"$<" index 1 with lines title "omega(t)"; \
			'|tee log.ode.gpi|gnuplot

Out.simple.int.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "time [s]";\
			set ylabel "y";\
			set title "Linear interpolation of simple harmonic oscillator";\
			set grid;\
			plot\
					"$<" index 2 with lines title "position(t)" \
					,"$<" index 3 with lines title "velocity(t)"; \
			'|tee log.ode.gpi|gnuplot


Out.txt:main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs RK.dll
	mcs -target:exe -out:main.exe -reference:RK.dll main.cs

RK.dll: ../A/RK.cs ../A/vector.cs ../A/matrix.cs ../A/binary_search.cs ../A/genlist.cs
	mcs -target:library -out:RK.dll $^

clean:
	$(RM) *.exe *.dll [Oo]ut* *.png *.svg *.gpi