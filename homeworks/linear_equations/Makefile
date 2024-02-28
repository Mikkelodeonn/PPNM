Out.txt:main.exe
	mono $< > $@

matrix.dll:matrix.cs vector.cs
	mcs -target:library -out:matrix.dll matrix.cs vector.cs

main.exe:main.cs matrix.dll QRGS.cs random.cs
	mcs -target:exe -out:main.exe -reference:matrix.dll main.cs QRGS.cs random.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*