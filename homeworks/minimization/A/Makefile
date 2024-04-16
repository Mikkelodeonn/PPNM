
out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs minimize.dll
	mcs -target:exe -out:main.exe -reference: main.cs minimize.dll

minimize.dll: minimize.cs matrix.cs vector.cs qrgs.cs
	mcs -target:library -out: minimize.dll minimize.cs matrix.cs vector.cs qrgs.cs

clean:
	$(RM) *.exe *.dll *.txt

