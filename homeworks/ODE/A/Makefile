all: Out.damped.png Out.simple.png

Out.damped.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "time [s]";\
			set ylabel "y";\
			set title "Damped pendulum (scipy example)";\
			set grid;\
			plot\
					"$<" index 0 with lines title "theta(t)" \
					,"$<" index 1 with lines title "omega(t)"; \
			'|tee log.ode.gpi|gnuplot

Out.simple.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "time [s]";\
			set ylabel "y";\
			set title "Simple harmonic oscillator";\
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

RK.dll:RK.cs vector.cs matrix.cs binary_search.cs genlist.cs
	mcs -target:library -out:RK.dll RK.cs vector.cs matrix.cs binary_search.cs genlist.cs

clean:
	$(RM) *.exe *.dll [Oo]ut* *.png *.svg *.gpi