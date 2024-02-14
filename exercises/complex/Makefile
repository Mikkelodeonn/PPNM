Out.txt:main.exe
	mono $< > $@

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:./cmath.dll $^

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll -target:exe -out:main.exe main.cs

clean:
	$(RM) main.exe Out.txt
