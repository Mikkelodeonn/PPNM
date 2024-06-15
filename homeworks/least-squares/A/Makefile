CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.decay.png : Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set output "$@" ;\
			set title "Activity of ThX as a function of time"; \
			set ylabel "Activity [log(units)]"; \
			set xlabel "Time [days]"; \
			plot \
					"$<" index 1 with lines title "least square fit" \
					, "data.txt" using 1:2:3 with yerrorbars title "data"; \
		' | tee log.decay.gpi | gnuplot

Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

ls.dll: lslib.cs matrix.cs vector.cs qrgs.cs ; $(MKLIB)
main.exe: main.cs ls.dll ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*