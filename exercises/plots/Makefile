CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

all : Out.erf.gnuplot.svg Out.gamma.gnuplot.svg Out.lngamma.gnuplot.svg

Out.erf.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@"  ;\
		set decimalsign ",";\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out;\
		set grid ;\
		set title "Error function" ;\
		plot \
			"$<" index 0 with lines notitle \
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle; \
	' | tee log.erf.gpi | gnuplot


Out.gamma.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set title "Gamma function" ;\
		plot \
			"$<" index 1 with lines notitle \
			,"gamma.data.txt" with points pointtype 6 notitle ;\
	' | tee log.gamma.gpi | gnuplot

Out.lngamma.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set title "Logarithm of Gamma function" ;\
		plot \
			"$<" index 2 with lines notitle \
			,"lngamma.data.txt" with points pointtype 6 notitle ;\
	' | tee log.lngamma.gpi | gnuplot

Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

sfuns.dll: sfuns.cs ; $(MKLIB)
main.exe: main.cs sfuns.dll ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
