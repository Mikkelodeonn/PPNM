CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.ann.png: Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set title "Neural network curve fitting of g(x) = cos(5x-1) exp(-x^2)";\
			set xlabel "x";\
			set ylabel "g(x)";\
			plot\
				"$<" index 0 with points pt 1 title "data"\
				,"$<" index 1 with lines title "fit"\
				,"$<" index 3 with points pt "." lc "dark-green" title "1st derivative"\
				,"$<" index 5 with points pt "." lc "blue" title "2nd derivative"\
				,"$<" index 6 with points pt "." lc "red" title "anti-derivative";\
		'| tee log.gpi | gnuplot 

Out.txt: main.exe
	mono $< >$@ 2>log
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs ../A/ann.cs ../A/minimize.cs ../A/rndmin.cs ../A/simplex.cs neural.dll
	$(MKEXE)

neural.dll: ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs
	$(MKLIB)

clean:
	$(RM) *.exe *.dll *.txt *.gpi *.png log
