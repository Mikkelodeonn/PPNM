all: Out.damped.int.png Out.simple.int.png Out.eliptical.motion.png Out.circular.motion.png Out.rel.motion.png

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

Out.circular.motion.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "(1/u)*cos(φ)";\
			set ylabel "(1/u)*sin(φ)";\
			set size square;\
			set xrange [-1.5:1.5];\
			set yrange [-1.5:1.5];\
			set title "Newtonian circular motion (i)";\
			plot\
					"$<" index 4 with lines title "[eps=0, u(0)=1, u´(0)=0]"; \
			'|tee log.ode.gpi|gnuplot

Out.eliptical.motion.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "(1/u)*cos(φ)";\
			set ylabel "(1/u)*sin(φ)";\
			set size square;\
			set title "Newtonian eliptical motion (ii)";\
			plot\
					"$<" index 5 with lines title "[eps=0, u(0)=1, u´(0)=-0.5]"; \
			'|tee log.ode.gpi|gnuplot

Out.rel.motion.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set xlabel "(1/u)*cos(φ)";\
			set ylabel "(1/u)*sin(φ)";\
			set size square;\
			set xrange [-2.5:2.5];\
			set yrange [-2.5:2.5];\
			set title "Relativistic orbital precession (iii)";\
			plot\
					"$<" index 6 with lines title "[eps=0.01, u(0)=1, u´(0)=-0.5]"; \
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