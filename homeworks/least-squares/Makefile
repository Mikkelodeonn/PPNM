Out.decay.svg : Out.txt Makefile
	echo '\
			set terminal svg background "white";\
			set out "$<" ;\
			plot \
					"Out.txt" index 1 with lines notitle ;\
		'|tee log.decay.gpi|gnuplot

Out.txt:main.exe
	mono $< >$@

ls.dll:matrix.cs vector.cs qrgs.cs lslib.cs
	mcs -target:library -out:ls.dll matrix.cs vector.cs qrgs.cs lslib.cs

main.exe:main.cs ls.dll
	mcs -target:exe -out:main.exe -reference:ls.dll main.cs lslib.cs

clean: 
	$(RM) *.exe *.dll [Oo]ut* *.svg