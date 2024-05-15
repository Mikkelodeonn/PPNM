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
				"$<" index 0 with points title "data"\
				,"$<" index 1 with lines title "fit";\
			'| tee log.gpi | gnuplot 

Out.txt: main.exe
	mono $< >$@ 2>log
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs ann.cs minimize.cs rndmin.cs simplex.cs neural.dll
	$(MKEXE)

neural.dll: \
	../../../mylibrary/matrix.cs \
	../../../mylibrary/vector.cs \
	../../linear_equations/qrgs.cs
	$(MKLIB)

clean:
	$(RM) *.exe *.dll *.txt *.gpi *.png 
