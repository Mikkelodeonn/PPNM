CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.fiterror.png : Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set output "$@" ;\
			set title "Activity of ThX as a function of time"; \
			set ylabel "Activity [arb. u.]"; \
			set xlabel "Time [days]"; \
			plot \
					"$<" index 1 with lines lc "red" title "least squares fit" \
					, "$<" index 2 with lines lc "dark-green" title "fit + error" \
					, "$<" index 3 with lines lc "dark-green" title "fit - error" \
					, "data.txt" using 1:2:3 with yerrorbars title "data"; \
		' | tee log.decay.gpi | gnuplot

Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

ls.dll: ../A/lslib.cs ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs ; $(MKLIB)
main.exe: main.cs ls.dll ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*