Out.3bodyproblem.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set out "$@";\
		set title "8-Figure solution to the 3-body problem (m1=m2=m3=1, G=1)";\
		set xlabel "x";\
		set ylabel "y";\
		set yrange [-1:1];\
		plot\
				"$<" using 2:3 w l lw 8 lc "dark-spring-green" title "m1" \
				,"$<" using 6:7 w l lw 5 lc "dark-orange" title "m2" \
				,"$<" using 10:11 w l lw 2 lc "black" title "m3";\
	'| tee log.3body.gpi | gnuplot

Out.txt:main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs RK.dll
	mcs -target:exe -out:main.exe -reference:RK.dll main.cs

RK.dll: ../A/RK.cs ../A/vector.cs ../A/matrix.cs ../A/binary_search.cs ../A/genlist.cs
	mcs -target:library -out:RK.dll $^

clean:
	$(RM) *.exe *.dll [Oo]ut* *.png *.gpi