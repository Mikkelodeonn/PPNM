Out.txt:main.exe
	mono $< > $@

matrix.dll: ../A/matrix.cs ../A/vector.cs
	mcs -target:library -out:matrix.dll $^

main.exe:main.cs matrix.dll 
	mcs -target:exe -out:main.exe -reference:matrix.dll main.cs ../A/qrgs.cs ../A/random.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*