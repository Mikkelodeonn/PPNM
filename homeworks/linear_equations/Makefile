Out.txt:main.exe
	mono $< > $@

matrix.dll:matrix.cs vector.cs
	mcs -target:library -out:matrix.dll matrix.cs vector.cs

main.exe:main.cs matrix.dll QRGS.cs
	mcs -target:exe -out:main.exe -reference:matrix.dll main.cs QRGS.cs

clean:
	$(RM) main.exe Out.txt 